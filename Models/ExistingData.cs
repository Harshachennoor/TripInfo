//This model helps do Custom Validation on existing Emails and PhoneNumbers to create code-first migration.

using System.ComponentModel.DataAnnotations;

namespace TripInfo.Models
{
    public class ExistingData
    {
        public int ExistingDataId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
    }
}