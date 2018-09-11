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
                switch (data[i])
                {
                    case decimal decimalValue: // This case statement matches any decimal value and assigns it to a new variable called decimalValue.
                        total += decimalValue;
                        break;
                    case int intValue when intValue > 50: // This case statement matches int values and assigns them to a variable called intValue, 
                                                          //but only when the value is greater than 50.
                        total += intValue;
                        break;
                }
            }

            return View("Index", new string[] { $"Total: {total:C2}" });
        }
    }
}