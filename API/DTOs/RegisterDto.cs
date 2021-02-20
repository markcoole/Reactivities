using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[~@#$^*()_+=[\\]{}|\\,.?: -])(?=.*[a-z])(?=.*[A-Z]).{4,12}$", ErrorMessage = "Password must be complex")]
        public string Password { get; set; }
        public string Username { get; set; }
    }
}