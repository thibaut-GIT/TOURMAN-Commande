using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionCommande.model;
using GestionCommande.controleur;
using GestionCommande.dao;
using GestionCommande.vue;
using System.Linq;

namespace GestionCommande.TestsUnitaires
{
    /// <summary>
    /// Description résumée pour TestsUnitaires
    /// </summary>
    [TestClass]
    public class TestsUnitaires
    {
        [TestMethod]
        public void TestCreateClientOk()
        {
            Controleur ctrl = new CommandeControleur();

            ctrl.CreerClient("Wilson", "Wade", "deadpool@marvel.com");

            Assert.AreEqual("Wilson", ctrl.GetClients().Last().Nom);
            Assert.AreEqual("Wade", ctrl.GetClients().Last().Prenom);
            Assert.AreEqual("deadpool@marvel.com", ctrl.GetClients().Last().Mail);
        }

        [TestMethod]
        public void TestCreateProduitOk()
        {
            Controleur ctrl = new CommandeControleur();

            ctrl.CreerProduit("Chimichangas", 20);

            Assert.AreEqual("Chimichanga", ctrl.GetProduits().Last().Designation);
            Assert.AreEqual(20, ctrl.GetProduits().Last().Prix);
        }

        [TestMethod]
        public void TestCreateCommandeOk()
        {
            Controleur ctrl = new CommandeControleur();

            ctrl.CreerClient("Wilson", "Wade", "deadpool@marvel.com");
            ctrl.CreerProduit("Chimichanga", 20);

            List<LigneCommande> lgCmd = new List<LigneCommande>();
            lgCmd.Add(new LigneCommande() { Produit = ctrl.GetProduits().Last(), Quantite = 1 });

            ctrl.CreerCommande(ctrl.GetClients().Last(), lgCmd);

            Assert.AreEqual(ctrl.GetClients().Last(), ctrl.GetCommandes().Last().Client);
            Assert.AreEqual(lgCmd, ctrl.GetCommandes().Last().LignesCommande);
        }

    }
}
