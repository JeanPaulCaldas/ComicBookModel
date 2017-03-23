using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ComicBookModel.Models;

namespace ComicBookModel
{
    public class Context : DbContext
    {
        public Context()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }
        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}
