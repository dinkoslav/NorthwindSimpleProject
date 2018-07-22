namespace Fourth.Services.ViewModels.Forms
{
    using System.ComponentModel.DataAnnotations;

    public class CustomerSearchViewModel
    {
        [Required(ErrorMessage = "Name should not be empty! ***")]
        public string Name { get; set; }
    }
}
