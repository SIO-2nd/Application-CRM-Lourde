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

        private int ID;
        private string Nom;
        private string Prenom;
        private int Numero;
        private string Email;

        #endregion

        #region Constructeurs

        public Commercials(int id, string nom, string prenom, int numero, string email)
        {
            ID = id;
            Nom = nom;
            Prenom = prenom;
            Numero = numero;
            Email = email;
        }

        #endregion

        #region Accesseurs/Mutateurs

        public int ID_Commercials
        {
            get { return ID; }
            set { ID = value; }
        }

        public string Nom_Commercials
        {
            get { return Nom; }
            set { Nom = value; }
        }

        public string Prenom_Commercials
        {
            get { return Prenom; }
            set { Prenom = value; }
        }

        public int Numero_Commercials
        {
            get { return Numero; }
            set { Numero = value; }
        }

        public string Email_Commercials
        {
            get { return Email; }
            set { Email = value; }
        }

        #endregion
    }
}
