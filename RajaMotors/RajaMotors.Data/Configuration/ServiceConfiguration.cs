using RajaMotors.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace RajaMotors.Data.Configuration
{
    public class ServiceConfiguration:EntityTypeConfiguration<Service>
    {
        public ServiceConfiguration()
        {
            Property(c => c.ServiceId).IsRequired();
        }
    }
}
