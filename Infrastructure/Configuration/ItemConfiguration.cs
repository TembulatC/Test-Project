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
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);

            // Один к одному (Один товар - один набор элементов Заказа)
            builder
                .HasOne(i => i.OrderItem)
                .WithOne(oi => oi.Item)
                .HasForeignKey<OrderItem>(oi => oi.Item_Id);
        }
    }
}
