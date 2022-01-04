using System;


namespace Application_Lourde_CRM
{
	public class Facture
	{
        #region Champs

        private int Id;
        private Client Id_Client;
        private Achats Id_Achats;
        private DateTime Date;

        #endregion

        #region Constructeurs

        public Facture(int id)
        {
            Id = id;
        }

        public Facture(int id, Client id_client, Achats id_Achats, DateTime date)
        {
            Id = id;
            Id_Client = id_client;
            Id_Achats = id_Achats;
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

        public Achats ID_ACHATS
        {
            get { return Id_Achats; }
            set { Id_Achats = value; }
        }

        public DateTime DATE
        {
            get { return Date; }
            set { Date = value; }
        }

        #endregion
    }
}
