﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopPrint_API.Entities.DTOs;
using ShopPrint_API.Services;

namespace ShopPrint_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        public readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            try
            {
                var productId = await _productService.CreateProduct(product);
                return Ok(productId);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductById([FromRoute] string id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }


        [HttpGet]
        [Route("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string id)
        {
            try
            {
                var result = await _productService.DeleteProduct(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [HttpPut]
        [Route("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO product)
        {
            try
            {
                var result = await _productService.UpdateProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [HttpPost]
        [Route("Filter")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FilterProducts([FromBody] FilterDTO filter)
        {
            try
            {
                var result = await _productService.Filter(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            try
            {
                var product = await _productService.GetProductByName(name);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }
    }
}
