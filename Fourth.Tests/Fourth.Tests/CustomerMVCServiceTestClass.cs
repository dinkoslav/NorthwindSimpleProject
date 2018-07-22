namespace Fourth.Tests
{
    using Fourth.Services;
    using Fourth.Services.Interfaces;
    using Fourth.Services.ViewModels.Models;
    using Fourth.WebServices.Interfaces;
    using Moq;
    using NUnit.Framework;
    using Services.ViewModels.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class CustomerMVCServiceTestClass
    {
        private const string CustomerId = "AALFA";
        private ICustomerMVCService customerMVCService;
        private Mock<ICustomerWebService> mockCustomerMVCService;

        [SetUp]
        public void Init()
        {
            this.mockCustomerMVCService = new Mock<ICustomerWebService>();
            this.mockCustomerMVCService.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new CustomerModel()
                {
                    Address = "Address",
                    City = "City",
                    CompanyName = "CompanyName",
                    ContactName = "ContactName",
                    ContactTitle = "Title",
                    Country = "Bulgaria",
                    CustomerID = CustomerId,
                    Fax = "Fax",
                    Phone = "123",
                    PostalCode = "5800",
                    Region = "Sofia"
                });
            this.mockCustomerMVCService.Setup(x => x.GetOrdersByCustomerId(It.IsAny<string>()))
                .Returns(new List<OrderModel>
                {
                    new OrderModel
                    {
                        OrderID = 10435,
                        Products = new List<OrderProductModel>
                        {
                            new OrderProductModel
                            {
                                ProductName = "Chang",
                                OrderUnitPrice = 15,
                                OrderQuantity = 10,
                                OrderUnitDiscount = 0,
                                Discontinued = false,
                                UnitsInStock = 17,
                                UnitsOnOrder = 40
                            },
                            new OrderProductModel
                            {
                                ProductName = "Gustaf's Knäckebröd",
                                OrderUnitPrice = 16,
                                OrderQuantity = 12,
                                OrderUnitDiscount = 0,
                                Discontinued = false,
                                UnitsInStock = 104,
                                UnitsOnOrder = 0
                            },
                            new OrderProductModel
                            {
                                ProductName = "Mozzarella di Giovanni",
                                OrderUnitPrice = 27,
                                OrderQuantity = 10,
                                OrderUnitDiscount = 0,
                                Discontinued = false,
                                UnitsInStock = 14,
                                UnitsOnOrder = 0
                            }
                        }
                    },
                    new OrderModel
                    {
                        OrderID = 10462,
                        Products = new List<OrderProductModel>
                        {
                            new OrderProductModel
                            {
                                ProductName = "Konbu",
                                OrderUnitPrice = 4,
                                OrderQuantity = 1,
                                OrderUnitDiscount = 0,
                                Discontinued = false,
                                UnitsInStock = 24,
                                UnitsOnOrder = 0
                            },
                            new OrderProductModel
                            {
                                ProductName = "Tunnbröd",
                                OrderUnitPrice = 7,
                                OrderQuantity = 21,
                                OrderUnitDiscount = 0,
                                Discontinued = false,
                                UnitsInStock = 61,
                                UnitsOnOrder = 0
                            }
                        }
                    },
                    new OrderModel
                    {
                        OrderID = 10848,
                        Products = new List<OrderProductModel>
                        {
                            new OrderProductModel
                            {
                                ProductName = "Chef Anton's Gumbo Mix",
                                OrderUnitPrice = 21,
                                OrderQuantity = 30,
                                OrderUnitDiscount = 0,
                                Discontinued = true,
                                UnitsInStock = 0,
                                UnitsOnOrder = 0
                            },
                            new OrderProductModel
                            {
                                ProductName = "Mishi Kobe Niku",
                                OrderUnitPrice = 97,
                                OrderQuantity = 3,
                                OrderUnitDiscount = 0,
                                Discontinued = true,
                                UnitsInStock = 29,
                                UnitsOnOrder = 0
                            }
                        }
                    }
                });
            this.customerMVCService = new CustomerMVCService(this.mockCustomerMVCService.Object);
        }

        [Test]
        public void GetCustomerOrdersWithTwoPossibleProblems()
        {
            CustomerViewModel customerViewModel = this.customerMVCService.GetCustomer(CustomerId);

            Assert.AreEqual(2, customerViewModel.Orders.Count(x => x.PossibleProblem));
        }
    }
}
