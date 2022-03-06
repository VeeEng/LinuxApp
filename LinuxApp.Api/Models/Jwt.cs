namespace LinuxApp.Api.Models
{
    public class Jwt
    {
        public const string Name = "JWTSettings";
        public const string KeyName = "JWTSettings:Key";
        public const string IssuerName = "JWTSettings:Issuer";
        public const string AudienceName = "JWTSettings:Audience";

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
