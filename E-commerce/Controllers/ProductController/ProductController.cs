using Dtos.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ProductServices;

namespace E_commerce.Controllers.ProductController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }



        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            var Products = await _ProductService.GetAllAsync();
            if (Products == null)
            {
                return Ok(new List<ProductDTO>());
            }
            return Ok(Products);
        }
        [Authorize(Roles = "Admin")]

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var Product = await _ProductService.GetByIdAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO ProductDTO)
        {
            var createdProduct = await _ProductService.CreateAsync(ProductDTO);

            return Ok(createdProduct);
        }
        [Authorize(Roles = "Admin")]


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDTO ProductDTO)
        {
            var existingDto = await _ProductService.GetByIdAsync(id);
            if (existingDto == null)
            {
                return NotFound();
            }
            await _ProductService.UpdateAsync(ProductDTO);
            return Ok("Updated Successfuly");
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _ProductService.DeleteAsync(id);
            return Ok("Deleted Successfuly");
        }
    }


}

