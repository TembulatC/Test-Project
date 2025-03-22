using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    // Данные для фильтрации пользователей
    public record FilterResponse
    {
        public string searchInput { get; set; } = string.Empty;

        [Required]
        public string filter { get; set; } = string.Empty;

        [Required]
        public string sort { get; set; } = string.Empty;

        public int searchDiscountInput { get; set; } = 0;

        [Required]
        public int page { get; set; } = 1;

        [Required]
        public int pageSize { get; set; } = 25;
    }
}
