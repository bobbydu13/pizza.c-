using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppPizza.Models;

namespace WebAppPizza.Controllers
{
    public class PizzaController : Controller
    {
        private const int itemsPerPage = 6;
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>
        {
           
            new Pizza(1,"Reine",10.40m,"Sauce tomate,jambon,champignon","Pizza_reine.jpg"),
            new Pizza(2,"Saumon",12,"Sauce tomate,saumon","Pizza_saumon.jpg"),
            new Pizza(3,"Chorizo",11.50m,"Sauce tomate,chorizo,champignon","Pizza_chorizo.jpg"),
            new Pizza(4,"Montagnarde",12,"Creme fraiche,lardons,capres","Pizza_montagnarde.jpg"),
            new Pizza(5,"Cremière",12,"Creme fraiche,emmental","Pizza_cremière.jpg"),
            new Pizza(6,"Figatelli",12,"Sauce tomate,figatelli","Pizza_figatelli.jpg"),
            new Pizza(7,"Aubergines",12,"Sauce tomate,aubergines","Pizza_auberginesn.jpg"),
            new Pizza(8,"Roquefort",12,"Creme fraiche,roquefort","Pizza_roquefort.jpg")
        };

        [HttpGet("[controller]/[action]/Page/{page?}")]
        public IActionResult Index(int  page = 1)
        {
            
            //var query = Pizzas.Where(p=>p.PriceHT<12);// linq
            //var query2 = from p in Pizzas
            //           where p.PriceHT < 12
            //          select p;
            // var champQuery = Pizzas.Where(p => p.Description.Contains("champignons"));// fonction anonyme 

            var pizzasVM = new List<PizzaViewModel>();

            ViewBag.ItemsCount = Math.Ceiling((decimal)Pizzas.Count / itemsPerPage);
            ViewBag.CurrentPage = page;

            //Pizzas.Where(p=>p.PriceHT<18).ToList().ForEach(p =>
            //{
            //    pizzasVM.Add(new PizzaViewModel() { Pizza = p });

            //});
            Pizzas.Skip((page-1)* itemsPerPage).Take(itemsPerPage).ToList().ForEach(p =>
            { 
                  pizzasVM.Add(new PizzaViewModel() { Pizza = p });
            });
            return View(pizzasVM);
        }

        public PartialViewResult Detail(int id)
        {
            var pizza = this.Pizzas.Find(p => p.IDPizza == id);
            var pizzaVM = new PizzaViewModel()
            {
                Pizza = pizza
            };

            return PartialView("DetailPartial", pizzaVM);
        }
    }
}