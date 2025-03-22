using Domain.Contracts;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using System.Threading.Tasks;

namespace WebApplicationTest.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly ClientService _clientService;
        public readonly ItemService _iItemService;

        public AdminPageController(ClientService clientService, ItemService itemService)
        {
            _clientService = clientService;
            _iItemService = itemService;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> AddClient([FromBody] AddClientRequest request)
        {
            // Проверка на валидность данных
            // Если все поля не являются пустыми, то данные передаются в обработку
            if (ModelState.IsValid)
            {
                // Проверка на наличие пользователя
                var client = await _clientService.FindClientForAuth(request.login, request.password);

                if (client == "ClientNotFound") // Если пользователя не существует - регистриурем его и возвращаем данные в ajax
                {
                    await _clientService.AddClient(request.login, request.password);
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
        public async Task<IActionResult> AddItem([FromBody] CreateItemRequest request)
        {
            if (ModelState.IsValid)
            {
                await _iItemService.AddItem(request.name, request.price, request.category);
                return Json(request);
            }

            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _clientService.GetAll());
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> GetByFilter([FromQuery] FilterResponse response)
        {
            return Json(await _clientService.GetByFilter(response.searchInput, response.filter, response.searchDiscountInput, response.sort, response.page, response.pageSize));
        }

        [HttpDelete]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> DeleteClient([FromBody] DeleteRequest request)
        {
            if (ModelState.IsValid)
            {
                await _clientService.DeleteClient(request.codes);
                return Json(request);
            }

            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> UpdateClient([FromBody] UpdateClientRequest request)
        {
            if (ModelState.IsValid)
            {
                await _clientService.UpdateClient(request.login, request.code, request.password, request.discount);
                return Json(request);
            }

            else
            {
                return BadRequest();
            }
        }
    }
}
