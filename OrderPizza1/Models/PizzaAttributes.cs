﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderPizza1.Models
{
    public class PizzaAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public double Amount { get; set; }
        public int Size { get; set; }
        public bool IsSelected { get; set; }

        //navigation properties
        //public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}