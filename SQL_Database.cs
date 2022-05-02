using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Application_Lourde_CRM
{
    public class BDD
    {
        #region Champs

        /* Ne pas utilser */

        private MySqlConnection connexion;
        private static string serveur;
        private static string data_base;
        private static string uid;
        private static string password;

        #endregion

        #region Constructeurs

        public BDD(string Serveur, string Data_Base, string UID, string Password)
        {
            serveur = Serveur;
            data_base = Data_Base;
            uid = UID;
            password = Password;
            this.Initialisation_connexion();
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

        private void Initialisation_connexion()
        {
            //Méthode pour initialiser la connexion

            // Création de la chaîne de connexion
            string Connexion_String = "SERVER=" + serveur + ';' + "DATABASE=" + data_base + ';' + "UID=" + uid + ';' + "PASSWORD=" + password + ';';
            this.connexion = new MySqlConnection(Connexion_String);
        }

        private bool Ouverture_Connexion()
        {
            try
            {
                this.connexion.Open();
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
                this.connexion.Close();
                return true;
            }
            catch(MySqlException erreur)
            {
                Console.WriteLine(erreur.Message);
                return false;
            }
        }

        #region Recherche ID

        Client Recherche_ID_Clients(int Id_Client)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Client> tempTableauClients = new List<Client>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM clients WHERE IdCli = " + Id_Client;

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while (requete_aff.Read())
                {
                    Client ClientAff = new Client(Convert.ToInt32(requete_aff["IdCli"]), Convert.ToString(requete_aff["NomCli"]), Convert.ToString(requete_aff["PreCli"]), Convert.ToString(requete_aff["AdrCli"]), Convert.ToInt32(requete_aff["CpCli"]), Convert.ToString(requete_aff["VilleCli"]), Convert.ToString(requete_aff["MailCli"]), Convert.ToInt32(requete_aff["TelCli"]));
                    tempTableauClients.Add(ClientAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return tempTableauClients[0];
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        Produits Recherche_ID_Produits(int Id_Produits)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Produits> TempTableauProduits = new List<Produits>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM produits WHERE IdProd = " + Id_Produits;

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while (requete_aff.Read())
                {
                    Produits ProduitsAff = new Produits(Convert.ToInt32(requete_aff["IdProd"]), Convert.ToString(requete_aff["NomProd"]), Convert.ToString(requete_aff["TypeProd"]), Convert.ToDouble(requete_aff["PrixProd"]), Convert.ToInt32(requete_aff["LibProd"]));
                    TempTableauProduits.Add(ProduitsAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return TempTableauProduits[0];
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        Commercials Recherche_ID_Commercials(int Id_Commercials)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Commercials> TempTableauCommercials = new List<Commercials>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM commercials WHERE IdCommercial = " + Id_Commercials;

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while (requete_aff.Read())
                {
                    Commercials CommercialsAff = new Commercials(Convert.ToInt32(requete_aff["IdCommercial"]), Convert.ToString(requete_aff["NomCommercial"]), Convert.ToString(requete_aff["PreCommercial"]), Convert.ToInt32(requete_aff["TelCommercial"]), Convert.ToString(requete_aff["MailCommercial"]));
                    TempTableauCommercials.Add(CommercialsAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return TempTableauCommercials[0];
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        Prospects Recherche_ID_Prospects(int Id_Prospects)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Prospects> TempTableauProspects = new List<Prospects>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM prospects WHERE IdPro = " + Id_Prospects;

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while (requete_aff.Read())
                {
                    Prospects ProspectsAff = new Prospects(Convert.ToInt32(requete_aff["IdPro"]), Convert.ToString(requete_aff["NomPro"]), Convert.ToString(requete_aff["PrePro"]), Convert.ToString(requete_aff["MailPro"]), Convert.ToInt32(requete_aff["TelPro"]), Convert.ToString(requete_aff["AdrPro"]), Convert.ToString(requete_aff["VillePro"]), Convert.ToInt32(requete_aff["CpPro"]));
                    TempTableauProspects.Add(ProspectsAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return TempTableauProspects[0];
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        #endregion

        #region Afficher

        List<Client> Afficher_Client()
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Client> TableauClient = new List<Client>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM clients";

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while(requete_aff.Read())
                {
                    Client ClientAff = new Client(Convert.ToInt32(requete_aff["IdCli"]), Convert.ToString(requete_aff["NomCli"]), Convert.ToString(requete_aff["PreCli"]), Convert.ToString(requete_aff["AdrCli"]), Convert.ToInt32(requete_aff["CpCli"]), Convert.ToString(requete_aff["VilleCli"]), Convert.ToString(requete_aff["MailCli"]), Convert.ToInt32(requete_aff["TelCli"]));
                    TableauClient.Add(ClientAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return TableauClient;
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        List<Prospects> Afficher_Prospects()
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Prospects> TableauProspects = new List<Prospects>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM prospects";

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while (requete_aff.Read())
                {
                    Prospects ProspectsAff = new Prospects(Convert.ToInt32(requete_aff["IdPro"]), Convert.ToString(requete_aff["NomPro"]), Convert.ToString(requete_aff["PrePro"]), Convert.ToString(requete_aff["MailPro"]), Convert.ToInt32(requete_aff["TelPro"]), Convert.ToString(requete_aff["AdrPro"]), Convert.ToString(requete_aff["VillePro"]), Convert.ToInt32(requete_aff["CpPro"]));
                    TableauProspects.Add(ProspectsAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return TableauProspects;
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        List<Commercials> Afficher_Commercials()
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Commercials> TableauCommercials = new List<Commercials>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM commercials";

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while (requete_aff.Read())
                {
                    Commercials CommercialsAff = new Commercials(Convert.ToInt32(requete_aff["IdCommercial"]), Convert.ToString(requete_aff["NomCommercial"]), Convert.ToString(requete_aff["PreCommercial"]), Convert.ToInt32(requete_aff["TelCommercial"]), Convert.ToString(requete_aff["MailCommercial"]));                   
                    TableauCommercials.Add(CommercialsAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return TableauCommercials;
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        List<Produits> Afficher_Produits()
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Produits> TableauProduits = new List<Produits>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM produits";

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while (requete_aff.Read())
                {
                    Produits ProduitsAff = new Produits(Convert.ToInt32(requete_aff["IdProd"]), Convert.ToString(requete_aff["NomProd"]), Convert.ToString(requete_aff["TypeProd"]), Convert.ToDouble(requete_aff["PrixProd"]), Convert.ToInt32(requete_aff["LibProd"]));
                    TableauProduits.Add(ProduitsAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return TableauProduits;
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        List<Achats> Afficher_Achats()
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Achats> TableauAchats = new List<Achats>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM achats";

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while (requete_aff.Read())
                {
                    Achats AchatsAff = new Achats(Convert.ToInt32(requete_aff["IdAchat"]), /* Client , Produits */ Convert.ToInt32(requete_aff["Qte"]));
                    TableauAchats.Add(AchatsAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return TableauAchats;
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        List<Rendez_vous> Afficher_Rendez_vous()
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Rendez_vous> TableauRendez_vous = new List<Rendez_vous>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM rendez-vous";

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while (requete_aff.Read())
                {
                    Rendez_vous Rendez_vousAff = new Rendez_vous(Convert.ToInt32(requete_aff["IdRdv"]), /*Propects Commercials*/ Convert.ToDateTime(requete_aff["DateRdv"]);
                    TableauRendez_vous.Add(Rendez_vousAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return TableauRendez_vous;
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        List<Facture> Afficher_Facture()
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                List<Facture> TableauFacture = new List<Facture>();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM factures";

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                //Création d'un objet stocker dans un tableau à partir de la requête reçus (but afficher sur l'écran le résultat de la requête)
                while (requete_aff.Read())
                {
                    Client TempClient = Recherche_ID_Clients(requete_aff["IdCli"]);
                    Facture FactureAff = new Facture(Convert.ToInt32(requete_aff["IdFact"]), Recherche_ID_Clients(), Recherche_ID_Produits() ,Convert.ToDateTime(requete_aff["DateFact"]);
                    TableauFacture.Add(FactureAff);
                }

                //fermeture du Data Reader
                requete_aff.Close();

                // Fermeture de la connexion
                this.Fermeture_Connexion();

                return TableauFacture;
            }
            else
            {
                Console.WriteLine("Erreur");
                return null;
            }
        }

        #endregion

        #region Ajouter

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
                requete.Parameters.AddWithValue("@IdCli", client.ID);
                requete.Parameters.AddWithValue("@NomCli", client.NOM);
                requete.Parameters.AddWithValue("@PreCli", client.PRENOM);
                requete.Parameters.AddWithValue("@AdrCli", client.ADRESSE);
                requete.Parameters.AddWithValue("@CpCli", client.CODE_POSTAL);
                requete.Parameters.AddWithValue("@VilleCli", client.VILLE);
                requete.Parameters.AddWithValue("@MailCli", client.EMAIL);
                requete.Parameters.AddWithValue("@TelCli", client.TELEPHONE);

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

        public bool Ajouter_Prospects(Prospects prospects)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "INSERT INTO prospects (IdPro, NomPro, PrePro, AdrPro, CpPro, VillePro, MailPro, TelPro) VALUES(@IdPro, @NomPro, @PrePro, @AdrPro, @CpPro, @VillePro, @MailPro, @TelPro)";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdPro", prospects.ID);
                requete.Parameters.AddWithValue("@NomPro", prospects.NOM);
                requete.Parameters.AddWithValue("@PrePro", prospects.PRENOM);
                requete.Parameters.AddWithValue("@AdrPro", prospects.ADRESSE);
                requete.Parameters.AddWithValue("@CpPro", prospects.CODE_POSTAL);
                requete.Parameters.AddWithValue("@VillePro", prospects.VILLE);
                requete.Parameters.AddWithValue("@MailPro", prospects.MAIL);
                requete.Parameters.AddWithValue("@TelPro", prospects.TEL);

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
                requete.CommandText = "INSERT INTO commercials (IdCommercial, NomCommercial, PreCommercial, TelCommercial, MailCommercial) VALUES(@IdCommercial, @NomCommercial, @PreCommercial, @TelCommercial, @MailCommercial)";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdCommercial", commercials.ID);
                requete.Parameters.AddWithValue("@NomCommercial", commercials.NOM);
                requete.Parameters.AddWithValue("@PreCommercial", commercials.PRENOM);
                requete.Parameters.AddWithValue("@TelCommercial", commercials.TELEPHONE);
                requete.Parameters.AddWithValue("@MailCommercial", commercials.EMAIL);

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
                requete.Parameters.AddWithValue("@TypeProd", produits.TYPE);
                requete.Parameters.AddWithValue("@PrixProd", produits.PRIX);
                requete.Parameters.AddWithValue("@NomProd", produits.NOM);
                requete.Parameters.AddWithValue("@LibProd", produits.REFERENCE);

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

        public bool Ajouter_Achats(Achats achats)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "INSERT INTO achats (IdAchat, IdCli, IdProd, Qte) VALUES(@IdAchat, @IdCli, @IdProd, @Qte)";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdAchat", achats.ID);
                requete.Parameters.AddWithValue("@IdCli", achats.ID_Client);
                requete.Parameters.AddWithValue("@IdProd", achats.ID_Produits);
                requete.Parameters.AddWithValue("@Qte", achats.QUANTITE);

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

        public bool Ajouter_Rendez_vous(Rendez_vous rendez_vous)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "INSERT INTO produit (IdRdv, DateRdv, IdCommercial, IdPro) VALUES(@IdRdv, @DateRdv, @IdCommercial, @IdPro)";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdRdv", rendez_vous.ID);
                requete.Parameters.AddWithValue("@DateRdv", rendez_vous.DATE);
                requete.Parameters.AddWithValue("@IdCommercial", rendez_vous.ID_COMMERCIALS);
                requete.Parameters.AddWithValue("@IdPro", rendez_vous.ID_PROSPECTS);

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

        public bool Ajouter_Facture(Facture facture)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "INSERT INTO factures (IdFact, DateFact, IdAchat, IdCli) VALUES(@IdFact, @TypeProd, @DateFact, @IdAchat, @IdCli)";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdFact", facture.ID);
                requete.Parameters.AddWithValue("@DateFact", facture.DATE);
                requete.Parameters.AddWithValue("@IdCli", facture.ID_CLIENT);
                requete.Parameters.AddWithValue("@IdAchat", facture.ID_PRODUITS);


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

        public bool Modifier_Client(Client client)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "UPDATE clients SET IdCli=@IdCli, NomCli=@NomCli, PreCli=@PreCli, AdrCli=@AdrCli, CpCli=@CpCli, VilleCli=@VilleCli, MailCli=@MailCli, TelCli=@TelCli";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdCli", client.ID);
                requete.Parameters.AddWithValue("@NomCli", client.NOM);
                requete.Parameters.AddWithValue("@PreCli", client.PRENOM);
                requete.Parameters.AddWithValue("@AdrCli", client.ADRESSE);
                requete.Parameters.AddWithValue("@CpCli", client.CODE_POSTAL);
                requete.Parameters.AddWithValue("@VilleCli", client.VILLE);
                requete.Parameters.AddWithValue("@MailCli", client.EMAIL);
                requete.Parameters.AddWithValue("@TelCli", client.TELEPHONE);

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

        public bool Modifier_Prospects(Prospects prospects)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "UPDATE prospects SET IdPro=@IdPro, NomPro=@NomPro, PrePro=@PrePro, AdrPro=@AdrPro, CpPro=@CpPro, VillePro=@VillePro, MailPro=@MailPro, TelPro=@TelPro";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdPro", prospects.ID);
                requete.Parameters.AddWithValue("@NomPro", prospects.NOM);
                requete.Parameters.AddWithValue("@PrePro", prospects.PRENOM);
                requete.Parameters.AddWithValue("@AdrPro", prospects.ADRESSE);
                requete.Parameters.AddWithValue("@CpPro", prospects.CODE_POSTAL);
                requete.Parameters.AddWithValue("@VillePro", prospects.VILLE);
                requete.Parameters.AddWithValue("@MailPro", prospects.MAIL);
                requete.Parameters.AddWithValue("@TelPro", prospects.TEL);

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

        public bool Modifier_Commercials(Commercials commercials)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "UPDATE commercials SET IdCommercial=@IdCommercial, NomCommercial=@NomCommercial, PreCommercial=@PreCommercial, TelCommercial=@TelCommercial, MailCommercial=@MailCommercial";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdCommercial", commercials.ID);
                requete.Parameters.AddWithValue("@NomCommercial", commercials.NOM);
                requete.Parameters.AddWithValue("@PreCommercial", commercials.PRENOM);
                requete.Parameters.AddWithValue("@TelCommercial", commercials.TELEPHONE);
                requete.Parameters.AddWithValue("@MailCommercial", commercials.EMAIL);

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

        public bool Modifier_Produits(Produits produits)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "UPDATE produit SET IdProd=@IdProd, TypeProd=@TypeProd, PrixProd=@PrixProd, NomProd=@NomProd, LibProd=@LibProd";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdProd", produits.ID);
                requete.Parameters.AddWithValue("@TypeProd", produits.TYPE);
                requete.Parameters.AddWithValue("@PrixProd", produits.PRIX);
                requete.Parameters.AddWithValue("@NomProd", produits.NOM);
                requete.Parameters.AddWithValue("@LibProd", produits.REFERENCE);

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

        public bool Modifier_Achats(Achats achats)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "UPDATE achats SET IdAchat=@IdAchat, IdCli=@IdCli, IdProd=@IdProd, Qte=@Qte";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdAchat", achats.ID);
                requete.Parameters.AddWithValue("@IdCli", achats.ID_Client);
                requete.Parameters.AddWithValue("@IdProd", achats.ID_Produits);
                requete.Parameters.AddWithValue("@Qte", achats.QUANTITE);

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

        public bool Modifier_Rendez_vous(Rendez_vous rendez_vous)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "UPDATE produit SET IdRdv=@IdRdv, DateRdv=@DateRdv, IdCommercial=@IdCommercial, IdPro=@IdPro";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdRdv", rendez_vous.ID);
                requete.Parameters.AddWithValue("@DateRdv", rendez_vous.DATE);
                requete.Parameters.AddWithValue("@IdCommercial", rendez_vous.ID_COMMERCIALS);
                requete.Parameters.AddWithValue("@IdPro", rendez_vous.ID_PROSPECTS);

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

        public bool Modifier_Facture(Facture facture)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "UPDATE factures SET IdFact=@IdFact, DateFact=@DateFact, IdAchat=@IdAchat, IdCli=@IdCli";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdFact", facture.ID);
                requete.Parameters.AddWithValue("@DateFact", facture.DATE);
                requete.Parameters.AddWithValue("@IdCli", facture.ID_CLIENT);
                requete.Parameters.AddWithValue("@IdAchat", facture.ID_PRODUITS);


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

        #region Supprimer

        public bool Supprimer_Client(Client client)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "DELETE FROM clients WHERE IdCli=@IdCli, NomCli=@NomCli, PreCli=@PreCli, AdrCli=@AdrCli, CpCli=@CpCli, VilleCli=@VilleCli, MailCli=@MailCli, TelCli=@TelCli";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdCli", client.ID);
                requete.Parameters.AddWithValue("@NomCli", client.NOM);
                requete.Parameters.AddWithValue("@PreCli", client.PRENOM);
                requete.Parameters.AddWithValue("@AdrCli", client.ADRESSE);
                requete.Parameters.AddWithValue("@CpCli", client.CODE_POSTAL);
                requete.Parameters.AddWithValue("@VilleCli", client.VILLE);
                requete.Parameters.AddWithValue("@MailCli", client.EMAIL);
                requete.Parameters.AddWithValue("@TelCli", client.TELEPHONE);

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

        public bool Supprimer_Prospects(Prospects prospects)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "DELETE FROM prospects WHERE IdPro=@IdPro, NomPro=@NomPro, PrePro=@PrePro, AdrPro=@AdrPro, CpPro=@CpPro, VillePro=@VillePro, MailPro=@MailPro, TelPro=@TelPro";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdPro", prospects.ID);
                requete.Parameters.AddWithValue("@NomPro", prospects.NOM);
                requete.Parameters.AddWithValue("@PrePro", prospects.PRENOM);
                requete.Parameters.AddWithValue("@AdrPro", prospects.ADRESSE);
                requete.Parameters.AddWithValue("@CpPro", prospects.CODE_POSTAL);
                requete.Parameters.AddWithValue("@VillePro", prospects.VILLE);
                requete.Parameters.AddWithValue("@MailPro", prospects.MAIL);
                requete.Parameters.AddWithValue("@TelPro", prospects.TEL);

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

        public bool Supprimer_Commercials(Commercials commercials)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "DELETE FROM commercials WHERE IdCommercial=@IdCommercial, NomCommercial=@NomCommercial, PreCommercial=@PreCommercial, TelCommercial=@TelCommercial, MailCommercial=@MailCommercial";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdCommercial", commercials.ID);
                requete.Parameters.AddWithValue("@NomCommercial", commercials.NOM);
                requete.Parameters.AddWithValue("@PreCommercial", commercials.PRENOM);
                requete.Parameters.AddWithValue("@TelCommercial", commercials.TELEPHONE);
                requete.Parameters.AddWithValue("@MailCommercial", commercials.EMAIL);

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

        public bool Supprimer_Produits(Produits produits)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "DELETE FROM produit WHERE IdProd=@IdProd, TypeProd=@TypeProd, PrixProd=@PrixProd, NomProd=@NomProd, LibProd=@LibProd";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdProd", produits.ID);
                requete.Parameters.AddWithValue("@TypeProd", produits.TYPE);
                requete.Parameters.AddWithValue("@PrixProd", produits.PRIX);
                requete.Parameters.AddWithValue("@NomProd", produits.NOM);
                requete.Parameters.AddWithValue("@LibProd", produits.REFERENCE);

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

        public bool Supprimer_Achats(Achats achats)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "DELETE FROM achats WHERE IdAchat=@IdAchat, IdCli=@IdCli, IdProd=@IdProd, Qte=@Qte";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdAchat", achats.ID);
                requete.Parameters.AddWithValue("@IdCli", achats.ID_Client);
                requete.Parameters.AddWithValue("@IdProd", achats.ID_Produits);
                requete.Parameters.AddWithValue("@Qte", achats.QUANTITE);

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

        public bool Supprimer_Rendez_vous(Rendez_vous rendez_vous)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "DELETE WHERE produit WHERE IdRdv=@IdRdv, DateRdv=@DateRdv, IdCommercial=@IdCommercial, IdPro=@IdPro";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdRdv", rendez_vous.ID);
                requete.Parameters.AddWithValue("@DateRdv", rendez_vous.DATE);
                requete.Parameters.AddWithValue("@IdCommercial", rendez_vous.ID_COMMERCIALS);
                requete.Parameters.AddWithValue("@IdPro", rendez_vous.ID_PROSPECTS);

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

        public bool Supprimer_Facture(Facture facture)
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "DELETE FROM factures WHERE IdFact=@IdFact, DateFact=@DateFact, IdAchat=@IdAchat, IdCli=@IdCli";

                // Utilisation de l'objet Prospects passé en paramètre
                requete.Parameters.AddWithValue("@IdFact", facture.ID);
                requete.Parameters.AddWithValue("@DateFact", facture.DATE);
                requete.Parameters.AddWithValue("@IdCli", facture.ID_CLIENT);
                requete.Parameters.AddWithValue("@IdAchat", facture.ID_PRODUITS);


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

        #endregion


    }
}
