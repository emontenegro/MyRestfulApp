using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Currency.Models
{
    public class MyCurrency
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public int decimal_places { get; set; }
        public decimal todolar { get; set; }
    }
}
