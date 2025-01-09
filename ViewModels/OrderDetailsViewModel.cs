namespace Menuzama1.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public string ClientFullName { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public decimal MenuItemPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
