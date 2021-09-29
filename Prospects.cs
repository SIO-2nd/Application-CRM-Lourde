using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    public class Prospects
    {

        #region Champs

        private int Id;
        private string Nom;
        private string Prenom;
        private string Email;
        private int Telephone;
        private string Adresse;
        private string Ville;
        private int Code_Postal;

        #endregion

        #region Constructeurs

        public Prospects(int id, string nom, string prenom, string email, int telephone, string adresse, string ville, int code_postal)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
            Adresse = adresse;
            Ville = ville;
            Code_Postal = code_postal;
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
        public string PrenomProspect
        {
            get { return Prenom; }
            set { Prenom = value; }
        }

        public string MailProspect
        {
            get { return Email; }
            set { Email = value; }
        }

        public int TelProspect
        {
            get { return Telephone; }
            set { Telephone = value; }
        }
        public string AdresseProspect
        {
            get { return Adresse; }
            set { Adresse = value; }
        }
        public string VilleProspect
        {
            get { return Ville; }
            set { Ville = value; }
        }

        public int CpProspect
        {
            get { return Code_Postal; }
            set { Code_Postal = value; }
        }

        #endregion

        #region Methodes
        public override string ToString()
        {
            // Méthode ToString() surchargée qui écrase la méthode ToString() de base
            return Convert.ToString(_numProspect);
        }
        #endregion
    }
}
