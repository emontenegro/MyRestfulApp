using System.Collections.Generic;

namespace MyRestfulApp.Domain.Models.Response
{
    public class SearchResponse
    {
        public string site_id { get; set; }
        public string country_default_time_zone { get; set; }
        public string query { get; set; }  
        public List<Results> results { get; set; }  
    }

    public class Results
    {
        public string id { get; set; }

        public string site_id { get; set; }

        public string title { get; set; }

        public decimal price { get; set; }

        public string permalink { get; set; }

        public Seller seller { get; set; }
    }

    public class Seller
    {
        public int id { get; set; }
    }
}
