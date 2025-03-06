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
    public record FilterResponse
    {
        public string searchInput { get; set; } = string.Empty;
        public string filter { get; set; } = string.Empty;
        public string sort { get; set; } = string.Empty;
        public int searchDiscountInput { get; set; } = 0;
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 25;
    }
}
