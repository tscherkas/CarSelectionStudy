using System;

namespace ConsoleCarSelector
{
    class Program
    {
        private static string ROOT_URL = "ab.onliner.by";

        static void Main(string[] args)
        {
            var browser = new CarsRepositoryBrowser(
                new CarRepository(ROOT_URL), 500);            
            Console.WriteLine(browser.FindCarsByPriceAndDescription(1000, 3000, "USD", "техосмотр"));
        }
    }
}
