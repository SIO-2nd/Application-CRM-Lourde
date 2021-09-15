using System;

namespace Application_Lourde_CRM
{
	public class Client
	{
		#region Champs

		private int ID;
		private string Nom;
		private string Prenom;
		private string Adresse;
		private int Code_Postal;
		private string Ville;
		private string Email;
		private int Numero;

		#endregion

		#region Constructeurs

		public Client(int id, string nom, string prenom, string adresse, int codePostal, string ville, string email, int numero)
		{
			ID=id;
			Nom = nom;
			Prenom = prenom;
			Adresse = adresse;
			Code_Postal = codePostal;
			Ville = ville;
			Email = email;
			Numero = numero;
		}

		#endregion

		#region Accesseurs/Mutateurs

		public int ID_Client
		{
			get { return ID; }
			set { ID = value; }
		}

		public string Nom_Client
        {
            get { return Nom; }
			set { Nom = value; }
        }

		public string Prenom_Client
		{
			get { return Prenom; }
			set { Prenom = value; }
		}

		public string Adresse_Client
		{
			get { return Adresse; }
			set { Adresse = value; }
		}

		public int Code_Postal_Client
		{
			get { return Code_Postal; }
			set { Code_Postal = value; }
		}

		public string Ville_Client
        {
			get { return Ville; }
			set { Ville = value; }
        }

		public string Email_Client
        {
			get { return Email; }
            set { Email = value; }
        }

		public int Numero_Client
        {
            get { return Numero; }
            set { Numero = value; }
        }
		#endregion


	}
}
