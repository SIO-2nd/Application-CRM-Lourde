using System;

namespace Application_Lourde_CRM
{
	public class Client
	{
		#region Champs

		private int Id;
		private string Nom;
		private string Prenom;
		private string Adresse;
		private int Code_Postal;
		private string Ville;
		private string Email;
		private int Telephone;

		#endregion

		#region Constructeurs

		public Client(int id)
		{
			Id = id;
		}

		public Client(int id, string nom, string prenom, string adresse, int codePostal, string ville, string email, int telephone)
		{
			Id=id;
			Nom = nom;
			Prenom = prenom;
			Adresse = adresse;
			Code_Postal = codePostal;
			Ville = ville;
			Email = email;
			Telephone = telephone;
		}

		#endregion

		#region Accesseurs/Mutateurs

		public int ID
		{
			get { return Id; }
			set { Id = value; }
		}

		public string NOM
        {
            get { return NOM; }
			set { NOM = value; }
        }

		public string PRENOM
		{
			get { return Prenom; }
			set { Prenom = value; }
		}

		public string ADRESSE
		{
			get { return Adresse; }
			set { Adresse = value; }
		}

		public int CODE_POSTAL
		{
			get { return Code_Postal; }
			set { Code_Postal = value; }
		}

		public string VILLE
        {
			get { return Ville; }
			set { Ville = value; }
        }

		public string EMAIL
        {
			get { return Email; }
            set { Email = value; }
        }

		public int TELEPHONE
        {
            get { return Telephone; }
            set { Telephone = value; }
        }
		#endregion


	}
}
