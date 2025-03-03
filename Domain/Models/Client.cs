using Microsoft.EntityFrameworkCore;


namespace Domain.Models
{
    // Заказчики
    public class Client
    {
        public Client() { }

        public Client(string name, string password, string code, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
            Code = code;
            Address = address;
            Discount = 0;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }
        public List<Order> Orders { get; set; } = [];
    }
}
