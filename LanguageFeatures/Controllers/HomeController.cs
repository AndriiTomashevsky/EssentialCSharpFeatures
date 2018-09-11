using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            decimal total = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] is decimal d) // The is keyword performs a type check, and if a value is of the specified type, it will assign the value to a new variable
                {
                    total += d;
                }
            }

            return View("Index", new string[] { $"Total: {total:C2}" });
        }
    }
}