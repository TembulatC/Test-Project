using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public record CreateItemRequest
    {
        [Required]
        public string name { get; set; } = string.Empty;

        [Required]
        public int price { get; set; } = 0;

        [Required]
        public string category { get; set; } = string.Empty;
    }
}
