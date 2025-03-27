using System.Diagnostics;
using Domain.Models;
using Domain.Services;
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using NuGet.Common;

namespace WebApplicationTest.Controllers
{
    public class AuthController : Controller
    {
        private readonly ClientService _clientService;
        private readonly IHttpContextAccessor _httpContext;

        public AuthController(ClientService clientService, IHttpContextAccessor httpContext)
        {
            _clientService = clientService;
            _httpContext = httpContext;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> RegisterWithEmail([FromBody] CreateClientWithEmailRequest request) // Данные берутся из тела ajax-запроса
        {
            // Проверка на валидность данных
            // Если все поля не являются пустыми, то данные передаются в обработку
            if (ModelState.IsValid)
            {
                // Проверка на наличие пользователя
                var client = await _clientService.FindClientForAuth(request.registerMethod, request.email, request.password);

                if (client == "ClientNotFound") // Если пользователя не существует - регистриурем его и возвращаем данные в ajax
                {
                    await _clientService.AddClientWithEmail(request.login, request.password, request.email);
                    return Json(request);
                }
                else // В другом случае возвращаем 409 код ошибки в ajax на обработку
                {
                    return Conflict();
                }              
            }
            // Если есть пустое поле, то возвращаем 400 код ошибки в ajax
            else
            {
                return BadRequest();
            }          
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> RegisterWithPhoneNumber([FromBody] CreateClientWithPhoneNumberRequest request) // Данные берутся из тела ajax-запроса
        {
            // Проверка на валидность данных
            // Если все поля не являются пустыми, то данные передаются в обработку
            if (ModelState.IsValid)
            {
                // Проверка на наличие пользователя
                var client = await _clientService.FindClientForAuth(request.registerMethod, request.phoneNumber, request.password);

                if (client == "ClientNotFound") // Если пользователя не существует - регистриурем его и возвращаем данные в ajax
                {
                    await _clientService.AddClientWithPhoneNumber(request.login, request.password, request.phoneNumber);
                    return Json(request);
                }
                else // В другом случае возвращаем 409 код ошибки в ajax на обработку
                {
                    return Conflict();
                }
            }
            // Если есть пустое поле, то возвращаем 400 код ошибки в ajax
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> LoginWithEmail([FromBody] LoginClientWithEmailRequest request) // Данные берутся из тела ajax-запроса
        {
            // Проверка на валидность данных
            // Если все поля не являются пустыми, то данные передаются в обработку
            if (ModelState.IsValid)
            {
                // Проверка на наличие пользователя
                var validation = await _clientService.FindClientForAuth(request.loginMethod, request.email, request.password);

                // Если пользователь ввел неправильный пароль или его не существует, то возвращаем 400 код ошибки в ajax
                if (validation == "Error" || validation == "ClientNotFound")
                {
                    return BadRequest();
                }
                // Если все прошло успешно то обабатываем данные в ajax
                else
                {
                    _httpContext.HttpContext!.Response.Cookies.Append("jwt-token", validation);
                    Console.WriteLine(validation);
                    return Json(request);
                }
            }
            // Если есть пустое поле, то возвращаем 400 код ошибки в ajax
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> LoginWithPhoneNumber([FromBody] LoginClientWithPhoneNumberRequest request) // Данные берутся из тела ajax-запроса
        {
            // Проверка на валидность данных
            // Если все поля не являются пустыми, то данные передаются в обработку
            if (ModelState.IsValid)
            {
                // Проверка на наличие пользователя
                var validation = await _clientService.FindClientForAuth(request.loginMethod, request.phoneNumber, request.password);

                // Если пользователь ввел неправильный пароль или его не существует, то возвращаем 400 код ошибки в ajax
                if (validation == "Error" || validation == "ClientNotFound")
                {
                    return BadRequest();
                }
                // Если все прошло успешно то обабатываем данные в ajax
                else
                {
                    _httpContext.HttpContext!.Response.Cookies.Append("jwt-token", validation);
                    Console.WriteLine(validation);
                    return Json(request);
                }
            }
            // Если есть пустое поле, то возвращаем 400 код ошибки в ajax
            else
            {
                return BadRequest();
            }
        }
    }
}
