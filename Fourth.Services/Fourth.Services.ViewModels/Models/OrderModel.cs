namespace Fourth.Services.ViewModels.Models
{
    using System;
    using System.Collections.Generic;

    public class OrderModel
    {
        public int OrderID { get; set; }

        public IList<OrderProductModel> Products { get; set; }
    }
}
