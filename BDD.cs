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

        private MySqlConnection connexion;
        private static string serveur;
        private static string data_base;
        private static string uid;
        private static string password;

        #endregion

        #region Constructeurs

        public BDD()
        {
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

        #region Afficher

        public bool Afficher_Client()
        {
            if (this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM clients";

                //Exécution de la commande SQL
                MySqlDataReader requete_aff = requete.ExecuteReader();

                while(requete_aff.Read())
                {
                    DataGrid.Rows.Add(requette_aff[0], requette_aff[1], requette_aff[2]);
                }


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

        public bool Afficher_Prospects()
        {
            if(this.Ouverture_Connexion())
            // Ouverture de la connexion SQL + vérification
            {


                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand requete = this.connexion.CreateCommand();

                // Requête SQL
                requete.CommandText = "SELECT * FROM ";

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
