using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    // Данные для входа пользователя
    public record DeleteRequest
    {
        public List<Codes> codes { get; set; } = [];
    }

    public record Codes
    {
        public string code { get; set; } = string.Empty;
    }
}
