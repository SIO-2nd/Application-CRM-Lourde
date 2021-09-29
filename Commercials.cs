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

        private int Id;
        private string Nom;
        private string Prenom;
        private int Telephone;
        private string Email;

        #endregion

        #region Constructeurs

        public Commercials(int id, string nom, string prenom, int telephone, string email)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Email = email;
        }

        #endregion

        #region Accesseurs/Mutateurs

        public int ID
        {
            get { return ID; }
            set { ID = value; }
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

        public int TELEPHONE
        {
            get { return Telephone; }
            set { Telephone = value; }
        }

        public string EMAIL
        {
            get { return Email; }
            set { Email = value; }
        }

        #endregion
    }
}
