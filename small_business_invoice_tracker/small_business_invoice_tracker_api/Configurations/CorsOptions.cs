namespace small_business_invoice_tracker.Configurations
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
