using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SeedData
    {
        #region Utils
        static readonly Random random = new Random();

        static string RandomStr(int min = 5, int max = 5, bool spaces = false, string charset = "asdffghjklqwertyuiopzxcvbnm0123456789")
        {
            if (spaces) charset += "           ";
            string result = "";
            for (int i = 0; i <= min && i < max; ++i)
            {
                char x = charset[random.Next(0, charset.Length)];
                result += x;
            }

            return result;
        }
        #endregion Utils

        internal static IEnumerable<Product> GenerateProducts(int upperLimit = 7)
        {
            var n = random.Next(3, upperLimit);
            var products = new List<Product>();

            for (int i = 0; i < n; ++i)
            {
                products.Add(new Product
                {
                    Name = RandomStr(min: 5, max: 10).ToUpper(),
                    Description = RandomStr(min: 25, max: 50, spaces: true),
                    Guid = Guid.NewGuid(),
                    ImageURL = "TODO"
                });
            }

            return products;
        }

        internal static IEnumerable<Model.Model> GenerateModelsFor(Product product)
        {
            var colors = new List<string>
            {
                "white", "gray", "black", "red", "blue", "green", "magenta", "purple"
            };

            var prices = new List<double> { 1.01, 4.98, 19.20, 100.00, 40.45, 9.99, 10000, 555, 6.78 };

            var n = random.Next(1, 5);

            var models = new List<Model.Model>();

            for (int i = 0; i < n; ++i)
            {
                models.Add(new Model.Model
                { 
                    Color = colors[random.Next(0, colors.Count)],
                    Description = RandomStr(min: 10, max: 25, spaces: true),
                    InStock = random.Next(1, 5),
                    Price = new decimal(prices[random.Next(0, prices.Count)]),
                    ProductId = product.Id
                });
            }

            return models;
        }

        internal static IEnumerable<Model.Model> GenerateModels(IEnumerable<Product> products)
        {
            var models = new List<Model.Model>();
            
            foreach (var product in products)
            {
                models.AddRange(GenerateModelsFor(product));
            }

            return models;
        }
    }
}
