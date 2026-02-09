using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly FirestoreServices _firestoreServices;

        public ProductsController(FirestoreServices firestoreServices)
        {
            _firestoreServices = new FirestoreServices();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _firestoreServices.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }   
    }
}