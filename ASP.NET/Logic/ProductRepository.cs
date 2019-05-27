using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASP.NET.Logic
{
    public static class ProductRepository
    {
        private const string FilePath = "products.csv";

        public static List<Product> GetProductsFromFile()
        {
            if (!File.Exists(FilePath))
                return new List<Product>();

            var lines = File.ReadLines(FilePath);
            return lines.Select(Product.ParseCsv).ToList();
        }

        public static bool SaveProductToFile(Product product)
        {
            var products = GetProductsFromFile();
            if (products.Any(it => it.Id == product.Id))
                return false;
            
            File.AppendAllLines(FilePath, new[] {product.GetCsvString()});
            return true;
        }
    }
}