using System.Diagnostics;
using Domain.Models;
using Domain.Services;
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplicationTest.Controllers
{
    public class AuthController : Controller
    {
        private readonly ClientService _clientService;

        public AuthController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Register([FromBody] CreateClientRequest request) // Данные берутся из тела ajax-запроса
        {
            // Проверка на валидность данных
            // Если все поля не являются пустыми, то данные передаются в обработку
            if (ModelState.IsValid)
            {
                // Проверка на наличие пользователя
                var client = await _clientService.FindClientForAuth(request.login, request.password);

                if (client == "ClientNotFound") // Если пользователя не существует - регистриурем его и возвращаем данные в ajax
                {
                    await _clientService.AddClient(request.login, request.password, request.city, request.street, request.number);
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
        public async Task<IActionResult> Login([FromBody] LoginClientRequest request) // Данные берутся из тела ajax-запроса
        {
            // Проверка на валидность данных
            // Если все поля не являются пустыми, то данные передаются в обработку
            if (ModelState.IsValid)
            {
                // Проверка на наличие пользователя
                var validation = await _clientService.FindClientForAuth(request.login, request.password);

                // Если пользователь ввел неправильный пароль или его не существует, то возвращаем 400 код ошибки в ajax
                if (validation == "Error" || validation == "ClientNotFound")
                {
                    return BadRequest();
                }
                // Если все прошло успешно то обабатываем данные в ajax
                else
                {
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
