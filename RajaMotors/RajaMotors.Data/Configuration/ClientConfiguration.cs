using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Data.Configuration
{
    public class ClientConfiguration:EntityTypeConfiguration<Client>
    { 
        public ClientConfiguration()
        {
            Property(c => c.ClientId).IsRequired();
            Property(c => c.ClientName).IsRequired().HasMaxLength(500);
            Property(c => c.ClientAddress).IsRequired().HasMaxLength(1000);
            Property(c => c.ClientMobile).IsRequired().HasMaxLength(50); 
        }
    }
}
