using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    public class Rendez_vous
    {

        #region Champs
        private int _Id;
        private DateTime _Date;
        private Prospects _Prospects;
        private Commercials _Commercials;
        #endregion

        #region Constructeurs
        public Rendez_vous(int Id, DateTime Date, Commercials Commercials, Prospects Prospects)
        {
            _Id = Id;
            _Date = Date;
            _Prospects = Prospects;
            _Commercials = Commercials;
        }
        #endregion

        #region Accesseurs/Mutateurs
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public Prospects Prospects
        {
            get { return _Prospects; }
            set { _Prospects = value; }
        }

        public Commercials Commercials
        {
            get { return _Commercials; }
            set { _Commercials = value; }
        }
        public DateTime Date
        {
            get { return Date; }
            set { Date = value; }
        }
        #endregion

        #region Methodes
        public override string ToString()
        {
            return Convert.ToString(Id);
        }

        public string Commercial_NomPrenom()
        {
            string nom_prenom = _Commercials.Nom + _Commercials.Prenom;
            return nom_prenom;
        }

        public string Prospects_NomPrenom()
        {
            string nom_prenom = _Prospects.Nom + _Prospects.Prenom;
            return nom_prenom;
        }

        #endregion
    }
}
