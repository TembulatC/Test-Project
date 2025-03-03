using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    // Товар
    public class Item
    {
        public Item() { }

        public Item(string code, string name, int price, string category)
        {
            Id = Guid.NewGuid();
            Code = code;
            Name = name;
            Price = price;
            Category = category;
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        [MaxLength(30)]
        public string Category {  get; set; }
        public OrderItem? OrderItem { get; set; }
    }
}
