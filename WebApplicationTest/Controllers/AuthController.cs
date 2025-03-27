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
        public async Task<IActionResult> RegisterWithEmail([FromBody] CreateClientWithEmailRequest request) // ������ ������� �� ���� ajax-�������
        {
            // �������� �� ���������� ������
            // ���� ��� ���� �� �������� �������, �� ������ ���������� � ���������
            if (ModelState.IsValid)
            {
                // �������� �� ������� ������������
                var client = await _clientService.FindClientForAuth(request.registerMethod, request.email, request.password);

                if (client == "ClientNotFound") // ���� ������������ �� ���������� - ������������ ��� � ���������� ������ � ajax
                {
                    await _clientService.AddClientWithEmail(request.login, request.password, request.email);
                    return Json(request);
                }
                else // � ������ ������ ���������� 409 ��� ������ � ajax �� ���������
                {
                    return Conflict();
                }              
            }
            // ���� ���� ������ ����, �� ���������� 400 ��� ������ � ajax
            else
            {
                return BadRequest();
            }          
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> RegisterWithPhoneNumber([FromBody] CreateClientWithPhoneNumberRequest request) // ������ ������� �� ���� ajax-�������
        {
            // �������� �� ���������� ������
            // ���� ��� ���� �� �������� �������, �� ������ ���������� � ���������
            if (ModelState.IsValid)
            {
                // �������� �� ������� ������������
                var client = await _clientService.FindClientForAuth(request.registerMethod, request.phoneNumber, request.password);

                if (client == "ClientNotFound") // ���� ������������ �� ���������� - ������������ ��� � ���������� ������ � ajax
                {
                    await _clientService.AddClientWithPhoneNumber(request.login, request.password, request.phoneNumber);
                    return Json(request);
                }
                else // � ������ ������ ���������� 409 ��� ������ � ajax �� ���������
                {
                    return Conflict();
                }
            }
            // ���� ���� ������ ����, �� ���������� 400 ��� ������ � ajax
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> LoginWithEmail([FromBody] LoginClientWithEmailRequest request) // ������ ������� �� ���� ajax-�������
        {
            // �������� �� ���������� ������
            // ���� ��� ���� �� �������� �������, �� ������ ���������� � ���������
            if (ModelState.IsValid)
            {
                // �������� �� ������� ������������
                var validation = await _clientService.FindClientForAuth(request.loginMethod, request.email, request.password);

                // ���� ������������ ���� ������������ ������ ��� ��� �� ����������, �� ���������� 400 ��� ������ � ajax
                if (validation == "Error" || validation == "ClientNotFound")
                {
                    return BadRequest();
                }
                // ���� ��� ������ ������� �� ����������� ������ � ajax
                else
                {
                    _httpContext.HttpContext!.Response.Cookies.Append("jwt-token", validation);
                    Console.WriteLine(validation);
                    return Json(request);
                }
            }
            // ���� ���� ������ ����, �� ���������� 400 ��� ������ � ajax
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> LoginWithPhoneNumber([FromBody] LoginClientWithPhoneNumberRequest request) // ������ ������� �� ���� ajax-�������
        {
            // �������� �� ���������� ������
            // ���� ��� ���� �� �������� �������, �� ������ ���������� � ���������
            if (ModelState.IsValid)
            {
                // �������� �� ������� ������������
                var validation = await _clientService.FindClientForAuth(request.loginMethod, request.phoneNumber, request.password);

                // ���� ������������ ���� ������������ ������ ��� ��� �� ����������, �� ���������� 400 ��� ������ � ajax
                if (validation == "Error" || validation == "ClientNotFound")
                {
                    return BadRequest();
                }
                // ���� ��� ������ ������� �� ����������� ������ � ajax
                else
                {
                    _httpContext.HttpContext!.Response.Cookies.Append("jwt-token", validation);
                    Console.WriteLine(validation);
                    return Json(request);
                }
            }
            // ���� ���� ������ ����, �� ���������� 400 ��� ������ � ajax
            else
            {
                return BadRequest();
            }
        }
    }
}
