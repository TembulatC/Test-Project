using Domain.Contracts;
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

        public ClientService(IClientRepository clientRepository, IHasherRepository hasherRepository, IJWTProviderRepository jwtProviderRepository)
        {
            _clientRepository = clientRepository;
            _hasherRepository = hasherRepository;
            _jwtProviderRepository = jwtProviderRepository;
        }

        public async Task AddClientWithEmail(string login, string password, string email)
        {
            // Создается код клиента
            string time = DateTime.Now.ToString("MMddhhmmss");
            string time2 = DateTime.Now.ToString("fffffff");
            string code = $"{time}-{time2}";

            // Пароль хэшируется и передается в метод addClient
            string hashedPassword = _hasherRepository.Generate(password);

            await _clientRepository.AddClient(login, hashedPassword, code, email, "");
        }

        public async Task AddClientWithPhoneNumber(string login, string password, string phoneNumber)
        {
            // Создается код клиента
            string time = DateTime.Now.ToString("MMddhhmmss");
            string time2 = DateTime.Now.ToString("fffffff");
            string code = $"{time}-{time2}";

            // Пароль хэшируется и передается в метод addClient
            string hashedPassword = _hasherRepository.Generate(password);

            await _clientRepository.AddClient(login, hashedPassword, code, "", phoneNumber);
        }

        public async Task AddClient(string login, string password)
        {
            // Создается код клиента
            string time = DateTime.Now.ToString("MMddHHmmss");
            string time2 = DateTime.Now.ToString("fffffff"); 
            string code = $"{time}-{time2}";

            // Пароль хэшируется и передается в метод addClient
            string hashedPassword = _hasherRepository.Generate(password);

            await _clientRepository.AddClient(login, hashedPassword, code, "", "");
        }

        public async Task<string> FindClientForAuth(string findData, string data, string password)
        {
            var client = await _clientRepository.FindClientForAuth(findData, data);

            // Если такого пользователя нет, то возвращаем ошибку
            if (client == null)
            {
                return "ClientNotFound";
            }

            // Если пользовтаель есть идет расхэширование его пароля
            else
            {
                string validate;
                var hashedPassword = _hasherRepository.Verify(password, client.Password);
                Console.WriteLine(client.Password);

                switch(hashedPassword)
                {
                    case false:
                        validate = "Error";
                        break;

                    case true:
                        var token = _jwtProviderRepository.GenerateToken(client);
                        validate = token;
                        break;
                }

                return validate;
            }
        }

        public async Task<string> FindClientForRegister(string findData, string data, string password)
        {
            var client = await _clientRepository.FindClientForAuth(findData, data);

            // Если такого пользователя нет, то создается новый(используется для регистрации пользователя)
            if (client == null)
            {
                return "ClientNotFound";
            }

            // Если пользовтаель есть
            else
            {
                return "ClientFound";
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

        public async Task DeleteClient(List<Codes> code)
        {
            foreach (Codes codes in code)
            {
                await _clientRepository.DeleteClient(codes.code);
            }                    
        }

        public async Task UpdateClient(string login, string code, string password, int discount)
        {
            string hashedPassword = _hasherRepository.Generate(password);
            await _clientRepository.UpdateClient(login, code, hashedPassword, discount);
        }
    }
}
