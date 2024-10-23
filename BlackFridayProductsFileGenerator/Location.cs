using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFridayProductsFileGenerator
{
    public class Location
    {
        public Location(string country, string city)
        {
            this.Country = country;
            this.City = city;
        }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
