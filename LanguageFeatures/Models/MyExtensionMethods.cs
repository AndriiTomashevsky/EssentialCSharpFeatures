using System;
using System.Collections.Generic;
using System.Linq;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;

            foreach (Product prod in products)
            {
                total += prod?.Price ?? 0;
            }

            return total;
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selector)
        {
            foreach (Product prod in productEnum)
            {
                if (selector(prod))
                {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, int, bool> selector)
        {
            int count = productEnum.Count();

            foreach (Product prod in productEnum)
            {
                if (selector(prod, count))
                {
                    yield return prod;
                }
            }
        }

    }
}