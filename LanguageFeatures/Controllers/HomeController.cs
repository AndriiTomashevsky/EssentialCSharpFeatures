using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(Product.GetProducts().Select(p => p?.Name));
        }
    }
}