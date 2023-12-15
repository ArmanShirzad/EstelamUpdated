using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EstelamIsargari.Pages
{
    public class ResponsePage : PageModel
    {
        [BindProperty]
        public ResponseModel apiResponse { get; set; }
        public void OnGet()
        {
            var responseDataJson = HttpContext.Session.GetString("ApiResponse");
           apiResponse = JsonSerializer.Deserialize<ResponseModel>(responseDataJson);
                // Display the properties of apiResponse
                
        }
    }
}
