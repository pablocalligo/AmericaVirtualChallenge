using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmericaVirtualApi.Contracts;
using AmericaVirtualApi.Models;
using AmericaVirtualApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmericaVirtualApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Obtener todos los productos Paginados.
        /// </summary>
        /// <returns>Objeto JSON</returns>
        [HttpGet]
        public ActionResult<PaginatedProducts> Get()
        {
            PaginatedProducts products = null;

            try
            {
                products = _productService.GetPaginated();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return products;
        }

        /// <summary>
        /// Obtener un Producto por ID.
        /// </summary>
        /// <param name="id">ID del producto (24 caracteres)</param>
        /// <returns></returns>
        [HttpGet("{id:length(24)}", Name = "GetProductById")]
        public ActionResult<Product> Get(string id)
        {
            Product product = null;

            try
            {
                product = _productService.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Crear un nuevo producto.
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Product> Create(NewProduct newProduct)
        {
            try
            {
                Product product = CreateProduct(newProduct);

                _productService.Create(product);
                return CreatedAtRoute("GetProductById", new { id = product.Id.ToString() }, product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Actualizar un producto por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productIn"></param>
        /// <returns></returns>
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, NewProduct productIn)
        {
            try
            {
                Product product = _productService.Get(id);

                if (product == null)
                {
                    return NotFound();
                }

                _productService.Update(id, CreateProduct(productIn));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Ok();
        }

        /// <summary>
        /// Borrar un producto por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            try
            {
                Product product = _productService.Get(id);
                
                if (product == null)
                {
                    return NotFound();
                }
                
                _productService.Remove(product.Id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }


            return NoContent();
        }

        private Product CreateProduct(NewProduct newProduct)
        {
            Product product = null;

            try
            {
                product = new Product
                {
                    Id = string.Empty,
                    Name = newProduct.Name,
                    Description = newProduct.Description,
                    Image = newProduct.Description,
                    Price = newProduct.Price
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return product;
        }
    }
}