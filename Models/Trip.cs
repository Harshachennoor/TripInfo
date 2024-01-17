//Trip Model this validations and its respective messages

using System.ComponentModel.DataAnnotations;

namespace TripInfo.Models
{
    public class Trip
    {
        public int TripID { get; set; }

        [Required(ErrorMessage = "Please enter a destination")]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Destination must only contain alphabets")]
        public string? Destination { get; set; }

        [Required(ErrorMessage ="Select Start Date")]
        [StartDateCheck]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage ="Select End Date")]
        [EndDateCheck]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Enter Accomodation Name")]
        [RegularExpression("^[a-zA-Z0-9\\s-']+$", ErrorMessage = "Accomodation must only contain alphabets, ' , - ,and numbers")]
        public string? Accommodation { get; set; }

        //Custom Validation for StartDate to be in the future
        public class StartDateCheck : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                string msg = base.ErrorMessage ?? $"{validationContext.DisplayName}";

                if (value is DateTime)
                {
                    DateTime Check = (DateTime)value;
                    if (Check < DateTime.Now)
                    {
                        return new ValidationResult(msg + " must be a future fate");
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                return new ValidationResult("");
            }
        }

        //Custom validation for trip EndDate to be in the future and ahead of StartDate.
        public class EndDateCheck : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                string msg = base.ErrorMessage ?? $"{validationContext.DisplayName}";
                if (value is DateTime)
                {
                    DateTime Check = (DateTime)value;
                    var trip = (Trip)validationContext.ObjectInstance;
                    if (Check < DateTime.Now && Check < trip.StartDate)
                    {
                        return new ValidationResult(msg +" must be future date and greater than Start Date");
                    }
                    else if (Check < DateTime.Now)
                    {
                        return new ValidationResult(msg +" must be future date");
                    }
                    else if (Check < trip.StartDate)
                    {
                        return new ValidationResult(msg +" must be greater than Start Date");
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                return new ValidationResult("");
            }
        }
    }
}