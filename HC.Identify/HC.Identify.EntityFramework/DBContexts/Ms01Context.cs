using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.EntityFramework.DBContexts
{
    public class Ms01Context : DbContext
    {
        private static string Ms01DSN = "Ms01DSN";
        public Ms01Context() : base(Ms01DSN) { }
        static Ms01Context()
        {
            Database.SetInitializer(new NeverCreateDatabase<Ms01Context>());
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
