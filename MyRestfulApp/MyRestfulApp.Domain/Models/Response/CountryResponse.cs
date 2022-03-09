using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestfulApp.Domain.Models.Response
{
    public class CountryResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string locale { get; set; }
        public string currency_id { get; set; }  
    }
}
