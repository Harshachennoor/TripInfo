//Model to do code-first Migration

using Microsoft.EntityFrameworkCore;
using TripInfo.Models;

namespace TripInfo.Models{
    public class TripContext : DbContext{
        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
            { }

        //Adding Existing Table to Sqlite Database
        public DbSet<ExistingData> ExistingDatas {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Data used to check custom validation on Email and Phone number
            modelBuilder.Entity<ExistingData>().HasData(
                new ExistingData {ExistingDataId=1,Email="harshachennoor@gmail.com",PhoneNumber="3316660212"}
            );
        }
    }
}