using Microsoft.EntityFrameworkCore;


namespace Domain.Models
{
    // Заказ
    public class Order
    {
        public Order() { }

        public Order(Guid client_Id, DateTime shipment_Date, int order_Number, string status)
        {
            Id = Guid.NewGuid();
            Client_Id = client_Id;
            Order_Date = DateTime.Now;
            Shipment_Date = shipment_Date;
            Order_Number = order_Number;
            Status = status;
        }

        public Guid Id { get; set; }
        public Guid Client_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Shipment_Date { get; set; }
        public int Order_Number { get; set; }
        public string Status { get; set; }
        public Client? Client { get; set; }
        public OrderItem? OrderItem { get; set; }
    }
}
