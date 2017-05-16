﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderPizza1.Models;
using OrderPizza1.ViewModel;

namespace OrderPizza1.Controllers
{
    public class OrderController : Controller
    {
        readonly ApplicationDbContext _context;
        public OrderController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpGet]
        // GET: Order
        public ActionResult Index()
        {
            var model = new PizzaPizzaAttributesViewModel
            {
                PizzaSizes = _context.PizzaAttributes.Where(x => x.Name == "Size"),
                PizzaCrusts = _context.PizzaAttributes.Where(x => x.Name == "Crust"),
                PizzaToppings = _context.PizzaAttributes.Where(x => x.Name == "Topping"),
                SelectedToppings = _context.PizzaAttributes.Where(x => x.Name == "Topping").Select(y => y.IsSelected),
                Customer = new Customer()
            };
            return View(model);
        }

        [Authorize(Roles = "CanOrderPizza")]
        [HttpPost]
        public ActionResult Save(PizzaPizzaAttributesViewModel model)
        {
            if (ModelState.IsValid) return View();
            model.PizzaSizes = _context.PizzaAttributes.Where(x => x.Name == "Size");
            model.PizzaCrusts = _context.PizzaAttributes.Where(x => x.Name == "Crust");
            model.PizzaToppings = _context.PizzaAttributes.Where(x => x.Name == "Topping");
            //SelectedToppings = _context.PizzaAttributes.Where(x => x.Name == "Topping").Select(y => y.IsSelected),
            //Customer = new Customer()
            return View("Index", model);
        }
    }
}