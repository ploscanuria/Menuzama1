namespace Menuzama1.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending"; // Ex.: Pending, Processed, Completed, Cancelled
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        // Relație cu User
        public virtual User User { get; set; } = default!;
    }
}
