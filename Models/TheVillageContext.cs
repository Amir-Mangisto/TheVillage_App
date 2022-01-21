using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TheVillage_App.Models
{
    public partial class TheVillageContext : DbContext
    {
        public TheVillageContext()
            : base("name=TheVillageContext")
        {
        }

        public virtual DbSet<Citizen> Citizens { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
