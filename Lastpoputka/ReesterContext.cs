using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lastpoputka
{
    class ReesterContext : DbContext
    {
        public ReesterContext() : base("DefaultConnection")
        { }

        public DbSet<Reester> Reesters { get; set; }
    }
}
