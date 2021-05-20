namespace ExternalIntegration
{
    public class TelstarRequest
    {
        public string Company { get; set; }
        public string SecretCompanyCode { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public string[] Features { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width{ get; set; }
        public int Length { get; set; }
    }
}
