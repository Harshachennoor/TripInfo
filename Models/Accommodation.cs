//Accommodation Model with Inbuilt Validation

using System.ComponentModel.DataAnnotations;

namespace TripInfo.Models
{
    public class Accommodation
    {
        public string? Name;

        [Required(ErrorMessage ="Please Enter Phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Must be 10 digits only")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="Must be digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Please Enter Email Id")]
        [RegularExpression("^[a-z0-9@.]+$", ErrorMessage ="Must contain aplhabets,digits, . , @ only")]
        public string? Email { get; set; }
    }
}