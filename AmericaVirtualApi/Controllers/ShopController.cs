using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmericaVirtualApi.Models;
using AmericaVirtualApi.Models;
using AmericaVirtualApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmericaVirtualApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> _logger;
        private readonly LogService _logService;


        public ShopController(LogService logService, ILogger<ShopController> logger)
        {
            _logger = logger;
            _logService = logService;
        }

        /// <summary>
        /// Comprar un producto.
        /// </summary>
        /// <param name="purchase">Objeto que contiene datos del usuario y del producto</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Purchase(PurchaseProduct purchase)
        {
            try
            {
                //Acá iría toda la logica de la compra del producto.
                //Como pago y envio de mail.

                //Logueo la compra.
                _logService.Create(new Log { UserId = purchase.User.Id, TimeStamp = DateTime.Now, Action = $"Compra del producto {purchase.Product.Id}" });
                return Ok("Producto comprado.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }
    }
}