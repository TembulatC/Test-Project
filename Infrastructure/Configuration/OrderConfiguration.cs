using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            // Один ко многим (Один клиент - много заказов)
            builder
                .HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.Client_Id);

            // Один к одному (Один заказ - один набор элементов заказа)
            builder
                .HasOne(o => o.OrderItem)
                .WithOne(oi => oi.Order)
                .HasForeignKey<OrderItem>(oi => oi.Order_Id);
        }
    }
}
