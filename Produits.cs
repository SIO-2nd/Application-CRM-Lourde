using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    public class Produits
    {

        #region Champs

        private int Id;
        private string Nom;
        private string Type;
        private double Prix;
        private int Reference;

        #endregion

        #region Constructeurs

        public Produits(int id, string nom, string type, double prix, int reference)
        {
            Id = id;
            Nom = nom;
            Type = type;
            Prix = prix;
            Reference = reference;

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

        public string TYPE
        {
            get { return Type; }
            set { Type = value; }
        }

        public double PRIX
        {
            get { return Prix; }
            set { Prix = value; }
        }

        public int REFERENCE
        {
            get { return Reference; }
            set { Reference = value; }
        }

        #endregion

        #region Methodes

        #endregion
    }
}