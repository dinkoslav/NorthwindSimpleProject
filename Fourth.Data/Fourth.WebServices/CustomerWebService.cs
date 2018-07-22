using Fourth.Services.ViewModels.Models;
using Fourth.WebServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourth.WebServices
{
    public class CustomerWebService : ICustomerWebService
    {
        private const string fourthWebApiUrl = "http://localhost:60308/";

        private const string customersUrl = "{0}api/customers";
        private const string customerByIdUrl = "{0}api/customer/{1}";
        private const string customerOrdersByIdUrl = "{0}api/customer/{1}/orders";

        private readonly IHttpRequestService httpRequestService;

        public CustomerWebService(IHttpRequestService httpRequestService)
        {
            this.httpRequestService = httpRequestService;
        }

        public IList<CustomerGridModel> GetAll()
        {
            string requestUrl = string.Format(customersUrl, fourthWebApiUrl);
            IList<CustomerGridModel> customers = this.httpRequestService.Get<IList<CustomerGridModel>>(requestUrl);

            return customers;
        }

        public CustomerModel GetById(string id)
        {
            string requestUrl = string.Format(customerByIdUrl, fourthWebApiUrl, id);
            CustomerModel customer = this.httpRequestService.Get<CustomerModel>(requestUrl);

            return customer;
        }

        public IList<OrderModel> GetOrdersByCustomerId(string id)
        {
            string requestUrl = string.Format(customerOrdersByIdUrl, fourthWebApiUrl, id);
            IList<OrderModel> orders = this.httpRequestService.Get<IList<OrderModel>>(requestUrl);

            return orders;
        }
    }
}
