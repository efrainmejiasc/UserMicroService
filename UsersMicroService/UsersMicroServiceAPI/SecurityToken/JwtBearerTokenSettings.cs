namespace UsersMicroServiceAPI.SecurityToken
{
    public class JwtBearerTokenSettings
    {
       
        public string SecretKey { get; set; }
       
        public string Audience { get; set; }

        public string Issuer { get; set; }

        public int ExpiryTimeInDays { get; set; }

        public int ExpiryTimeInMinutes { get; set; }
    }
}
