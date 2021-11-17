namespace Server.Models
{
    public class AppSettings
    {
        public static AppSettings appSettings {get; set;}
        public string JwtSecret {get; set;}
        public string GoogleClientId  {get; set;}
        public string GoogleClientSecret  {get; set;}
        public string JwtEmailEncryption {get; set;}
        public string HueAppId {get; set;}
        public string HueClientId {get; set;}
        public string HueClientSecret {get; set;}
    }
}