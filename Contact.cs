using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
	public class Contact
	{
		#region Champs

		private int Id;
		private string Nom;
		private string Prenom;
		private string Telephone;
		private string Email;
		private string Adresse;
		private string Ville;
		private string Code_Postal;

        #endregion

        #region Constructeurs
        public Contact()
        {

        }

        public Contact(int id)
        {
            Id = id;
        }

        public Contact(string nom, string prenom, string telephone, string email, string adresse, string ville, string code_postal)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Email = email;
            Adresse = adresse;
            Ville = ville;
            Code_Postal = code_postal;
        }

        public Contact(int id, string nom, string prenom, string telephone, string email, string adresse, string ville, string code_postal)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Email = email;
            Adresse = adresse;
            Ville = ville;
            Code_Postal = code_postal;
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
            get { return Nom; }
            set { Nom = value; }
        }
        public string PRENOM
        {
            get { return Prenom; }
            set { Prenom = value; }
        }

        public string EMAIL
        {
            get { return Email; }
            set { Email = value; }
        }

        public string TELEPHONE
        {
            get { return Telephone; }
            set { Telephone = value; }
        }
        public string ADRESSE
        {
            get { return Adresse; }
            set { Adresse = value; }
        }
        public string VILLE
        {
            get { return Ville; }
            set { Ville = value; }
        }

        public string CODE_POSTAL
        {
            get { return Code_Postal; }
            set { Code_Postal = value; }
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
        #endregion
    }
}