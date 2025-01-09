using Microsoft.AspNetCore.Mvc.Rendering;

namespace Menuzama1.ViewModels
{
    public class OrderFormulareCRUDViewModel
    {
        
            public int OrderID { get; set; }
            public int ClientID { get; set; }
            public int MenuItemId { get; set; }
            public string ClientFullName { get; set; }
            public string MenuItemName { get; set; }
            public string MenuItemDescription { get; set; }
            public decimal MenuItemPrice { get; set; }
            public DateTime OrderDate { get; set; }
        public SelectList Clients { get; set; }
        public SelectList MenuItems { get; set; }
    }

    }

