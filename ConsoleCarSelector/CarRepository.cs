using Models;
using System;
using System.Collections.Generic;

namespace ConsoleCarSelector
{
    public class CarRepository
    {
        private string root_url;

        public CarRepository(string root_url)
        {
            this.root_url = root_url;
        }

        public IEnumerable<CarListItem> GetCarsByPrice(int priceFrom, int priceTo, string currency)
        {
            return null;
        }

        public string GetCarsDescription(string url)
        {
            return null;
        }
    }
}