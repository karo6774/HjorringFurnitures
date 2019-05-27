using System;
using System.Globalization;
using ASP.NET.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.Pages
{
    public class AddProductsModel : PageModel
    {
        public bool PostSuccess = false;

        public IActionResult OnPost(int id, string image, string title, string short_desc, string long_desc,
            string price)
        {
            try
            {
                var p = float.Parse(price, CultureInfo.InvariantCulture);
                
                if (string.IsNullOrWhiteSpace(image))
                    throw new Exception("Billede URL er påkrævet.");
                
                if (string.IsNullOrWhiteSpace(title))
                    throw new Exception("Overskrift er påkrævet.");
                if (title.Length > 20)
                    throw new Exception("Overskrift må højest være 20 tegn langt.");
                
                if (string.IsNullOrWhiteSpace(short_desc))
                    throw new Exception("Kort beskrivelse er påkrævet.");
                if (short_desc.Length > 50)
                    throw new Exception("Kort beskrivelse må højest være 50 tegn langt.");

                if (string.IsNullOrWhiteSpace(long_desc))
                    throw new Exception("Lang beskrivelse er påkrævet.");

                if (p < 0)
                    throw new Exception("Pris må ikke være negativt.");
                
                var product = new Product(id, image, title, short_desc, long_desc, DateTime.Now, p);

                PostSuccess = ProductRepository.SaveProductToFile(product);
            }
            catch (FormatException)
            {
                return RedirectToPage("/Errors", new {errorMessage = "Pris blev givet i et forkert format."});
            }
            catch (Exception e)
            {
                return RedirectToPage("/Errors", new {errorMessage = e.Message});
            }

            if (!PostSuccess)
                return Page();
            return RedirectToPage("/ProductView", new {id});
        }
    }
}