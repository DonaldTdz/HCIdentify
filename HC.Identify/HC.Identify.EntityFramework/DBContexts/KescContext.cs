using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.EntityFramework.DBContexts
{
  public  class KescContext:DbContext
    {
        public KescContext() : base("KsecDSN") { }

        static KescContext()
        {
            Database.SetInitializer(new NeverCreateDatabase<KescContext>());
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
