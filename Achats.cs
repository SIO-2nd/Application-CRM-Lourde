using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    public class Achats
    {
        #region Champs

        private int Id;
        private Client Id_Client;
        private Produit Id_Produits;
        private int Quantite;

        #endregion

        #region Constructeurs

        public Achats()
        {

        }

        public Achats(int id)
        {
            Id = id;
        }

        public Achats(int id, Client client, Produit produits, int quantite)
        {
            Id = id;
            Id_Client = client;
            Id_Produits = produits;
            Quantite = quantite;
        }

        #endregion

        #region Accesseurs/Mutateurs

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public Client ID_Client
        {
            get { return Id_Client; }
            set { Id_Client = value; }
        }

        public Produit ID_Produits
        {
            get { return Id_Produits; }
            set { Id_Produits = value; }
        }

        public int QUANTITE
        {
            get { return Quantite; }
            set { Quantite = value; }
        }
        #endregion
    }
}