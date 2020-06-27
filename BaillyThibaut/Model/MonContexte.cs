using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MonContexte : DbContext
    {
        public MonContexte() : base("name=MaConnexion")
        {
            Database.SetInitializer<MonContexte>(new DropCreateDatabaseIfModelChanges<MonContexte>());
        }

        public DbSet<Classe> Classes { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Absence> Absences { get; set; }
    }
}
