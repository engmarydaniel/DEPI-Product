using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Contracts;
using ServicesLayer.DTOs.ProductDto;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _productService;
        private readonly IUnitofwork _unitofWork;
        public ProductsController(IProductsServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_productService.Get_All());
        }
        [HttpPost]

        public async Task<IActionResult> Post(ProductInsertDto product)
        {
            await _productService.InsertProductAsync(product);
            
            await _unitofWork.SaveAsync();
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(ProductUpdateDto product)
        {
            var result = _productService.UpdateProduct(product);
            if (!result)
                return NotFound("Product not found or update failed.");
            return Ok("Product updated successfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (!result)
                return NotFound("Product not found or deleted failed.");
            return Ok("Product deleted successfully.");
        }
    }
}
