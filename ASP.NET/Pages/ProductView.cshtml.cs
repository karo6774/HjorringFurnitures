using System;
using ASP.NET.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.Pages
{
    public class ProductViewModel : PageModel
    {
        public Product Product;

        public IActionResult OnGet(string id)
        {
            if (!int.TryParse(id, out var i))
                return Page();

            try
            {
                var products = ProductRepository.GetProductsFromFile();
                Product = products.Find(it => it.Id == i);
            }
            catch (Exception e)
            {
                return RedirectToPage("/Errors", new {errorMessage = e.Message});
            }

            return Page();
        }
    }
}