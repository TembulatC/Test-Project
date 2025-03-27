using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    // Данные для регистрации пользователя
    public record CreateClientWithPhoneNumberRequest
    {
        [Required]
        public string registerMethod { get; set; } = string.Empty;

        [Required]
        public string login { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        [Required]
        [Phone]
        [RegularExpression(@"^(?:\+?7|8)?(?:[\s\-(_]+)?(\d{3})(?:[\s\-_)]+)?(\d{3})(?:[\s\-_]+)?(\d{2})(?:[\s\-_]+)?(\d{2})$")]
        public string phoneNumber { get; set; } = string.Empty;
    }
}