using BusinessManager;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = Manager.Instance;
            /*Classe c = new Classe() { Niveau = "Terminale", NomEtablissement = "Edouard Vaillant" };
            Note n1 = new Note() { Matiere = "Mathématiques", Valeur = 10 };
            List<Note> notes = new List<Note>();
            notes.Add(n1);
            manager.AjouterEleve(new Eleve() { Nom = "sqfsdf", Prenom = "sdfdd", Classe = c, DateDeNaissance = new DateTime(), Notes = notes });
            manager.AjouterEleve(new Eleve() { Nom = "fqsdfsdf", Prenom = "qsdfsqdf", Classe = c, DateDeNaissance = new DateTime(), Notes = new List<Note>() });*/
            Console.WriteLine("Hello");
            List<Eleve> eleves = manager.GetAllEleve();
            foreach (Eleve e in eleves)
            {
                Console.WriteLine("Elève : ");
                Console.WriteLine("{0} {1}", e.Id, e.Nom);
            }
            Thread.Sleep(3000);
        }
    }
}
