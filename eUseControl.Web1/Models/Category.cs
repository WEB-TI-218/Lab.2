﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web1.Models
{
    public class Category
    {
        public int id { get; set; }

        public string categoryName { get; set; }

        public string desc { get; set; }

        public List<Car> cars { get; set; }
    }
}