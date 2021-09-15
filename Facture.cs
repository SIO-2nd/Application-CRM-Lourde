using System;


namespace Application_Lourde_CRM
{
	public class Facture
	{
        #region Champs

        private int ID_Facture_M;
        private Client ID_Client_M;
        private Produits ID_Produits_M;
        private string Date_Facture_M;

        #endregion

        #region Constructeurs

        public Facture(int id_facture, Client id_client, Produits id_produit, string date_facture)
        {
            ID_Facture_M = id_facture;
            ID_Client_M = id_client;
            ID_Produits_M = id_produit;
            Date_Facture_M = date_facture;
        }

        #endregion

        #region Accesseurs/Mutateurs

        public int ID_Facture
        {
            get { return ID_Facture_M; }
            set { ID_Facture_M = value; }
        }

        public Client ID_Client
        {
            get { return ID_Client_M; }
            set { ID_Client_M = value; }
        }

        public Produits ID_Produits
        {
            get { return ID_Produits_M; }
            set { ID_Produits_M = value; }
        }

        public string Date_Facture
        {
            get { return Date_Facture_M; }
            set { Date_Facture_M = value; }
        }

        #endregion
    }
}
