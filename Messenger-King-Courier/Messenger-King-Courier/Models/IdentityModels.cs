using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Messenger_King_Courier.Models.AppModels;

namespace Messenger_King_Courier.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

            public DbSet<Booking> Bookings {get;set;}
            public DbSet<Client> Clients { get; set; }
            public DbSet<Document> Documents { get; set; }
            public DbSet<Driver> Drivers { get; set; }  
            public DbSet<Inspection> Inspections { get; set; }
            public DbSet<InspectionCategory> InspectionCategories { get; set; }
            public DbSet<Invoice> Invoices { get; set; }
            public DbSet<Order> Orders{ get; set; }
            public DbSet<OrderCategory> OrderCategories { get; set; }
            public DbSet<Quote> Quotes { get; set; }
            public DbSet<Rate> Rates { get; set; }
            public DbSet<Vehicle> Vehicles { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
