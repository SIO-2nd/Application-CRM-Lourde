using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    public class Rendez_Vous
    {

        #region Champs
        private int Id;
        private DateTime Date;
        private Commercial Commercial;
        private Contact Contact;
        #endregion

        #region Constructeurs
        public Rendez_Vous(int id, DateTime date, Commercial commercial, Contact contact)
        {
            Id = id;
            Date = date;
            Commercial = commercial;
            Contact = contact;
        }
        #endregion

        #region Accesseurs/Mutateurs
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public DateTime DATE
        {
            get { return Date; }
            set { Date = value; }
        }

        public Commercial COMMERCIAL
        {
            get { return Commercial; }
            set { Commercial = value; }
        }

        public Contact CONTACT
        {
            get { return Contact; }
            set { Contact = value; }
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
