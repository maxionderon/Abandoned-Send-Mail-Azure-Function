namespace Maxionderon.Function.Services{

    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Microsoft.Extensions.Logging;

    using Maxionderon.Function.Models;

    public class RecaptchaService {

        private Dictionary<string,string> recaptchaCheck = new Dictionary<string, string>();
        private ILogger log;

        public RecaptchaService(string recaptchaResponse, string recaptchaSecret, ILogger log) {

            this.recaptchaCheck.Add("response", recaptchaResponse);
            this.recaptchaCheck.Add("secret", recaptchaSecret);
            this.log = log;

        }

        public async Task<bool> validate() {
        
            HttpClient httpClient = new HttpClient();

            FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(this.recaptchaCheck);
            
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("https://www.google.com/recaptcha/api/siteverify", formUrlEncodedContent);
            
            string httpResponseMessageContent = await httpResponseMessage.Content.ReadAsStringAsync();
                       
            ReCaptchaResponse reCaptchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(httpResponseMessageContent);
            
            log.LogInformation($"{reCaptchaResponse.GetType().ToString()} {reCaptchaResponse.success} {reCaptchaResponse.action} {reCaptchaResponse.challenge_ts}{reCaptchaResponse.hostname} {reCaptchaResponse.score}");
            
            if( reCaptchaResponse.success == false) {
                
                return false;
                
            }
            
            return true;

        }

    }


}

