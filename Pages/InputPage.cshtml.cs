using EstelamIsargari.TestingUtilities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;

namespace EstelamIsargari.Pages
{
        public class InputPage : PageModel
        {
            private readonly IHttpClientFactory _clientFactory;
        
            [BindProperty]
            public InputModel ApiRequest { get; set; }
            public ResponseModel ApiResponse { get; set; }

            public void OnGet()
            {
                // Initialize the input model or perform any other setup needed on page load.
                ApiRequest = new InputModel();
            }
            public async Task<IActionResult> OnPostAsync()
            {
           
                ApiRequest.NationalCode = Request.Form["nationalCode"];
                // Make an API request and process the response
                ApiResponse = await CallApiAndProcessResponseAsync(ApiRequest);
            
                //if (ApiResponse == null || ApiResponse.IsError)
                //{
                    // If ApiResponse is null o r an error occurred, generate mock data
                    var mockDataGenerator = new MockDataGenerator();
                    ApiResponse = mockDataGenerator.GenerateMockResponse();
                //}
                ApiResponse.ApplicantId = long.Parse(ApiRequest.NationalCode);
                //using session instead of tempdata to ensure no exception occures on page referesh
                HttpContext.Session.SetString("ApiResponse", JsonSerializer.Serialize(ApiResponse));

                //important use of temp data 
               // TempData["ApiResponse"] = JsonSerializer.Serialize(ApiResponse);


                return RedirectToPage("ResponsePage");
            }

            private async Task<ResponseModel> CallApiAndProcessResponseAsync(InputModel requestData)
            {
                // Make an API request using HttpClient and process the response
                // Filter the response data and return a model with true and non-null fields
                // Handle errors and exceptions as needed
                    try
                    {
                        var client = _clientFactory.CreateClient();
                        var response = await client.GetAsync($"your-api-url/{requestData.NationalCode}");
                        if (response.IsSuccessStatusCode)
                        {
                            var apiResponse = await response.Content.ReadFromJsonAsync<ResponseModel>();
                            // Filter the data here
                    
                            var responseModel = new ResponseModel() {

                                ErrorMessage = apiResponse.ErrorMessage, // Set this based on your error handling logic
                                ApplicantId = apiResponse.ApplicantId,
                                Isargar = apiResponse.Isargar,
                                IsShd = apiResponse.IsShd,
                                IsJbz = apiResponse.IsJbz,
                                IsAzd = apiResponse.IsAzd,
                                IsMfq = apiResponse.IsMfq,
                                IsAsr = apiResponse.IsAsr,
                                ShdDate = apiResponse.ShdDate,
                                JbzPercent = apiResponse.JbzPercent,
                                CaptivityDuration = apiResponse.CaptivityDuration,
                                Childs = apiResponse.Childs,
                                Parents = apiResponse.Parents,
                                IsError = apiResponse.IsError,
                                ErrorCode = apiResponse.ErrorCode
                            };
                            // Handle Childs and Parents lists
                            responseModel.Childs = apiResponse.Childs != null
                                ? apiResponse.Childs.Select(child => new PersonBrDTO
                                {
                                    NationalCode = child.NationalCode,
                                    FirstName = child.FirstName,
                                    LastName = child.LastName,
                                    // Map other properties as needed
                                }).ToList()
                                : new List<PersonBrDTO>();

                            responseModel.Parents = apiResponse.Parents != null
                                ? apiResponse.Parents.Select(parent => new PersonBrDTO
                                {
                                    FirstName = parent.FirstName,
                                    LastName = parent.LastName,
                                    Gender = parent.Gender,
                                    IsLiving =parent.IsLiving,
                                    BirthDate = parent.BirthDate,
                                    DeathDate = parent.DeathDate,
                                    FatherName = parent.FatherName,
                                    IdCardNumber = parent.IdCardNumber,
                                    IsRelationshipNatural = parent.IsRelationshipNatural,
                                    Stateld = parent.Stateld,
                                    StateTitle = parent.StateTitle,
                                    NationalCode = parent.NationalCode,
                                    RelationshipTypeId =parent.RelationshipTypeId
                                }).ToList() : new List<PersonBrDTO>();


                     



                            //responseModel.Parents = apiResponse.Parents != null
                            //    ? apiResponse.Parents.Select(parent => new PersonBrDTO
                            //    {
                            //        NationalCode = parent.NationalCode,
                            //        FirstName = parent.FirstName,
                            //        LastName = parent.LastName,
                            //// Map other properties as needed
                            //    }).ToList()
                            //    : new List<PersonBrDTO>();

                            return responseModel;
                        }
                    else
                    {
                        // Handle API request failure
                        return new ResponseModel { ErrorMessage = "unsuccessful" };
                    }
                    }
                    catch (Exception ex)
                    {

                        return new ResponseModel();
                    }


        }
    }
}

    //#region SIMPLIFIED CODE 
    //public string Code { get; set; }
    //public FirstPageModel ApiResponse { get; set; }

    //public async Task<IActionResult> OnPostAsync()
    //{
    //    // Get user-entered code from the form
    //    Code = Request.Form["code"];

    //    // Make an API request and process the response
    //    ApiResponse = await CallApiAndProcessResponseAsync(Code);

    //    return Page();
    //}

    //private async Task<FirstPageModel> CallApiAndProcessResponseAsync(string code)
    //{
    //    // Make an API request using HttpClient and process the response
    //    // Filter the response data and return a model with true and non-null fields
    //    // Handle errors and exceptions as needed

    //    // Example:
    //    var response = await httpClient.GetAsync($"your-api-url/{code}");
    //    if (response.IsSuccessStatusCode)
    //    {
    //        var apiResponse = await response.Content.ReadAsAsync<FirstPageModel>();
    //        // Filter the data here
    //        return apiResponse.FilteredData();
    //    }
    //    else
    //    {
    //        // Handle API request failure
    //        return new FirstPageModel { ErrorMessage = "API request failed." };
    //    }
    //}
    //#endregion
