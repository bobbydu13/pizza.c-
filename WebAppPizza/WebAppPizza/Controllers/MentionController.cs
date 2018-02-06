using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppPizza.Models;

namespace WebAppPizza.Controllers
{
    public class MentionController : Controller
    {
        public IActionResult Index()
        {
            var mention = new Mention
            {
                Title = "Mentions légales",
                Paragraphe1 = "qerkjfhguilqefgviojhsdfiocvjnqsdfiojvoqerijpozej",
                Paragraphe2 = "qerkjfhguilqefgviojhsdfiocvjnqsdfiojvoqerijpozej",
                Paragraphe3 = "qerkjfhguilqefgviojhsdfiocvjnqsdfiojvoqerijpozej"
            };

            ViewBag.MonTitle = mention.Title;
            ViewData["MonTitle"] = mention.Title;

            return View(mention);
        }
    }
}