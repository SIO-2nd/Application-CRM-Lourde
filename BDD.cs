using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Application_Lourde_CRM
{
    public class BDD
    {
        #region Champs

        private MySqlConnection connexion;
        private static string serveur;
        private static string data_base;
        private static string uid;
        private static string password;

        #endregion

        #region Constructeurs

        public BDD()
        {
            this.initialisation_connexion();
        }

        #endregion

        #region Accesseurs/Mutateurs

        public string Serveur
        {
            get { return Serveur; }
            set { Serveur = value; }
        }

        public string Data_Base
        {
            get { return data_base; }
            set { data_base = value; }
        }

        public string UID
        {
            get {return uid;}
            set { uid = value;}
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        #endregion

        #region Méthode

        private void initialisation_connexion()
        {
            string Connexion_String = "SERVER=" + serveur + ';' + "DATABASE=" + data_base + ';' + "UID=" + uid + ';' + "PASSWORD=" + password + ';';
            connexion = new MySqlConnection(Connexion_String);
        }

        private bool Ouverture_Connexion()
        {
            try
            {
                connexion.Open();
                return true;
            }
            catch (MySqlException erreur)
            {
                switch (erreur.Number)
                {
                    case 0:
                        Console.WriteLine("Impossible de se connecter au serveur, veuillez contacter l'administrateur réseau de votre infratructure");
                        break;
                    case 1045:
                        Console.WriteLine("Nom d'utilsateur et mot de passe incorrecte, veuillez réessayer");
                        break;
                }
                return false;
            }
        }

        private bool Fermeture_Connexion()
        {
            try
            {
                connexion.Close();
                return true;
            }
            catch(MySqlException erreur)
            {
                Console.WriteLine(erreur.Message);
                return false;
            }
        }

        public bool Ajouter()
        {
            if(this.Ouverture_Connexion())
            {
                MySqlCommand requete = this.connexion.CreateCommand();

                requete.CommandText = "INSERT INTO" + " " +

                requete.ExecuteNonQuery();

                this.Fermeture_Connexion();
                return true;
            }
            else
            {
                Console.WriteLine("Erreur");
                return false;
            }
        }

        public bool Modifier()
        {
            if(this.Ouverture_Connexion())
            {
                this.Ouverture_Connexion();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool
        #endregion
    }
}
