using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyCarHistory.Utils.DatabaseEntities;

namespace MyCarHistory.Utils {
    class CarDBContext: DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Filename=" + Program.DB_PATH, options => {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<ServiceLog>().ToTable("ServiceLog");
            modelBuilder.Entity<Car>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ServiceLog>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ServiceLog>()
                .HasOne(s => s.Car)
                .WithMany(p => p.serviceLogs);
            modelBuilder.Entity<Car>()
                .HasMany(p => p.serviceLogs)
                .WithOne(s => s.Car);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceLog> Services { get; set; }
    }
}
