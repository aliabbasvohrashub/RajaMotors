using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaMotors.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private RajaMotorsEntities dataContext;
        public RajaMotorsEntities Get()
        { 
            return dataContext ?? (dataContext = new RajaMotorsEntities());  
        }

        protected override void DisposeCore()
        {if(dataContext != null)
            {
                dataContext.Dispose();
            } 
        } 
    }
}
