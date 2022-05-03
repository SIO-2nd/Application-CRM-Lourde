using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    public class Produit
    {

        #region Champs

        private int Id;
        private string Nom;
        private double Prix;
        private string Description;

        #endregion

        #region Constructeurs

        public Produit(string Nom)
        {

        }

        public Produit(int id, string nom, double prix, string description)
        {
            Id = id;
            Nom = nom;
            Prix = prix;
            Description = description;
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

        public double PRIX
        {
            get { return Prix; }
            set { Prix = value; }
        }

        public string DESCRIPTION 
        {
            get { return Description; }
            set { Description = value; }
        }

        #endregion

        #region Methodes

        #endregion
    }
}