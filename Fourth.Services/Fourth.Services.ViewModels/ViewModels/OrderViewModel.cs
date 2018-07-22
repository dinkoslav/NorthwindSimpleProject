namespace Fourth.Services.ViewModels.ViewModels
{
    using System;
    using System.ComponentModel;

    public class OrderViewModel
    {
        [DisplayName("Order ID")]
        public int OrderID { get; set; }

        [DisplayName("Total Price")]
        public decimal TotalPrice { get; set; }

        [DisplayName("Product Types")]
        public int TotalProducts { get; set; }

        [DisplayName("Product Quantities")]
        public int TotalQuantities { get; set; }

        [DisplayName("Possible Problem")]
        public bool PossibleProblem { get; set; }
    }
}
