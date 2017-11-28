namespace DVideo.Settings
{
    public class AuthenticationSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifetimeInMinutes { get; set; }
    }
}