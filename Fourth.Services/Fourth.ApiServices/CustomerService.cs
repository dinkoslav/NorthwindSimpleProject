namespace Fourth.ApiServices
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Fourth.ApiServices.Interfaces;
    using Data.DataHandlers.Interfaces;
    using Services.ViewModels.Models;
    using Database;

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDataHandler customerDataHandler;
        private readonly IMapperService mapperService;

        public CustomerService(ICustomerDataHandler customerDataHandler, IMapperService mapperService)
        {
            this.customerDataHandler = customerDataHandler;
            this.mapperService = mapperService;
        }

        public IEnumerable<CustomerGridModel> AllCustomers()
        {
            try
            {
                IList<Customer> customers = this.customerDataHandler.All().ToList();
                IList<CustomerGridModel> customerGridModels = this.mapperService.Map<IList<Customer>, IList<CustomerGridModel>>(customers);

                return customerGridModels;
            }
            catch (Exception)
            {
                throw new ApplicationException("Something went wrong, please try again later.");
            }
        }

        public CustomerModel GetCustomerById(string id)
        {
            try
            {
                Customer customer = this.customerDataHandler.GetByID(id);
                CustomerModel customerModel = this.mapperService.Map<Customer, CustomerModel>(customer);

                return customerModel;
            }
            catch (Exception)
            {
                throw new ApplicationException("Something went wrong, please try again later.");
            }
        }

        public IEnumerable<OrderModel> GetCustomerOrdersByCustomerId(string id)
        {
            try
            {
                Customer customer = this.customerDataHandler.GetByID(id);
                IList<OrderModel> orderModels = this.mapperService.Map<IList<Order>, IList<OrderModel>>(customer.Orders.ToList());

                return orderModels;
            }
            catch (Exception)
            {
                throw new ApplicationException("Something went wrong, please try again later.");
            }
        }
    }
}
