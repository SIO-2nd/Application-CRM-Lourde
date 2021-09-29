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

        #region Ajouter

        public bool Ajouter_Prospects(Prospects prospects)
        {
            if(this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "INSERT INTO prospects (IdPro, NomPro, PrePro, AdrPro, CpPro, VillePro, MailPro, TelPro) VALUES(@idPro, @NomPro, @PrePro, @AdrPro, @CpPro, @VillePro, @MailPro, @TelPro)";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdPro", prospects.NumProspect);
                requete.Parameters.AddWithValue("@NomPro", prospects.NomProspect);
                requete.Parameters.AddWithValue("@PrePro", prospects.PrenomProspect);
                requete.Parameters.AddWithValue("@AdrPro", prospects.AdresseProspect);
                requete.Parameters.AddWithValue("@CpPro", prospects.CpProspect);
                requete.Parameters.AddWithValue("@VillePro", prospects.VilleProspect);
                requete.Parameters.AddWithValue("@MailPro", prospects.MailProspect);
                requete.Parameters.AddWithValue("@TelPro", prospects.TelProspect);

                //Exécution de la commande SQL
                requete.ExecuteNonQuery();


                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return true;
            }
            else
            {
                Console.WriteLine("Erreur");
                return false;
            }
        }

        public bool Ajouter_Client(Client client)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "INSERT INTO clients (IdCli, NomCli, PreCli, AdrCli, CpCli, VilleCli, MailCli, TelCli) VALUES(@IdCli, @NomCli, @PreCli, @AdrCli, @CpCli, @VilleCli, @MailCli, @TelCli)";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdCli", client.ID_Client);
                requete.Parameters.AddWithValue("@NomCli", client.Nom_Client);
                requete.Parameters.AddWithValue("@PreCli", client.Prenom_Client);
                requete.Parameters.AddWithValue("@AdrCli", client.Adresse_Client);
                requete.Parameters.AddWithValue("@CpCli", client.Code_Postal_Client);
                requete.Parameters.AddWithValue("@VilleCli", client.Ville_Client);
                requete.Parameters.AddWithValue("@MailCli", client.Email_Client);
                requete.Parameters.AddWithValue("@TelCli", client.Numero_Client);

                //Exécution de la commande SQL
                requete.ExecuteNonQuery();


                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return true;
            }
            else
            {
                Console.WriteLine("Erreur");
                return false;
            }
        }

        public bool Ajouter_Commercials(Commercials commercials)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "INSERT INTO commercials (idCommercial, NomCommercial, PreCommercial, TelCommercial, MailCommercial) VALUES(@idCommercial, @NomCommercial, @PreCommercial, @TelCommercial, @MailCommercial)";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdCommercial", commercials.ID_Commercials);
                requete.Parameters.AddWithValue("@NomCommercial", commercials.Nom_Commercials);
                requete.Parameters.AddWithValue("@PreCommercial", commercials.Prenom_Commercials);
                requete.Parameters.AddWithValue("@TelCommercial", commercials.Numero_Commercials);
                requete.Parameters.AddWithValue("@MailCommercial", commercials.Email_Commercials);

                //Exécution de la commande SQL
                requete.ExecuteNonQuery();


                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return true;
            }
            else
            {
                Console.WriteLine("Erreur");
                return false;
            }
        }

        public bool Ajouter_Produits(Produits produits)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "INSERT INTO produit (IdProd, TypeProd, PrixProd, NomProd, LibProd) VALUES(@IdProd, @TypeProd, @PrixProd, @NomProd, @LibProd)";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdProd", produits.ID);
                requete.Parameters.AddWithValue("@TypeProd", produits.TypeProduit);
                requete.Parameters.AddWithValue("@PrixProd", produits.PrixProduit);
                requete.Parameters.AddWithValue("@NomProd", produits.NomProduit);
                requete.Parameters.AddWithValue("@LibProd", produits.RefProduit);

                //Exécution de la commande SQL
                requete.ExecuteNonQuery();


                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return true;
            }
            else
            {
                Console.WriteLine("Erreur");
                return false;
            }
        }

        public bool Facture(Facture facture)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "INSERT INTO produit (IdProd, TypeProd, PrixProd, NomProd, LibProd) VALUES(@IdProd, @TypeProd, @PrixProd, @NomProd, @LibProd)";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdProd", facture.ID_Facture);
                requete.Parameters.AddWithValue("@TypeProd", facture.Date_Facture);
                requete.Parameters.AddWithValue("@PrixProd", facture.I);
                requete.Parameters.AddWithValue("@NomProd", .);
                requete.Parameters.AddWithValue("@LibProd", .);

                //Exécution de la commande SQL
                requete.ExecuteNonQuery();


                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return true;
            }
            else
            {
                Console.WriteLine("Erreur");
                return false;
            }
        }

        #endregion

        #region Modifier

  
        #endregion

        #endregion
    }
}
