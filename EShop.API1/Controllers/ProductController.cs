using EShop.API1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [Authorize(Policy = "ReadProduct")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<Product>()
            {
                new Product { Id = 1, Name = "Kalem", Price = 100, Stock = 100},
                new Product { Id = 2, Name = "Silgi", Price = 200, Stock = 200},
                new Product { Id = 3, Name = "Defter", Price = 300, Stock = 300},
                new Product { Id = 4, Name = "Kitap", Price = 400, Stock = 400},
                new Product { Id = 5, Name = "Bant", Price = 500, Stock = 500},
                new Product { Id = 6, Name = "kaju" , Price = 2500, Stock = 1} 
            };
            return Ok(products);
        }

        [Authorize(Policy = "UpdateOrCreate")]
        [HttpPut]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"idsi {id} olan ürün güncellenmiştir");
        }

        [Authorize(Policy = "UpdateOrCreate")]
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(product);
        }
    }
}
