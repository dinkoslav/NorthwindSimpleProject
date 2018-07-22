namespace Fourth.Services.ViewModels.ViewModels
{
    using Fourth.Services.ViewModels.Forms;
    using Fourth.Services.ViewModels.Models;
    using System.Collections.Generic;

    public class CustomersViewModel
    {
        public CustomersViewModel()
        {
            this.SearchForm = new CustomerSearchViewModel();
            this.Customers = new List<CustomerGridModel>();
        }

        public CustomerSearchViewModel SearchForm { get; set; }

        public IList<CustomerGridModel> Customers { get; set; }
    }
}
