using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    class Prospects
    {

        #region Champs
        private int _numProspect;
        private string _nomProspect;
        private string _prenomProspect;
        private string _mailProspect;
        private int _telProspect;
        private string _adresseProspect;
        private string _villeProspect;
        private int _cpProspect;
        #endregion

        #region Constructeurs
        public Prospects(int num, string nom, string prenom, string mail, int tel, string adresse, string ville, int cp)
        {
            _numProspect = num;
            _nomProspect = nom;
            _prenomProspect = prenom;
            _mailProspect = mail;
            _telProspect = tel;
            _adresseProspect = adresse;
            _villeProspect = ville;
            _cpProspect = cp;
        }
        #endregion

        #region Accesseurs/Mutateurs
        public int NumProspect
        {
            get { return _numProspect; }
            set { _numProspect = value; }
        }

        public string NomProspect
        {
            get { return _nomProspect; }
            set { _nomProspect = value; }
        }
        public string PrenomProspect
        {
            get { return _prenomProspect; }
            set { _prenomProspect = value; }
        }

        public string MailProspect
        {
            get { return _mailProspect; }
            set { _mailProspect = value; }
        }

        public int TelProspect
        {
            get { return _telProspect; }
            set { _telProspect = value; }
        }
        public string AdresseProspect
        {
            get { return _adresseProspect; }
            set { _adresseProspect = value; }
        }
        public string VilleProspect
        {
            get { return _villeProspect; }
            set { _villeProspect = value; }
        }

        public int CpProspect
        {
            get { return _cpProspect; }
            set { _cpProspect = value; }
        }
        #endregion

        #region Methodes
        public override string ToString()
        {
            return Convert.ToString(_numProspect);
        }
        #endregion
    }
}
