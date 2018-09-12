using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.EntityFramework.DBContexts
{
    public class KsecpickContext : DbContext
    {
        private static string KsecpickDSN = "KsecpickDSN";

        public KsecpickContext():base(KsecpickDSN){}
        static KsecpickContext()
        {
            Database.SetInitializer(new NeverCreateDatabase<KsecpickContext>());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {

                throw new ArgumentNullException("modelBuilder");
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
