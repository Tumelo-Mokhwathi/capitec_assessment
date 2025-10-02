namespace card_dispute_portal.Configurations
{
    public class CorsOptions
    {
        public string AllowedOrigins { get; set; } = String.Empty;
        public string[] GetAllowedOriginsAsArray()
        {
            return AllowedOrigins.Split(',').Select(o => o.Trim()).ToArray();
        }
    }
}
