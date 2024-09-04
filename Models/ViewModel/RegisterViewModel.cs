using System.ComponentModel.DataAnnotations;

namespace Task_Identity.Models.ViewModel
{
    public class RegisterViewModel
    {

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public String ConfirmPassword { get; set; }

        public String Phone { get; set; }


    }
}
