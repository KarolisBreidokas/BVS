using System;
using System.Data.Entity;

namespace BVS.Data
{
    public class BVSDBContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
