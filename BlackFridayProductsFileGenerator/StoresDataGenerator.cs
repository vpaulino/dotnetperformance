
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFridayProductsFileGenerator
{
    public class StoreDataGenerator
    {
       
        public Sell[] GenerateMillionSells(List<Store> stores, List<Location> locations)
        {
            var random = new Random();
            var sells = new Sell[1_000_000];

            for (int i = 0; i < 1_000_000; i++)
            {
                // Randomly select a store and product
                var store = stores[random.Next(stores.Count)];
                var product = store.Products[random.Next(store.Products.Count)];

                // Randomly select a location
                var location = locations[random.Next(locations.Count)];

                // Generate a random timestamp within the last year
                var startDate = new DateTime(2023, 1, 1);
                var range = (DateTime.Now - startDate).Days;
                var transactionTimestamp = startDate.AddDays(random.Next(range)).AddSeconds(random.Next(86400));

                // Create a Sell object
                sells[i] = new Sell(
                    transactionTimestamp,
                    location.Country,
                    location.City,
                    store.Name,
                    product.Name,
                    product.Price
                );
            }

            return sells;
        }


        public List<Location> Locations { get; set; }
   
        public static List<Store> GenerateStores()
        {
            // List of top 50 stores
            var stores = new List<Store>
            {
                new Store("Best Buy", GenerateProductsForCategory("Electronics")),
                new Store("Home Depot", GenerateProductsForCategory("Gardening")),
                new Store("AutoZone", GenerateProductsForCategory("Automobile Parts")),
                new Store("Trek Bikes", GenerateProductsForCategory("Bikes")),
                new Store("Fry's Electronics", GenerateProductsForCategory("Electronics")),
                new Store("Lowe's", GenerateProductsForCategory("Gardening")),
                new Store("Advance Auto Parts", GenerateProductsForCategory("Automobile Parts")),
                new Store("Specialized Bicycle Components", GenerateProductsForCategory("Bikes")),
                new Store("Micro Center", GenerateProductsForCategory("Electronics")),
                new Store("Ace Hardware", GenerateProductsForCategory("Gardening")),
                new Store("O'Reilly Auto Parts", GenerateProductsForCategory("Automobile Parts")),
                new Store("REI", GenerateProductsForCategory("Bikes")),
                new Store("Newegg", GenerateProductsForCategory("Electronics")),
                new Store("Tractor Supply Co.", GenerateProductsForCategory("Gardening")),
                new Store("Pep Boys", GenerateProductsForCategory("Automobile Parts")),
                new Store("Giant Bicycles", GenerateProductsForCategory("Bikes")),
                new Store("Currys", GenerateProductsForCategory("Electronics")),
                new Store("True Value", GenerateProductsForCategory("Gardening")),
                new Store("NAPA Auto Parts", GenerateProductsForCategory("Automobile Parts")),
                new Store("Cannondale Bicycle Corporation", GenerateProductsForCategory("Bikes"))
            };

            // Add more stores manually or through a loop for 50 total stores.
            return stores;
        }


        public static List<Location> GenerateLocations() 
        {
            return new List<Location>
                {
                    new Location("USA", "New York"),
                    new Location("USA", "Los Angeles"),
                    new Location("USA", "Chicago"),
                    new Location("USA", "Houston"),
                    new Location("USA", "Phoenix"),
                    new Location("Canada", "Toronto"),
                    new Location("Canada", "Vancouver"),
                    new Location("Canada", "Montreal"),
                    new Location("Canada", "Calgary"),
                    new Location("Canada", "Ottawa"),
                    new Location("UK", "London"),
                    new Location("UK", "Manchester"),
                    new Location("UK", "Birmingham"),
                    new Location("UK", "Liverpool"),
                    new Location("UK", "Edinburgh"),
                    new Location("France", "Paris"),
                    new Location("France", "Lyon"),
                    new Location("France", "Marseille"),
                    new Location("France", "Nice"),
                    new Location("France", "Toulouse"),
                    new Location("Germany", "Berlin"),
                    new Location("Germany", "Munich"),
                    new Location("Germany", "Frankfurt"),
                    new Location("Germany", "Hamburg"),
                    new Location("Germany", "Cologne"),
                    new Location("Japan", "Tokyo"),
                    new Location("Japan", "Osaka"),
                    new Location("Japan", "Nagoya"),
                    new Location("Japan", "Fukuoka"),
                    new Location("Japan", "Sapporo"),
                    new Location("Australia", "Sydney"),
                    new Location("Australia", "Melbourne"),
                    new Location("Australia", "Brisbane"),
                    new Location("Australia", "Perth"),
                    new Location("Australia", "Adelaide"),
                    new Location("Brazil", "São Paulo"),
                    new Location("Brazil", "Rio de Janeiro"),
                    new Location("Brazil", "Brasilia"),
                    new Location("Brazil", "Salvador"),
                    new Location("Brazil", "Fortaleza"),
                    new Location("Mexico", "Mexico City"),
                    new Location("Mexico", "Guadalajara"),
                    new Location("Mexico", "Monterrey"),
                    new Location("Mexico", "Puebla"),
                    new Location("Mexico", "Tijuana"),
                    new Location("Italy", "Rome"),
                    new Location("Italy", "Milan"),
                    new Location("Italy", "Naples"),
                    new Location("Italy", "Turin"),
                    new Location("Italy", "Palermo"),
                    new Location("Spain", "Madrid"),
                    new Location("Spain", "Barcelona"),
                    new Location("Spain", "Valencia"),
                    new Location("Spain", "Seville"),
                    new Location("Spain", "Zaragoza"),
                    new Location("India", "Mumbai"),
                    new Location("India", "Delhi"),
                    new Location("India", "Bangalore"),
                    new Location("India", "Hyderabad"),
                    new Location("India", "Chennai"),
                    new Location("China", "Shanghai"),
                    new Location("China", "Beijing"),
                    new Location("China", "Shenzhen"),
                    new Location("China", "Guangzhou"),
                    new Location("China", "Chengdu"),
                    new Location("South Korea", "Seoul"),
                    new Location("South Korea", "Busan"),
                    new Location("South Korea", "Incheon"),
                    new Location("South Korea", "Daegu"),
                    new Location("South Korea", "Daejeon"),
                    new Location("Russia", "Moscow"),
                    new Location("Russia", "Saint Petersburg"),
                    new Location("Russia", "Novosibirsk"),
                    new Location("Russia", "Yekaterinburg"),
                    new Location("Russia", "Nizhny Novgorod"),
                    new Location("South Africa", "Johannesburg"),
                    new Location("South Africa", "Cape Town"),
                    new Location("South Africa", "Durban"),
                    new Location("South Africa", "Pretoria"),
                    new Location("South Africa", "Port Elizabeth"),
                    new Location("Argentina", "Buenos Aires"),
                    new Location("Argentina", "Córdoba"),
                    new Location("Argentina", "Rosario"),
                    new Location("Argentina", "Mendoza"),
                    new Location("Argentina", "La Plata"),
                    new Location("Netherlands", "Amsterdam"),
                    new Location("Netherlands", "Rotterdam"),
                    new Location("Netherlands", "The Hague"),
                    new Location("Netherlands", "Utrecht"),
                    new Location("Netherlands", "Eindhoven")
                };
        }

        private static List<Product> GenerateProductsForCategory(string category)
        {
            var products = new List<Product>();

            switch (category)
            {
                case "Electronics":
                    products.AddRange(new List<Product>
                {
                    new Product("Laptop", 999.99m),
                    new Product("Smartphone", 799.99m),
                    new Product("Tablet", 499.99m),
                    new Product("Smart TV", 1200.99m),
                    new Product("Bluetooth Speaker", 149.99m),
                    new Product("Headphones", 199.99m),
                    new Product("Smartwatch", 249.99m),
                    new Product("Gaming Console", 599.99m),
                    new Product("Digital Camera", 999.99m),
                    new Product("External Hard Drive", 119.99m),
                    new Product("Printer", 179.99m),
                    new Product("Wireless Router", 89.99m),
                    new Product("Drone", 499.99m),
                    new Product("VR Headset", 399.99m),
                    new Product("Smart Home Hub", 129.99m),
                    new Product("Soundbar", 349.99m),
                    new Product("Projector", 699.99m),
                    new Product("Portable Charger", 39.99m),
                    new Product("SSD Drive", 159.99m),
                    new Product("USB Cable", 9.99m)
                });
                    break;

                case "Gardening":
                    products.AddRange(new List<Product>
                {
                    new Product("Lawn Mower", 299.99m),
                    new Product("Garden Hose", 49.99m),
                    new Product("Shovel", 29.99m),
                    new Product("Rake", 19.99m),
                    new Product("Wheelbarrow", 89.99m),
                    new Product("Fertilizer", 39.99m),
                    new Product("Pruning Shears", 24.99m),
                    new Product("Gloves", 9.99m),
                    new Product("Hedge Trimmer", 129.99m),
                    new Product("Leaf Blower", 149.99m),
                    new Product("Watering Can", 14.99m),
                    new Product("Garden Sprayer", 39.99m),
                    new Product("Plant Pots", 19.99m),
                    new Product("Soil", 12.99m),
                    new Product("Compost Bin", 79.99m),
                    new Product("Weed Puller", 15.99m),
                    new Product("Garden Trowel", 9.99m),
                    new Product("Seed Packets", 5.99m),
                    new Product("Lawn Edger", 99.99m),
                    new Product("Plant Food", 29.99m)
                });
                    break;

                case "Automobile Parts":
                    products.AddRange(new List<Product>
                {
                    new Product("Car Battery", 129.99m),
                    new Product("Engine Oil", 29.99m),
                    new Product("Air Filter", 19.99m),
                    new Product("Brake Pads", 59.99m),
                    new Product("Windshield Wipers", 24.99m),
                    new Product("Spark Plugs", 15.99m),
                    new Product("Tire", 199.99m),
                    new Product("Headlights", 49.99m),
                    new Product("Car Jack", 99.99m),
                    new Product("Car Wash Kit", 39.99m),
                    new Product("Car Cover", 59.99m),
                    new Product("Jumper Cables", 29.99m),
                    new Product("Oil Filter", 14.99m),
                    new Product("Coolant", 24.99m),
                    new Product("Car Mats", 49.99m),
                    new Product("Exhaust Pipe", 119.99m),
                    new Product("Fuel Injector", 199.99m),
                    new Product("Radiator", 249.99m),
                    new Product("Brake Fluid", 9.99m),
                    new Product("Transmission Fluid", 34.99m)
                });
                    break;

                case "Bikes":
                    products.AddRange(new List<Product>
                {
                    new Product("Mountain Bike", 799.99m),
                    new Product("Road Bike", 999.99m),
                    new Product("Bike Helmet", 59.99m),
                    new Product("Bike Lock", 29.99m),
                    new Product("Bike Pump", 24.99m),
                    new Product("Cycling Gloves", 19.99m),
                    new Product("Bike Lights", 49.99m),
                    new Product("Bike Rack", 199.99m),
                    new Product("Water Bottle Holder", 9.99m),
                    new Product("Bike Saddle", 79.99m),
                    new Product("Bike Chain", 39.99m),
                    new Product("Pedals", 49.99m),
                    new Product("Cycling Jersey", 89.99m),
                    new Product("Bike Tires", 59.99m),
                    new Product("Cycling Shoes", 129.99m),
                    new Product("Bike Bell", 12.99m),
                    new Product("Reflective Vest", 19.99m),
                    new Product("Bike Mirror", 14.99m),
                    new Product("Pannier Bag", 49.99m),
                    new Product("Chain Lubricant", 9.99m)
                });
                    break;
            }

            return products;
        }
    
           
    }

}
