namespace Menuzama1.Models
{
    public class OrderItem
    {
        public int ID{ get; set; }
        public int OrderID { get; set; }
        public int MenuItemID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // Relații
        public virtual Order Order { get; set; } = default!;
        public virtual MenuItem MenuItem { get; set; } = default!;
    }
}
