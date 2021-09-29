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
        private int Id_Client;
        private int Id_Produits;
        private int Quantite;

        #endregion

        #region Constructeurs

        public Achats(int id, Client client, Produits produits, int quantite)
        {
            Id = id;
            Id_Client = client.ID_Client;
            Id_Produits = produits.ID;
            Quantite = quantite;
        }

        #endregion

        #region Accesseurs/Mutateurs

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public int ID_Client
        {
            get { return Id_Client; }
            set { Id_Client = value; }
        }

        public int ID_Produits
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