namespace Fourth.MVC.Controllers
{
    using Services.Interfaces;
    using Services.ViewModels.Models;
    using Services.ViewModels.ViewModels;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CustomerController : Controller
    {
        private readonly ICustomerMVCService customerMVCService;

        public CustomerController(ICustomerMVCService customerMVCService)
        {
            this.customerMVCService = customerMVCService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            CustomersViewModel viewModel = this.customerMVCService.GetCustomers();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Info(string id)
        {
            CustomerViewModel viewModel = this.customerMVCService.GetCustomer(id);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Search(string name)
        {
            IList<CustomerGridModel> viewModels = this.customerMVCService.GetCustomersByName(name);

            return this.PartialView("~/Views/Customer/_CustomersGridPartial.cshtml", viewModels);
        }
    }
}