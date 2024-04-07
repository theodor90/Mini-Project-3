using System.Numerics;
using System.Runtime.Intrinsics.X86;

//List<Asset> assetList = new List<Asset> {
//    new Computer("ASUS ROG", "B550-F", new DateTime(2020, 11, 24), 243, swe),
//    new Computer("HP", "14S-FQ1010NO", new DateTime(2022, 01, 30), 679, usa),
//    new Phone("Samsung", "S20 Plus", new DateTime(2020, 09, 12), 1500, swe),
//    new Phone("Sony Xperia", "10 III", new DateTime(2020, 03, 06), 800,usa),
//    new Phone("Iphone", "10", new DateTime(2018, 11, 25), 951, greece),
//    new Computer("HP", "Elitebook", new DateTime(2021, 08, 30), 2234, greece),
//    new Computer("HP", "Elitebook", new DateTime(2020, 07, 30), 2234, swe)
//};

//// creating a set list of products, mostly for testing purposes

//productList.Add(new Computer("HP", "Elitebook", "Sweden", "2020-10-02", "SEK", 588));
//productList.Add(new Computer("Asus", "W234", "USA", "2017-04-21", "USD", 1200));
//productList.Add(new Computer("Lenovo", "Yoga 730", "USA", "2018-05-28", "USD", 835));
//productList.Add(new Computer("Lenovo", "Yoga 730", "USA", "2019-05-21", "USD", 1030));
//productList.Add(new Computer("HP", "Elitebook", "Spain", "2019-06-01", "EUR", 1423));

//productList.Add(new Phone("iPhone", "8", "Spain", "2018-12-29", "EUR", 970));
//productList.Add(new Phone("iPhone", "11", "Spain", "2020-09-25", "EUR", 990));
//productList.Add(new Phone("iPhone", "X", "Sweden", "2018-07-15", "SEK", 1245));
//productList.Add(new Phone("Motorola", "Razr", "Sweden", "2020-03-16", "SEK", 970));

//assetList.Add(new Laptop("Dell", "XPS 13", "USA", new DateTime(2021, 01, 15), 200m, new Office("USA", "$")));
//assetList.Add(new Laptop("Asus", "ZenBook", "USA", new DateTime(2020, 01, 15), 300m, new Office("USA", "$")));
//assetList.Add(new Laptop("Lenovo", "ThinkPad", "Sweden", new DateTime(2022, 01, 15), 350m, new Office("Sweden", "SEK")));
//assetList.Add(new Laptop("HP", "Elitebook", "Sweden", new DateTime(2021, 03, 15), 950m, new Office("Sweden", "SEK")));

//assetList.Add(new MobilePhone("Samsung", "Galaxy S21", "Spain", new DateTime(2021, 12, 10), 150m, new Office("Spain", "€")));
//assetList.Add(new MobilePhone("Apple", "iPhone 13", "Spain", new DateTime(2020, 12, 10), 250m, new Office("Spain", "€")));
//assetList.Add(new MobilePhone("Samsung", "Galaxy S20", "Spain", new DateTime(2022, 02, 10), 100m, new Office("Spain", "€")));

class Program
{
    static void Main(string[] args)
    {
        List<Asset> assetList = new List<Asset> {
            new Computer("ASUS", "ROG", new DateTime(2020, 11, 24), 243, "swe"),
            new Computer("HP", "14S-FQ1010NO", new DateTime(2022, 01, 30), 679, "usa"),
            new Phone("Samsung", "S20 Plus", new DateTime(2020, 09, 12), 1500, "swe"),
            new Phone("Sony Xperia", "10 III", new DateTime(2020, 03, 06), 800, "usa"),
            new Phone("Iphone", "10", new DateTime(2018, 11, 25), 951, "greece"),
            new Computer("HP", "Elitebook", new DateTime(2021, 08, 30), 2234, "greece"),
            new Computer("HP", "Elitebook", new DateTime(2020, 07, 30), 2234, "swe")
        };

        // Sort the list of assets by type and purchase date
        var sortedAssetList = assetList.OrderBy(asset => asset.GetType().Name).ThenBy(asset => asset.PurchaseDate);

        // Writing out the headers for the list
        Console.WriteLine("Type".PadRight(20) + "Brand".PadRight(20) + "Model".PadRight(20) + "Purchase Date".PadRight(20) + "Price".PadRight(20) + "Office".PadRight(20));
        Console.WriteLine("----".PadRight(20) + "-----".PadRight(20) + "-----".PadRight(20) + "-------------".PadRight(20) + "------------".PadRight(20) + "------".PadRight(20));

        // Print the list of assets
        foreach (var asset in sortedAssetList)
        {
            PrintAsset(asset);
        }

        // Loop to add new products
        while (true)
        {
            try
            {
                // Prompt user to enter details of the new product
                Console.WriteLine("Enter the type of the device (Computer/Phone):");
                string type = Console.ReadLine();

                // Check if the type is valid
                if (type.ToLower() != "computer" && type.ToLower() != "phone")
                {
                    throw new ArgumentException("Invalid device type. Please enter 'Computer' or 'Phone'.");
                }

                Console.WriteLine("Enter the name of the device:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the model of the device:");
                string model = Console.ReadLine();

                // Prompt user to enter purchase date until its in the correct format
                DateTime purchaseDate = DateTime.MinValue;
                bool validDate = false;
                while (!validDate)
                {
                    Console.WriteLine("Enter the purchase date of the device (YYYY-MM-DD):");
                    string dateString = Console.ReadLine();
                    validDate = DateTime.TryParse(dateString, out purchaseDate);
                    if (!validDate)
                    {
                        Console.WriteLine("Invalid date format. Please enter the date in the format YYYY-MM-DD.");
                    }
                }

                Console.WriteLine("Enter the price of the device:");
                decimal price;
                while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
                {
                    Console.WriteLine("Invalid price. Please enter a valid positive number.");
                }

                Console.WriteLine("Enter the office of the device:");
                string office = Console.ReadLine();

                // Add the new product to the list
                if (type.ToLower() == "computer")
                {
                    assetList.Add(new Computer(name, model, purchaseDate, price, office));
                }
                else if (type.ToLower() == "phone")
                {
                    assetList.Add(new Phone(name, model, purchaseDate, price, office));
                }

                Console.WriteLine("Device added successfully!");

                // Ask if the user wants to add another device
                Console.WriteLine("Do you want to add another device? (yes/no)");
                string response = Console.ReadLine().ToLower();
                if (response != "yes")
                {
                    break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input. " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid input. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(ex.Message);
            }
        }

        // Print the updated list of assets
        foreach (var asset in assetList)
        {
            PrintAsset(asset);
        }
    }

    static void PrintAsset(Asset asset)
    {
        if (asset.IsCloseToEndOfLife())
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (asset.IsNearingEndOfLife())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        Console.WriteLine($"{asset.GetType().Name.PadRight(20)}{asset.Name.PadRight(20)}{asset.Model.PadRight(20)}{asset.PurchaseDate.ToShortDateString().PadRight(20)}{asset.Price.ToString("C").PadRight(20)}{asset.Office.PadRight(20)}");
        Console.ResetColor(); // Reset color to default
    }
}
