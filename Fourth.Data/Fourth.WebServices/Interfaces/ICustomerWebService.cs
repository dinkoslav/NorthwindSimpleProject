using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fourth.Services.ViewModels.Models;

namespace Fourth.WebServices.Interfaces
{
    public interface ICustomerWebService
    {
        IList<Fourth.Services.ViewModels.Models.CustomerGridModel> GetAll();

        CustomerModel GetById(string id);

        IList<OrderModel> GetOrdersByCustomerId(string id);
    }
}
