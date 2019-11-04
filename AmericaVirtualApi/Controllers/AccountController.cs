using System;
using AmericaVirtualApi.Models;
using AmericaVirtualApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmericaVirtualApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly LogService _logService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserService userService, ILogger<AccountController> logger, LogService logService)
        {
            _userService = userService;
            _logService = logService;
            _logger = logger;
        }

        /// <summary>
        /// Validar y obtener datos del usuario mediante email y contraseña.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password">Encoded SHA1</param>
        /// <returns>Usuario completo o NotFound</returns>
        [HttpGet(Name = "LogIn")]
        public ActionResult<User> LogIn(string email, string password)
        {
            try
            {
                User user = _userService.Validate(email, password);

                if (user == null)
                {
                    return NotFound("Usuario no encontrado.");
                }

                //Log de log in
                _logService.Create(new Log { UserId = user.Id, TimeStamp = DateTime.Now, Action = "Inicio de Sesion." });

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.ToString());
            }

        }

        [HttpGet(Name = "LogOut")]
        public IActionResult LogOut(string id)
        {
            //Log de log Out
            _logService.Create(new Log { UserId = id, TimeStamp = DateTime.Now, Action = "Cierre de Sesion." });
            return Ok();
        }

        /// <summary>
        /// Crear un nuevo Usuario.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<User> Create(NewUser newUser)
        {
            try
            {
                User user = CreateUser(newUser);

                _userService.Create(user);

                return CreatedAtRoute("logIn", new { Email = user.Email, Password = user.Password }, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }

        private User CreateUser(NewUser newUser)
        {
            User user = null;

            try
            {
                user = new User
                {
                    Id = string.Empty,
                    Image = newUser.Image,
                    Birthday = newUser.Birthday,
                    Email = newUser.Email,
                    FullName = newUser.FullName,
                    isAdmin = newUser.isAdmin,
                    Password = newUser.Password
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return user;
        }
    }
}