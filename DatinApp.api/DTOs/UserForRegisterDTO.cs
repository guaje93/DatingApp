using System.ComponentModel.DataAnnotations;

namespace DatinApp.api.DTOs
{
    public class UserForRegisterDTO
    {
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(8,MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8")]
        public string UserName { get; set; }

    }
}