using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.Pages
{
    public class ErrorsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ErrorMessage { get; set; }
    }
}