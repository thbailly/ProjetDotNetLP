using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    [Table("jalon1_eleve")]
    public class Eleve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateDeNaissance { get; set; }
        public int ClasseId { get; set; }

        public double Moyenne { get; set; }

        [ForeignKey("ClasseId")]
        public Classe Classe { get; set; }
        public ICollection<Absence> Absences { get; set; }
        public ICollection<Note> Notes { get; set; }

        public double GetMoyenne()
        {
            double res = 0;
            foreach(Note n in Notes)
            {
                res = res + n.Valeur;
            }
            Moyenne = res == 0 ? 0 : Math.Round(res / Notes.Count(), 2);
            return Moyenne;
        }
    }
}
