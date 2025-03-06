using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    // Слой бизнес логики
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IHasherRepository _hasherRepository;
        private readonly IJWTProviderRepository _jwtProviderRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public ClientService(IClientRepository clientRepository, IHasherRepository hasherRepository, IJWTProviderRepository jwtProviderRepository, IHttpContextAccessor httpContextAccessor)
        {
            _clientRepository = clientRepository;
            _hasherRepository = hasherRepository;
            _jwtProviderRepository = jwtProviderRepository;
            _contextAccessor = httpContextAccessor;
        }

        public async Task AddClient(string login, string password, string city, string street, string number)
        {
            // Создается код клиента
            string time = DateTime.Now.ToString("MMddhhmmss");
            string time2 = DateTime.Now.ToString("fffffff");
            string code = $"{time}-{time2}";

            // Пароль хэшируется и передается в метод addClient
            string hashedPassword = _hasherRepository.Generate(password);

            await _clientRepository.AddClient(login, hashedPassword, code, $"город {city}, улица {street}, дом {number}");
        }

        public async Task AddClient(string login, string password)
        {
            // Создается код клиента
            string year = DateTime.Now.ToString("yyyy");
            string time = DateTime.Now.ToString("MMddHHmmss");
            string time2 = DateTime.Now.ToString("fffffff"); 
            string code = $"{time}-{time2}-{year}";

            // Пароль хэшируется и передается в метод addClient
            string hashedPassword = _hasherRepository.Generate(password);

            await _clientRepository.AddClient(login, hashedPassword, code, "");
        }

        public async Task<string> FindClientForAuth(string login, string password)
        {
            var client = await _clientRepository.FindClientForAuth(login);

            // Если такого пользователя нет, то создается новый(используется для регистрации пользователя)
            if (client == null)
            {
                return "ClientNotFound";
            }

            // Если пользовтаель есть идет расхэширование его пароля
            else
            {
                string validate;
                var hashedPassword = _hasherRepository.Verify(password, client.Password); // Расхэширование происходит путем вырезания строки с паролем из колонки Name
                Console.WriteLine(client.Password);

                if (hashedPassword == false)
                {
                    validate = "Error";
                }

                // Если расхэшированный пароль является верным, то создается Jwt токен содержащий id клиента и отправляется в куки
                else
                {
                    var token = _jwtProviderRepository.GenerateToken(client);
                    _contextAccessor.HttpContext.Response.Cookies.Append("jwt-token", token);
                    validate = token;
                }

                return validate;
            }

        }

        public async Task<List<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }

        public async Task<List<Client>> GetByFilter(string searchInput, string filter, int searchDiscountInput, string sort, int page, int pageSize)
        {
            return await _clientRepository.GetByFilter(searchInput, filter, searchDiscountInput, sort, page, pageSize);
        }

        // Добавить метод поиска клиента без создания токена после исполнения
    }
}
