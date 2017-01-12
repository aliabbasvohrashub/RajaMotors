using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Data.Configuration
{
    public class VehicleConfiguration:EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            Property(v => v.VehicleId).IsRequired();
            Property(v => v.ClientId).IsRequired();
        }
    }
}
