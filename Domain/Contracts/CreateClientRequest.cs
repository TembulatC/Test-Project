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
    public record CreateClientRequest
    {
        [Required]
        public string login { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        [Required]
        public string city { get; set; } = string.Empty;

        [Required]
        public string street { get; set; } = string.Empty;

        [Required]
        public string number { get; set; } = string.Empty;

        [Required]
        public string email {  get; set; } = string.Empty;

        [Required]
        public string phoneNumber { get; set; } = string.Empty;
    }
}