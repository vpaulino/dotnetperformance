using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlackFridayProductsFileGenerator
{
    public class Sell
    {

        public Sell(DateTime transactionTimestamp, string country, string city, string storeName, string productName, decimal price)
        {
            TransactionTimestamp = transactionTimestamp;
            Country = country;
            City = city;
            StoreName = storeName;
            ProductName = productName;
            Price = price;
        }

        public DateTime TransactionTimestamp { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string StoreName { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{TransactionTimestamp.ToString("yyyy-MM-ddTHH:mm:ss")};{Country};{City};{StoreName};{ProductName};{Price}";
        }

    }
}
