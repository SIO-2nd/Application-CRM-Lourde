using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    public class Commercials
    {
        #region Champs

        private int _Id;
        private string _Nom;
        private string _Prenom;
        private string _Email;
        private int _Telephone;

        #endregion

        #region Constructeurs

        public Commercials()
        {

        }

        public Commercials(int Id)
        {
            _Id = Id;
        }

        public Commercials(string Nom, string Prenom, string Email, int Telephone)
        {
            _Nom = Nom;
            _Prenom = Prenom;
            _Email = Email;
            _Telephone = Telephone;
        }

        public Commercials(int Id, string Nom, string Prenom, string Email, int Telephone)
        {
            _Id = Id;
            _Nom = Nom;
            _Prenom = Prenom;
            _Email = Email;
            _Telephone = Telephone;
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
        #endregion
    }
}
