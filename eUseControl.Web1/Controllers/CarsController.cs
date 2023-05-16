using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Web1.ViewsModels;

namespace eUseControl.Web1.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly IAllCarsCategory _allCatigories;

        public CarsController(IAllCars iAllCars, IAllCarsCategory iCarsCat)//// можно ли интерфейс или надо класс реализ интерф
        {
            _allCars = iAllCars;
            _allCatigories = iCarsCat;
        }

        public ViewResult List()
        {
            CarsListViewModel obj = new CarsListViewModel();
            obj.allCars = _allCars.Cars;
            obj.currCategory = "Автомобили";
            return View(obj);
        }
    }
}