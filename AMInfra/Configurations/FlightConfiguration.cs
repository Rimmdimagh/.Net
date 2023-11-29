using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMInfra.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //configuration de la relation many to many avec le choix de nom de la table association 
            builder.HasMany(b => b.Passengers)
                .WithMany(b => b.Flights)
                .UsingEntity(tab=>tab.ToTable("Volpassenger"));
            //relation one to many 
            builder.HasOne(b => b.Plane)
                .WithMany(b => b.Flights)
                .HasForeignKey(b=>b.PlaneFK)
                .OnDelete(DeleteBehavior.Cascade);



            

        }
    }
}
