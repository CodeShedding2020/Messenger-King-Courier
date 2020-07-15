using Messenger_King_Courier.Models.AppModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

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

        public DbSet<AccountCategory> AccountCategories { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankCategory> BankCategories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientCategory> ClientCategories { get; set; }
        public DbSet<ClientCategoryCopy> ClientCategoryCopies { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<InspectionCategory> InspectionCategories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderCategory> OrderCategories { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
        public DbSet<TrackingCategory> TrackingCategories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        //Role Management
        public DbSet<IdentityUserRole> UserInRole { get; set; }
        // public DbSet<ApplicationUser> appUsers { get; set; }
        public DbSet<ApplicationRole> appRoles { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

  
    }
}
