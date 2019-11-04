using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmericaVirtualApi.Models;
using AmericaVirtualApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmericaVirtualApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly LogService _logService;
        private readonly ILogger<AccountController> _logger;

        public AdminController(UserService userService, ILogger<AccountController> logger, LogService logService)
        {
            _userService = userService;
            _logService = logService;
            _logger = logger;
        }

        /// <summary>
        /// Obtener la lista de logs completa.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllLogs")]
        public ActionResult<List<Log>> GetAllLogs()
        {
            try
            {
                return _logService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Obtener todos los log de un usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetLogsByUserId")]
        public ActionResult<List<Log>> GetLogsByUserId(string id)
        {
            try
            {
                return _logService.GetByUserId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Obtener la lista de todos los usuarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllUsers")]
        public ActionResult<List<User>> GetAllUsers()
        {
            try
            {
                return _userService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }
    }
}