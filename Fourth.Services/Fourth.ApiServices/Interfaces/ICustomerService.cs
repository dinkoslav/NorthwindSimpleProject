namespace Fourth.ApiServices.Interfaces
{
    using Fourth.Services.ViewModels.Models;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerGridModel> AllCustomers();

        CustomerModel GetCustomerById(string id);

        IEnumerable<OrderModel> GetCustomerOrdersByCustomerId(string id);
    }
}
