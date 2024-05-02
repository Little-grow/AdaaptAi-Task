namespace WebApplication1.Helper
{
    public class Jwt
    {
        public string Key { get; set; }

        public int ExpiryTimeInMinutes { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
