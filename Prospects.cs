using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    public class Prospects
    {

        #region Champs

        private int Id;
        private string Nom;
        private string Prenom;
        private string Email;
        private string Telephone;
        private string Adresse;
        private string Ville;
        private int Code_Postal;

        #endregion

        #region Constructeurs

        public Prospects(int id)
        {
            Id = id;
        }

        public Prospects(int id, string nom, string prenom, string email, string telephone, string adresse, string ville, int code_postal)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
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

        public string MAIL
        {
            get { return Email; }
            set { Email = value; }
        }

        public string TEL
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

        public int CODE_POSTAL
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
