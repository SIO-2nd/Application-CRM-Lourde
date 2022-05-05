using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    public class Commercial
    {
        #region Champs

        private int Id;
        private string Nom;
        private string Prenom;
        private string Telephone;
        private string Email;

        #endregion

        #region Constructeurs

        public Commercial()
        {

        }

        public Commercial(int id)
        {
            Id = id;
        }

        public Commercial(string nom, string prenom, string telephone, string email)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Email = email;
        }

        public Commercial(int id, string nom, string prenom, string telephone, string email)
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

        public string EMAIL
        {
            get { return Email; }
            set { Email = value; }
        }

        public string TELEPHONE
        {
            get { return Telephone; }
            set { Telephone = value; }
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
        #endregion
    }
}
