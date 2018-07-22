namespace Fourth.Services.ViewModels.Models
{
    using System;

    public class OrderProductModel
    {
        public string ProductName { get; set; }

        public decimal OrderUnitPrice { get; set; }

        public short OrderQuantity { get; set; }

        public float OrderUnitDiscount { get; set; }

        public bool Discontinued { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }
    }
}
