using System;
using System.Globalization;

namespace ASP.NET.Logic
{
    public class Product
    {
        public int Id;
        public string ImageUrl;
        public string Title;
        public string ShortDescription;
        public string LongDescription;
        public DateTime Created;
        public float Price;

        public Product(int id, string imageUrl, string title, string shortDescription, string longDescription,
            DateTime created, float price)
        {
            Id = id;
            ImageUrl = imageUrl;
            Title = title;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            Created = created;
            Price = price;
        }

        public static Product ParseCsv(string value)
        {
            var parts = value.Split(',');
            return new Product(
                int.Parse(parts[0]),
                parts[1],
                CsvDecode(parts[2]),
                CsvDecode(parts[3]),
                CsvDecode(parts[4]),
                DateTime.FromBinary(long.Parse(parts[5])),
                float.Parse(parts[6], CultureInfo.InvariantCulture)
            );
        }

        public string GetCsvString()
        {
            var values = new[]
            {
                Id.ToString(),
                ImageUrl,
                CsvEncode(Title),
                CsvEncode(ShortDescription),
                CsvEncode(LongDescription),
                Created.ToBinary().ToString(),
                Price.ToString("#0.00", CultureInfo.InvariantCulture)
            };
            return string.Join(',', values);
        }

        private static string CsvEncode(string value) =>
            value.Replace(",", "%2C");


        private static string CsvDecode(string value) =>
            value.Replace("%2C", ",");
    }
}