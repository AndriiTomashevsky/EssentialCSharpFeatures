using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        bool FilterByPrice(Product p)
        {
            return (p?.Price ?? 0) >= 20;
        }

        bool FilterByPrice(Product prod, int count)
        {
            return prod.Price > 20 && count > 0;
        }


        public ViewResult Index()
        {
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

            Product[] productArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            Func<Product, bool> nameFilter = delegate (Product prod)
            {
                return prod?.Name?[0] == 'S';
            };

            decimal priceFilterTotal = productArray.Filter(p => FilterByPrice(p)).TotalPrices();

            decimal priceFilterTotal_2 = productArray.Filter((prod, count) => prod.Price > 20 && count > 0).TotalPrices();

            decimal priceFilterTotal_3 = productArray.Filter((prod, count) =>
            {
                // ...multiple code statements...
                bool result = prod.Price > 20 && count > 0;

                return result;
            })
            .TotalPrices();

            decimal nameFilterTotal = productArray.Filter(p => p?.Name?[0] == 'S').TotalPrices();

            return View("Index", new string[] {
                $"Price Total: {priceFilterTotal:C2}",
                $"Price Total 2: {priceFilterTotal_2:C2}",
                $"Price Total 3: {priceFilterTotal_3:C2}",
                $"Name Total: {nameFilterTotal:C2}"});
        }
    }
}