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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            // Один к одному (Один заказ - один набор элементов заказа)
            builder
                .HasOne(oi => oi.Order)
                .WithOne(o => o.OrderItem)
                .HasForeignKey<OrderItem>(o => o.Order_Id);

            // Один к одному (Один товар - один набор элементов заказа)
            builder
                .HasOne(oi => oi.Item)
                .WithOne(i => i.OrderItem)
                .HasForeignKey<OrderItem>(i => i.Item_Id);
        }
    }
}
