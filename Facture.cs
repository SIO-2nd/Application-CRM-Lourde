﻿using System;


namespace Application_Lourde_CRM
{
	public class Facture
	{
        #region Champs

        private int Id;
        private Client Id_Client;
        private Produits Id_Produits;
        private string Date;

        #endregion

        #region Constructeurs

        public Facture(int id, Client id_client, Produits id_produit, string date)
        {
            Id = id;
            Id_Client = id_client;
            Id_Produits = id_produit;
            Date = date;
        }

        #endregion

        #region Accesseurs/Mutateurs

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public Client ID_CLIENT
        {
            get { return Id_Client; }
            set { Id_Client = value; }
        }

        public Produits ID_PRODUITS
        {
            get { return Id_Produits; }
            set { Id_Produits = value; }
        }

        public string DATE
        {
            get { return Date; }
            set { Date = value; }
        }

        #endregion
    }
}
