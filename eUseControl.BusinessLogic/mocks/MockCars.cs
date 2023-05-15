﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.mocks;

namespace eUseControl.BusinessLogic.mocks
{
    internal class MockCars : IAllCars
    {

        private readonly ICarsCategory _categoryCars = new MockCategory();///
        
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car {
                        name = "AMG",
                        shortDesc="",
                        longDesc="",
                        img="",
                        price="400", 
                        isFavourite=true, 
                        available=true, 
                        Category=_categoryCars.AllCategories.First 
                    }
                };
            }
        }



        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
    }
}
