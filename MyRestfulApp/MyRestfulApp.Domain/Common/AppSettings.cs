namespace MyRestfulApp.Domain.Common
{
    public class AppSettings
    {
        public MercadoLibre MercadoLibre { get; set; }
    }

    public class MercadoLibre
    {
        public string BaseUrl { get; set; }
        public string ClassifiedLocations { get; set; }
        public string Sites { get; set; }
    }

}
