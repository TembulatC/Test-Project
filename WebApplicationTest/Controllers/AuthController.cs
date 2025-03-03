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
        public async Task<IActionResult> Register([FromBody] CreateClientRequest request) // ������ ������� �� ���� ajax-�������
        {
            // �������� �� ���������� ������
            // ���� ��� ���� �� �������� �������, �� ������ ���������� � ���������
            if (ModelState.IsValid)
            {
                // �������� �� ������� ������������
                var client = await _clientService.FindClientForAuth(request.login, request.password);

                if (client == "ClientNotFound") // ���� ������������ �� ���������� - ������������ ��� � ���������� ������ � ajax
                {
                    await _clientService.AddClient(request.login, request.password, request.city, request.street, request.number);
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
        public async Task<IActionResult> Login([FromBody] LoginClientRequest request) // ������ ������� �� ���� ajax-�������
        {
            // �������� �� ���������� ������
            // ���� ��� ���� �� �������� �������, �� ������ ���������� � ���������
            if (ModelState.IsValid)
            {
                // �������� �� ������� ������������
                var validation = await _clientService.FindClientForAuth(request.login, request.password);

                // ���� ������������ ���� ������������ ������ ��� ��� �� ����������, �� ���������� 400 ��� ������ � ajax
                if (validation == "Error" || validation == "ClientNotFound")
                {
                    return BadRequest();
                }
                // ���� ��� ������ ������� �� ����������� ������ � ajax
                else
                {
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
