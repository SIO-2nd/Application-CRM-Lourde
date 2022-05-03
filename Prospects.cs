using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    public class Prospect
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

        public Prospect()
        {

        }

        public Prospect(int id)
        {
            Id = id;
        }

        public Prospect(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public Prospect(string nom, string prenom, string telephone, string email, string adresse, string ville, string code_postal)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Email = email;
            Adresse = adresse;
            Ville = ville;
            Code_Postal = code_postal;
        }

        public Prospect(int id, string nom, string prenom, string telephone, string email, string adresse, string ville, string code_postal)
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

        #endregion

        #region Methodes
        public override string ToString()
        {
            // Méthode ToString() surchargée qui écrase la méthode ToString() de base
            return Convert.ToString(Id);
        }
        #endregion
    }
}
