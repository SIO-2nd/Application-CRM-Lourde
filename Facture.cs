using System;


namespace Application_Lourde_CRM
{
	public class Facture
	{
        #region Champs

        private int _Id;
        private Client _Client;
        private Achats _Achats;
        private DateTime _Date;

        #endregion

        #region Constructeurs
        public Facture()
        {

        }

        public Facture(int Id, Client Client, Achats Achats, DateTime Date)
        {
            _Id = Id;
            _Client = Client;
            _Achats = Achats;
            _Date = Date;
        }

        #endregion

        #region Accesseurs/Mutateurs

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public Client Client
        {
            get { return _Client; }
            set { _Client = value; }
        }

        public Achats Achats
        {
            get { return _Achats; }
            set { _Achats = value; }
        }

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        #endregion
    }
}
