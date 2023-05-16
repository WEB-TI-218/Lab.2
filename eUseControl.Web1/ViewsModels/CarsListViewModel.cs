using eUseControl.Web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web1.ViewsModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }
        public string currCategory { get; set; }
    }
}