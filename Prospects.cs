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

        private int _Id;
        private string _Nom;
        private string _Prenom;
        private string _Email;
        private int _Telephone;
        private string _Adresse;
        private string _Ville;
        private int _Code_Postal;

        #endregion

        #region Constructeurs

        public Prospects()
        {

        }

        public Prospects(int Id)
        {
            _Id = Id;
        }

        public Prospects(string Nom, string Prenom)
        {
            _Nom = Nom;
            _Prenom = Prenom;
        }

        public Prospects(int Id, string Nom, string Prenom, string Email, int Telephone, string Adresse, string Ville, int Code_Postal)
        {
            _Id = Id;
            _Nom = Nom;
            _Prenom = Prenom;
            _Email = Email;
            _Telephone = Telephone;
            _Adresse = Adresse;
            _Ville = Ville;
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

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public int Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        public string Adresse
        {
            get { return _Adresse; }
            set { _Adresse = value; }
        }
        public string Ville
        {
            get { return _Ville; }
            set { _Ville = value; }
        }

        public int Code_Postal
        {
            get { return _Code_Postal; }
            set { _Code_Postal = value; }
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
