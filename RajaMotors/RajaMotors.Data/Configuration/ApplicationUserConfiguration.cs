using RajaMotors.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Data.Configuration
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(c => c.EmailId).IsRequired().HasMaxLength(150);
            Property(c => c.FirstName).IsRequired().HasMaxLength(150);
            Property(c => c.LastName).HasMaxLength(150);
        }
    }
}
