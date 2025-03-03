using Microsoft.EntityFrameworkCore;


namespace Domain.Models
{
    // Элемент заказа
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(Guid order_id, Guid item_Id, int item_count, int item_price)
        {
            Id = Guid.NewGuid();
            Order_Id = order_id;
            Item_Id = item_Id;
            Item_Count = item_count;
            Item_Price = item_price;
        }

        public Guid Id { get; set; }
        public Guid Order_Id { get; set; }
        public Guid Item_Id { get; set; }
        public int Item_Count { get; set; }
        public int Item_Price { get; set; }
        public Order? Order { get; set; }
        public Item? Item { get; set; }
    }
}
