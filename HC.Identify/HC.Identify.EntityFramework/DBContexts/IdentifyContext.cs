using HC.Identify.Core.Identify;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.EntityFramework.DBContexts
{
    public class IdentifyContext : DbContext
    {
        private static string IdentifyDSN = "IdentifyDSN";//"Data Source=.;Initial Catalog=IdentifyDB;Persist Security Info=True;User ID=sa;Password=qaz;";
        public IdentifyContext() : base(IdentifyDSN) { }

        static IdentifyContext()
        {
            Database.SetInitializer(new NeverCreateDatabase<IdentifyContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {

                throw new ArgumentNullException("modelBuilder");
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
