using Microsoft.EntityFrameworkCore;

namespace CBMS.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasOne(x => x.Ticket)
                .WithOne(c => c.Customer)
                .HasForeignKey<Customer>(x => x.TicketId);

            modelBuilder.Entity<Hall>()
                .HasMany(x => x.Movies)
                .WithOne(x => x.Hall)
                .HasForeignKey(x => x.HallId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Customers)
                .WithMany(x => x.Movies);

        }
    }
}
