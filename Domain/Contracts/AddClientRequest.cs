using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public record AddClientRequest
    {
        [Required]
        public string login { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [RegularExpression(@"^(?:\+?7|8)?(?:[\s\-(_]+)?(\d{3})(?:[\s\-_)]+)?(\d{3})(?:[\s\-_]+)?(\d{2})(?:[\s\-_]+)?(\d{2})$")]
        public string phoneNumber { get; set; } = string.Empty;
    }
}
