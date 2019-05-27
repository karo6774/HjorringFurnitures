using System;
using System.Collections.Generic;
using ASP.NET.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; private set; }

        public IActionResult OnGet()
        {
            try
            {
                Products = ProductRepository.GetProductsFromFile();
            }
            catch (Exception e)
            {
                return RedirectToPage("/Errors", new {errorMessage = e.Message});
            }
            return Page();
        }
    }
}