using System;

namespace Application_Lourde_CRM
{
	public class Client
	{
		#region Champs

		private int _Id;
		private string _Nom;
		private string _Prenom;
		private string _Adresse;
		private int _Code_Postal;
		private string _Ville;
		private string _Email;
		private int _Telephone;

		#endregion

		#region Constructeurs

		public Client()
        {

        }

		public Client(int Id)
        {
			_Id = Id;
        }
		public Client(int Id, string Nom, string Prenom, string Adresse, int Telephone, string Ville, string Email, int Code_Postal)
		{
			_Id = Id;
			_Nom = Nom;
			_Prenom = Prenom;
			_Adresse = Adresse;
			_Telephone = Telephone;
			_Ville = Ville;
			_Email = Email;
			_Code_Postal = Code_Postal;
		}

		#endregion

		#region Accesseurs/Mutateurs

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		public string Nom
        {
            get { return _Nom; }
			set { _Nom = value; }
        }

		public string Prenom
		{
			get { return _Prenom; }
			set { _Prenom = value; }
		}

		public string Adresse
		{
			get { return _Adresse; }
			set { _Adresse = value; }
		}

		public int Telephone
		{
			get { return _Telephone; }
			set { _Telephone = value; }
		}

		public string Ville
        {
			get { return _Ville; }
			set { _Ville = value; }
        }

		public string Email
        {
			get { return _Email; }
            set { _Email = value; }
        }

		public int Code_Postal
		{
			get { return _Code_Postal; }
			set { _Code_Postal = value; }
		}
		#endregion


	}
}
