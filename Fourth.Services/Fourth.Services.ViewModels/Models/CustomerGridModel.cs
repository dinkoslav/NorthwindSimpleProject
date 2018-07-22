namespace Fourth.Services.ViewModels.Models
{
    using System.ComponentModel;

    public class CustomerGridModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Orders")]
        public int OrdersCount { get; set; }
    }
}
