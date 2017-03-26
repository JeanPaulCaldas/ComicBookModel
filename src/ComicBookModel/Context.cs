using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ComicBookModel.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ComicBookModel
{
    public class Context : DbContext
    {
        public Context()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            Database.SetInitializer(new DatabaseInitializer());
        }
        public DbSet<ComicBook> ComicBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            //modelBuilder.Conventions.Add(new DecimalPropertyConvention(5, 2));

            modelBuilder.Entity<ComicBook>().Property(cb => cb.AverageRating).HasPrecision(5, 2);
        }
    }
}
