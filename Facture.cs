using System;


namespace Application_Lourde_CRM
{
	public class Facture
	{
        #region Champs

        private int Id;
        private Client Client;
        private Produit Produit;
        private int Quantite;
        private DateTime Date;
        private double Montant;

        #endregion

        #region Constructeurs
        public Facture()
        {

        }

        public Facture(int id)
        {
            Id = id;
        }

        public Facture(int id, Client client, Produit produit, int quantite, DateTime date, double montant)
        {
            Id = id;
            Client = client;
            Produit = produit;
            Quantite = quantite;
            Date = date;
            Montant = montant;
        }

        #endregion

        #region Accesseurs/Mutateurs

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public Client CLIENT
        {
            get { return Client; }
            set { Client = value; }
        }

        public Produit PRODUIT
        {
            get { return Produit; }
            set { Produit = value; }
        }

        public int QUANTITE
        {
            get { return Quantite; }
            set { Quantite = value; }
        }

        public DateTime DATE
        {
            get { return Date; }
            set { Date = value; }
        }

        public double MONTANT
        {
            get { return Montant; }
            set { Montant = value; }
        }

        #endregion

        #region Méthode

        public string Client_NomPrenom()
        {
            string nom_prenom = Client.NOM + Client.PRENOM;
            return nom_prenom;
        }

        public string Produit_Nom()
        {
            string nom = Produit.NOM;
            return nom;
        }

        #endregion
    }
}
