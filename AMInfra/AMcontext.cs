using AM.ApplicationCore.Domain;
using AMInfra.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMInfra
{
    public class AMcontext :DbContext
    {
        DbSet<Flight> flights { get; set; }
        DbSet<Passenger> passengers { get; set; }
        DbSet<Plane> planes { get; set; }
 
        DbSet<Staff> staffs { get; set; }

        DbSet<Traveller> travellers { get; set; }
        DbSet<Ticket> ticket { get; set; }
        DbSet<ReservationTicket> reservations { get; set; }
       
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
      Initial Catalog=4ERP9;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationTicketConfiguration());
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.fullname,
                full =>
                {
                    full.Property(p => p.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                    full.Property(p => p.LastName).HasColumnName("PassLastName").IsRequired();
                })
             //.HasDiscriminator<int>("PassengerType").HasValue<Passenger>(0).HasValue<Staff>(1).HasValue<Traveller>(2)
             ;
            //TPT
            modelBuilder.Entity<Traveller>().ToTable("travellers");
            modelBuilder.Entity<Staff>().ToTable("Staffs");

            base.OnModelCreating(modelBuilder);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
            base.ConfigureConventions(configurationBuilder);
        }

    }
}
