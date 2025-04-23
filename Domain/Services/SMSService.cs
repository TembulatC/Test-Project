using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class SMSService
    {
        public async Task<int> SendSMSPhone(string phoneNumber)
        {
            Random random = new Random();
            int randomCode = random.Next(100000, 999999);

            string parseNumber = Regex.Replace(phoneNumber, @"[^\d]", "");

            string send = $"Ваш код авторизации {randomCode}";
            string to =  $"{parseNumber}";
            string _from = "INFORM";
            string apikey = "VG3O895W0ZUWCP04IC7Y9IY627521TB121005WK801ZU4UZ7U65B54A603YP37R1";
            string url = "http://smspilot.ru/api.php" +
                "?send=" + Uri.EscapeDataString(send) +
                "&to=" + to +
                "&from=" + _from +
                "&apikey=" + apikey;

            HttpClient client = new HttpClient();
            await client.GetAsync(url);

            return randomCode;
        }
    }
}
