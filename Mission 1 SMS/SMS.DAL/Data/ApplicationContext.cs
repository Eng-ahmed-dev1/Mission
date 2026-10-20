using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public virtual DbSet<Laptop> Laptops { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var l = modelBuilder.Entity<Laptop>();
            var s = modelBuilder.Entity<Student>();
            var t = modelBuilder.Entity<Teacher>();
            var sb = modelBuilder.Entity<Subject>();


            l.HasOne(x => x.Student)
                .WithOne(x => x.Laptop)
                .HasForeignKey<Student>(x => x.LaptopId)
                .OnDelete(DeleteBehavior.Cascade);

            s.HasMany(x => x.Teachers)
               .WithMany(x => x.Students);

            sb.HasMany(x => x.Teachers)
                .WithOne(x=>x.Subject)
                .HasForeignKey(x=>x.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);







        }
    }
}
