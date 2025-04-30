using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Dtos;
using MVC.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using MVC.Models;
namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly TokenProviderService _tokenProviderService;

        public ProductController(ProductService productService,TokenProviderService tokenProviderService)
        {
            _productService = productService;
            _tokenProviderService = tokenProviderService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetAllAsync<APIResponse>();
            List<Product> productList = new List<Product>();
            if (response != null)
            {
                productList = JsonConvert.DeserializeObject<List<Product>>(Convert.ToString(response.Data));
            }
            return View(productList);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            var response = await _productService.CreateAsync<APIResponse>(dto);
            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("CustomError", response.Errors.FirstOrDefault());
                return View(dto);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _productService.GetAsync<APIResponse>(id);
            ProductDto product = new();
            if (response != null)
            {
                product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Data));
            }
            if (product == null)
            {
                return NotFound();
            }
            TempData["id"] = id;
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto dto)
        {
            var response = await _productService.UpdateAsync<APIResponse>(id, dto);
            if (response != null)
            {
                TempData["success"] = "Product Updated successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("CustomError", response.Errors.FirstOrDefault());
                TempData["error"] = "Error encountered.";
                return View(dto);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.GetAsync<APIResponse>(id);
            Product product = new();
            if (response != null)
            {
                product = JsonConvert.DeserializeObject<Product>(Convert.ToString(response.Data));
            }
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Delete(Product dto)
        {
            var response = await _productService.DeleteAsync<APIResponse>(dto.Id);
            if (response != null)
            {
                TempData["success"] = "Product Deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("CustomError", response.Errors.FirstOrDefault());
                TempData["error"] = "Error encountered.";
                return View(dto);
            }



        }
    }
}
