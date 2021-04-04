using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCarSelector
{
    public class CarsRepositoryBrowser
    {
        private CarRepository carRepository;
        private int delay;

        public CarsRepositoryBrowser(CarRepository carRepository, int delay)
        {
            this.carRepository = carRepository;
            this.delay = delay;
        }

        public string FindCarsByPriceAndDescription(int priceFrom,
                                                    int priceTo,
                                                    string currency,
                                                    string description)
        {
            var carsList = this.carRepository.GetCarsByPrice(priceFrom, priceTo, currency);
            var carListFiltered = carsList?.Where(x => IsMatchCarDescription(description, x));

            return carListFiltered?.Aggregate(new StringBuilder(), (sb, car) => sb.AppendLine(car.html_url)).ToString()
                ?? string.Empty;
        }

        private bool IsMatchCarDescription(string description, CarListItem x)
        {
            bool v = this.carRepository.GetCarsDescription(x.url)?.Contains(description, StringComparison.OrdinalIgnoreCase) ?? false;
            if(v)
            {
                Console.WriteLine(x.html_url);
            }
            return v;
        }
    }
}