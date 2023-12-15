using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EstelamIsargari.Pages
{
    public class InputModel
    {
        [Microsoft.AspNetCore.Mvc.BindProperty]
        public string? NationalCode { get; set; }
        //public IActionResult OnPost()
        //{
        //    // Process the user's input here
        //    // The entered national code can be accessed using this.NationalCode

        //    // You can perform validation and further processing as needed
        //    return true;
        //}
    }
}
