using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    class Rendez_vous
    {

        #region Champs
        private int _idRdv;
        private int _idProspect;
        private int _idCommercial;
        private DateTime _dateRdv;
        #endregion

        #region Constructeurs
        public Rendez_vous(int id, int pros, int comm, DateTime date)
        {
            _idRdv = id;
            _idProspect = pros;
            _idCommercial = comm;
            _dateRdv = date;

        }
        #endregion

        #region Accesseurs/Mutateurs
        public int IdRdv
        {
            get { return _idRdv; }
            set { _idRdv = value; }
        }

        public int IdProspect
        {
            get { return _idProspect; }
            set { _idProspect = value; }
        }

        public int IdCommercial
        {
            get { return _idCommercial; }
            set { _idCommercial = value; }
        }
        public DateTime DateRdv
        {
            get { return _dateRdv; }
            set { _dateRdv = value; }
        }
        #endregion

        #region Methodes
        public override string ToString()
        {
            return Convert.ToString(_idRdv);
        }
        #endregion
    }
}