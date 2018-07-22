namespace Fourth.Services.Interfaces
{
    using System.Collections.Generic;
    using ViewModels.Models;
    using Fourth.Services.ViewModels.ViewModels;

    public interface ICustomerMVCService
    {
        CustomersViewModel GetCustomers();

        CustomerViewModel GetCustomer(string id);

        IList<CustomerGridModel> GetCustomersByName(string name);
    }
}
