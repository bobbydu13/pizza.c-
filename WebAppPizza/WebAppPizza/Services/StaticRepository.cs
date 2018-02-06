using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPizza.Models;

namespace WebAppPizza.Services
{
    public class StaticRepository : IStaticRepository
    {
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>()
        {
            new Pizza (1 , "Anchois",12, "Sauce tomate, anchois, olives",
                "Pizza_636524693379260770.jpg")
        };
    }
}
