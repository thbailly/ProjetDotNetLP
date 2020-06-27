using System;
using System.Collections.Generic;
using System.Linq;
using BusinessManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Entities;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OnCreateClasse()
        {
            Classe classe = new Classe { NomEtablissement = "Une super classe de test", Niveau = "Terminal", Eleves = new List<Eleve>() };

            Manager.Instance.AddClasse(classe);

            Assert.AreEqual(Manager.Instance.GetAllClasses().Last(),classe);
        }

        [TestMethod]
        public void OnDeleteClasse()
        {
            Classe classeToDelete = Manager.Instance.GetAllClasses().Last();

            Manager.Instance.DeleteClasseById(classeToDelete.Id);

            Assert.IsTrue(!Manager.Instance.GetAllClasses().Contains(classeToDelete));
        }

        [TestMethod]
        public void OnModifyClasse()
        {
            Classe toModify = Manager.Instance.GetAllClasses().Last();

            toModify.Niveau = "Test";

            Manager.Instance.ModifyClasse(toModify);
            Assert.IsTrue(Manager.Instance.getOneClasseById(toModify.Id).Niveau == "Test");
        }
    }
}
