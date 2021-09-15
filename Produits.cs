using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Lourde_CRM
{
    class Produits
    {

        #region Champs
        private int _numProduit;
        private string _nomProduit;
        private string _typeProduit;
        private int _refProduit;
        #endregion

        #region Constructeurs
        public Produits(int num, string nom, string type, int reference)
        {
            _numProduit = num;
            _nomProduit = nom;
            _typeProduit = type;
            _refProduit = reference;

        }
        #endregion

        #region Accesseurs/Mutateurs
        public int NumProduit
        {
            get { return _numProduit; }
            set { _numProduit = value; }
        }

        public string NomProduit
        {
            get { return _nomProduit; }
            set { _nomProduit = value; }
        }

        public string TypeProduit
        {
            get { return _typeProduit; }
            set { _typeProduit = value; }
        }
        public int RefProduit
        {
            get { return _refProduit; }
            set { _refProduit = value; }
        }
        #endregion

        #region Methodes
        public override string ToString()
        {
            return Convert.ToString(_numProduit);
        }
        #endregion
    }
}