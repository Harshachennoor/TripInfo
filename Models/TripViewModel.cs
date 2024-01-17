//Model helpful for Viewing the Trip data

namespace TripInfo.Models
{
    public class TripViewModel
    {

         public int TripID { get; set; }

        public string? Destination { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Accommodation { get; set; }

        public Accommodation? AccommodationDetails { get; set; }

        public ThingsToDo? ThingsToDoDetails { get; set; }

    }
}