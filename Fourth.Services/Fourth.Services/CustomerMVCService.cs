namespace Fourth.Services
{
    using System.Linq;
    using Fourth.Services.Interfaces;
    using System.Collections.Generic;
    using Fourth.Services.ViewModels.ViewModels;
    using Fourth.Services.ViewModels.Models;
    using Fourth.Services.ViewModels.Forms;
    using System;
    using WebServices.Interfaces;

    public class CustomerMVCService : ICustomerMVCService
    {
        private readonly ICustomerWebService customerWebService;

        public CustomerMVCService(ICustomerWebService customerWebService)
        {
            this.customerWebService = customerWebService;
        }

        public CustomersViewModel GetCustomers()
        {
            IList<CustomerGridModel> customers = this.customerWebService.GetAll();
            CustomersViewModel viewModel = new CustomersViewModel
            {
                SearchForm = new CustomerSearchViewModel(),
                Customers = customers
            };

            return viewModel;
        }

        public CustomerViewModel GetCustomer(string id)
        {
            CustomerModel customer = this.customerWebService.GetById(id);
            IList<OrderModel> orders = this.customerWebService.GetOrdersByCustomerId(id);
            IList<OrderViewModel> ordersViewModels = this.GetOrdersViewModels(orders);
            CustomerViewModel viewModel = new CustomerViewModel
            {
                Customer = customer,
                Orders = ordersViewModels
            };

            return viewModel;
        }

        public IList<CustomerGridModel> GetCustomersByName(string name)
        {
            IList<CustomerGridModel> viewModels = this.customerWebService.GetAll();
            if (!string.IsNullOrWhiteSpace(name))
            {
                viewModels = viewModels.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            return viewModels;
        }

        private IList<OrderViewModel> GetOrdersViewModels(IList<OrderModel> orders)
        {
            IList<OrderViewModel> ordersViewModels = new List<OrderViewModel>();
            foreach (OrderModel order in orders)
            {
                OrderViewModel viewModel = new OrderViewModel
                {
                    OrderID = order.OrderID,
                    TotalProducts = order.Products.Count,
                    TotalQuantities = order.Products.Sum(p => p.OrderQuantity),
                    TotalPrice = order.Products.Sum(p => p.OrderQuantity * (p.OrderUnitPrice - (decimal)p.OrderUnitDiscount)),
                    PossibleProblem = order.Products.Any(p => p.Discontinued || p.UnitsInStock < p.UnitsOnOrder)
                };

                ordersViewModels.Add(viewModel);
            }

            return ordersViewModels;
        }
    }
}
