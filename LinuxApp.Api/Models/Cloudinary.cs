namespace LinuxApp.Api.Models
{
    public class Cloudinary
    {
        public const string Name = "Cloudinary";
        public const string KeyName = "Cloudinary:ApiKey";
        public const string SecretName = "Cloudinary:ApiSecret";
        public const string CloudinaryName = "Cloudinary:CloudName";
        public string CloudName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }
}
