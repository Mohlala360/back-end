using ControllerApp.DatabaseRules;
using ControllerApp.DatabaseRules.Books;
using ControllerApp.DatabaseRules.Cars;
using ControllerApp.DatabaseRules.UserBooks;
using ControllerApp.DatabaseRules.Users;
using ControllerApp.Domains;
using ControllerApp.Domains.Books;
using ControllerApp.Domains.Cars;
using ControllerApp.Domains.UserBooks;
using ControllerApp.Domains.Users;
using Microsoft.EntityFrameworkCore;

namespace ControllerApp
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<UserBookState> UserBookStates { get; set; }
        public DbSet<UserBookStatus> UserBookStatuses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBooking> CarBookings { get; set; }
        public DbSet<CarBookStatus> CarBookStatuses { get; set; }
        public DbSet<CarBookState> CarBookStates { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorRule());
            modelBuilder.ApplyConfiguration(new BookRule());
            modelBuilder.ApplyConfiguration(new UserTypeRule());
            modelBuilder.ApplyConfiguration(new UserRule());
            modelBuilder.ApplyConfiguration(new UserBookStatusRule());
            modelBuilder.ApplyConfiguration(new UserBookRule());
            modelBuilder.ApplyConfiguration(new UserBookStateRule());
            modelBuilder.ApplyConfiguration(new CarRule());
            modelBuilder.ApplyConfiguration(new CarBookingRule());
            modelBuilder.ApplyConfiguration(new CarBookStatusRule());
            modelBuilder.ApplyConfiguration(new CarBookStateRule());
            modelBuilder.ApplyConfiguration(new UserHistoryRule());
        }
    }
}
