using System.ComponentModel.DataAnnotations;

namespace Task_Identity.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public bool RemmeberMe { get; set; }
    }
}
