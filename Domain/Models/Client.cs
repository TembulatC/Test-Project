using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    // Заказчики
    public class Client
    {
        public Client() { }

        public Client(string name, string password, string code, string address, string email, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
            Code = code;
            Address = address;
            Discount = 0;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; } = [];
    }
}
