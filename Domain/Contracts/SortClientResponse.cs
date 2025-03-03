using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    // Данные для входа пользователя
    public record SortClientResponse
    {
        [Required]
        public bool sort { get; set; }

        [Required]
        public int page { get; set; }

        [Required]
        public int pageSize { get; set; }
    }
}
