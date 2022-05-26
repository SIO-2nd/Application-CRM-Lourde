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

        public Rendez_Vous(DateTime date, Commercial commercial, Contact contact)
        {
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

        public int COMMERCIAL_ID
        {
            get { return Commercial.ID; }
            set { Commercial.ID = value; }
        }

        public string COMMERCIAL_EMAIL
        {
            get { return Commercial.EMAIL; }
            set { Commercial.EMAIL = value; }
        }

        public string COMMERCIAL_TELEPHONE
        {
            get { return Commercial.TELEPHONE; }
            set { Commercial.TELEPHONE = value; }
        }

        public Contact CONTACT
        {
            get { return Contact; }
            set { Contact = value; }
        }

        public int CONTACT_ID
        {
            get { return Contact.ID; }
            set { Contact.ID = value; }
        }

        public string CONTACT_EMAIL
        {
            get { return Contact.EMAIL; }
            set { Contact.EMAIL = value; }
        }

        public string CONTACT_TELEPHONE
        {
            get { return Contact.TELEPHONE; }
            set { Contact.TELEPHONE = value; }
        }

        public string CONTACT_ADRESSE
        {
            get { return Contact.ADRESSE; }
            set { Contact.ADRESSE = value; }
        }

        public string CONTACT_VILLE
        {
            get { return Contact.VILLE; }
            set { Contact.VILLE = value; }
        }

        public string CONTACT_CODE_POSTAL
        {
            get { return Contact.CODE_POSTAL; }
            set { Contact.CODE_POSTAL = value; }
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
