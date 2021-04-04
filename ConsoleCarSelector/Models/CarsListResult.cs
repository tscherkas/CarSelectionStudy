using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class CarsListResult
    {
        public List<CarListItem> adverts { get; set; }
         
    }
}