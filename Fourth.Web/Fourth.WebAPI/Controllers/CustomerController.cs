using Fourth.ApiServices.Interfaces;
using Fourth.Services.ViewModels.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fourth.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET api/customers
        [HttpGet]
        [Route("api/customers")]
        public IEnumerable<CustomerGridModel> Customers()
        {
            return this.customerService.AllCustomers();
        }

        // GET api/customer/id
        [HttpGet]
        [Route("api/customer/{id}")]
        public CustomerModel Customer(string id)
        {
            return this.customerService.GetCustomerById(id);
        }

        // GET api/customer/id/orders
        [HttpGet]
        [Route("api/customer/{id}/orders")]
        public IEnumerable<OrderModel> CustomerOrders(string id)
        {
            return this.customerService.GetCustomerOrdersByCustomerId(id);
        }
    }
}
