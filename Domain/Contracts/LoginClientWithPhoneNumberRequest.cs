using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    // Данные для входа пользователя
    public record LoginClientWithPhoneNumberRequest
    {
        [Required]
        public string loginMethod { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        [Required]
        [Phone]
        [RegularExpression(@"^(?:\+?7|8)?(?:[\s\-(_]+)?(\d{3})(?:[\s\-_)]+)?(\d{3})(?:[\s\-_]+)?(\d{2})(?:[\s\-_]+)?(\d{2})$")]
        public string phoneNumber { get; set; } = string.Empty;
    }
}
