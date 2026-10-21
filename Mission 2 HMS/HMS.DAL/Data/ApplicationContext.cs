using Microsoft.EntityFrameworkCore;

namespace HMS.DAL.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var g = modelBuilder.Entity<Guest>();
            var d = modelBuilder.Entity<Department>();
            var r = modelBuilder.Entity<Room>();
            var s = modelBuilder.Entity<Staff>();


            g.HasMany(x => x.Staffs)
                .WithMany(x => x.Guests);

            r.HasIndex(x => x.RoomNumber)
                .IsUnique();

            r.HasOne(x => x.Guest)
                .WithOne(x => x.Room)
                .HasForeignKey<Guest>(x => x.RoomId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            d.HasMany(x => x.Staffs)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
