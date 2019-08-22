using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using System.Collections.Generic;

using SendGrid;
using SendGrid.Helpers.Mail;

using System.Net.Http;


using Maxionderon.Function.Models;
using Maxionderon.Function.Services;

namespace Maxionderon.Function
{
    

    public static class sendMailFunction
   {
        private static readonly HttpClient Http = new HttpClient();

        [FunctionName("sendMailFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "mail")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("sendMailFunction processed a request.");
         
            try {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Email email = JsonConvert.DeserializeObject<Email>(requestBody);

                RecaptchaService recaptchaService = new RecaptchaService(email.recaptcha, Environment.GetEnvironmentVariable("RECAPTCHA_SECRET_KEY"), log);
                
                if(await recaptchaService.validate() == false) {

                    return new BadRequestObjectResult(new[] { "verification failed." });

                }

                //send Email
                SendGridMessage sendGridMessage = new SendGridMessage();
                
                sendGridMessage.SetFrom(email.emailAddress, email.lastName + ", " + email.firstName);
                
                List<EmailAddress> myMails = new List<EmailAddress>();

                myMails.Add(new EmailAddress(Environment.GetEnvironmentVariable("EMAIL1") , Environment.GetEnvironmentVariable("NAME")));
                myMails.Add(new EmailAddress(Environment.GetEnvironmentVariable("EMAIL2") , Environment.GetEnvironmentVariable("NAME")));
                myMails.Add(new EmailAddress(Environment.GetEnvironmentVariable("EMAIL3") , Environment.GetEnvironmentVariable("NAME")));

                sendGridMessage.AddTos(myMails);
                sendGridMessage.SetSubject(email.subject);
                sendGridMessage.PlainTextContent = email.message;

                string apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
                SendGridClient sendGridClient = new SendGridClient(apiKey);

                await sendGridClient.SendEmailAsync(sendGridMessage);

                return new OkObjectResult("email emitted");

            }catch(Exception e) {

                log.LogInformation(e.ToString());

                return new BadRequestObjectResult("Bad Request");  

            }          

        }

    }
}