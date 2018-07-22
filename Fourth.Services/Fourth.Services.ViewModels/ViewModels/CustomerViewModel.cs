namespace Fourth.Services.ViewModels.ViewModels
{
    using Fourth.Services.ViewModels.Models;
    using System.Collections.Generic;

    public class CustomerViewModel
    {
        public CustomerModel Customer { get; set; }

        public IList<OrderViewModel> Orders { get; set; }
    }
}
