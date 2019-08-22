namespace Maxionderon.Function.Models
{
    public class ReCaptchaResponse{

        public bool success { get; set; }
        public double score { get; set; }
        public string action { get; set; }
        public string challenge_ts { get; set; }
        public string hostname { get; set; }

    }
    
}