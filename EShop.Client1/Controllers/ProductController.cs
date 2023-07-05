using EShop.Client1.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShop.Client1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();

            HttpClient httpClient = new HttpClient();

            var discoveryEndpoint = await httpClient.GetDiscoveryDocumentAsync("https://localhost:7294");

            if (discoveryEndpoint.IsError)
            {
                //logging
            }

            var token = await httpClient.RequestClientCredentialsTokenAsync(

                     new ClientCredentialsTokenRequest()
                     {
                         ClientId = _configuration["Client:ClientId"],
                         ClientSecret = _configuration["Client:ClientSecret"],
                         Address = discoveryEndpoint.TokenEndpoint
                     }
                  );

            if (token.IsError)
            {
                //logging
            }

            httpClient.SetBearerToken(token.AccessToken);

            var response = await httpClient.GetAsync("https://localhost:7266/api/product/getproducts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                products = JsonConvert.DeserializeObject<List<ProductViewModel>>(content);
            }

            else
            {
                //logging
            }

            return View(products);
        }
    }
}
