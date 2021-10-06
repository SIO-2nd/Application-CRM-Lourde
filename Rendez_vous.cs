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
        private int Id;
        private Prospects Id_Prospects;
        private Commercials Id_Commercials;
        private DateTime Date;
        #endregion

        #region Constructeurs
        public Rendez_vous(int id, Prospects id_prospects, Commercials id_commercials, DateTime date)
        {
            Id = id;
            Id_Prospects = id_prospects;
            Id_Commercials = id_commercials;
            Date = date;

        }
        #endregion

        #region Accesseurs/Mutateurs
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public Prospects ID_PROSPECTS
        {
            get { return Id_Prospects; }
            set { Id_Prospects = value; }
        }

        public Commercials ID_COMMERCIALS
        {
            get { return Id_Commercials; }
            set { Id_Commercials = value; }
        }
        public DateTime DATE
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
        #endregion
    }
}
