using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Application_Lourde_CRM
{
    class MySql_Database
    {
        #region Champs

        private string serveur = "localhost";
        private string user = "root";
        private string password = "root";
        private string database = "infotools";
        private MySqlConnection connexion = null;
        private string requete = null;

        #endregion

        #region Constructeurs

        public MySql_Database()
        {
            Connexion_BD();
        }

        public MySql_Database(string Serveur, string User, string Password, string DataBase)
        {
            serveur = Serveur;
            user = User;
            password = Password;
            database = DataBase;

            Connexion_BD();
        }

        #endregion

        #region Accesseurs/Mutateurs

        public string Serveur
        {
            get { return Serveur; }
            set { Serveur = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string DataBase
        {
            get { return database; }
            set { database = value; }
        }

        #endregion

        #region Connexion

        private void Connexion_BD()
        {
            // Chaîne de connexion
            string chaine_connexion = "server=" + serveur + ";userid=" + user + ";password=" + password + ";database=" + database;

            // Instancie un objet MySqlConnection pour gère les connexions à la base de donnée

            try
            {
                connexion = new MySqlConnection(chaine_connexion);

                connexion.Open();

                MessageBox.Show("Connexion réussit", "succès MySql", MessageBoxButton.OK);

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Ne peut pas se connecter au serveur.", "Erreur MySql", MessageBoxButton.OK);
                        break;

                    case 1045:
                        MessageBox.Show("Mot de passe ou nom d'utilisateur non valide, veuillez réessayer.", "Erreur MySql", MessageBoxButton.OK);
                        break;

                    default:
                        MessageBox.Show(ex.Message, "Erreur MySql", MessageBoxButton.OK);
                        break;
                }

                connexion.Close();
            }
        }

        #endregion

        #region Commande

        #region Prospect

        #region Lire
        public List<Prospect> GetProspect()
        {
            try
            {
                requete = "select * from prospect";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Prospect> cProspect = new List<Prospect>();

                while (resultat.Read())
                {
                    Prospect tmpProspect = new Prospect(Convert.ToInt32(resultat["IdPro"]), Convert.ToString(resultat["NomPro"]), Convert.ToString(resultat["PrePro"]), Convert.ToString(resultat["MailPro"]), Convert.ToInt32(resultat["TelPro"]), Convert.ToString(resultat["AdrPro"]), Convert.ToString(resultat["VillePro"]), Convert.ToInt32(resultat["CPPro"]));
                    cProspect.Add(tmpProspect);
                }

                connexion.Close();
                return cProspect;
            }
            catch (MySqlException error)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetProspects : " + error.Message);
                return new List<Prospect>();
            }

        }
        #endregion

        #region Créer
        public void PostProspect(Prospects prospect)
        {
            try
            {
                requete = "INSERT INTO prospects(NomPro, PrePro, AdrPro, CpPro, VillePro, MailPro, TelPro) VALUES (@Nom, @Prenom, @Adresse, @Code_Postal, @Ville, @Email, @Telephone)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id", Convert.ToString(prospect.Id));
                commande.Parameters.AddWithValue("@Nom", prospect.Nom);
                commande.Parameters.AddWithValue("@Prenom", prospect.Prenom);
                commande.Parameters.AddWithValue("@Email", prospect.Email);
                commande.Parameters.AddWithValue("@Telephone", Convert.ToString(prospect.Telephone));
                commande.Parameters.AddWithValue("@Adresse", prospect.Adresse);
                commande.Parameters.AddWithValue("@Ville", prospect.Ville);
                commande.Parameters.AddWithValue("@Code_Postal", Convert.ToString(prospect.Code_Postal));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PostProspect : " + ex.Message);
            }
        }
        #endregion

        #region Modifier
        public void PutProspect(Prospects prospect)
        {
            try
            {
                requete = "update prospects set NomPro = @Nom, PrePro = @Prenom, MailPro = @Email, TelPro = @Telephone, AdrPro = @Adresse, VillePro = @Ville, CpPro = @Code_Postal where Id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id", Convert.ToString(prospect.Id));
                commande.Parameters.AddWithValue("@Nom", Convert.ToString(prospect.Nom));
                commande.Parameters.AddWithValue("@Prenom", Convert.ToString(prospect.Prenom));
                commande.Parameters.AddWithValue("@Email", Convert.ToString(prospect.Email));
                commande.Parameters.AddWithValue("@Telephone", Convert.ToInt32(prospect.Telephone));
                commande.Parameters.AddWithValue("@Adresse", Convert.ToString(prospect.Adresse));
                commande.Parameters.AddWithValue("@Ville", Convert.ToString(prospect.Ville));
                commande.Parameters.AddWithValue("@Code_Postal", Convert.ToInt32(prospect.Code_Postal));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PutProspect : " + ex.Message);
            }
        }
        #endregion

        #region Supprimer
        public void DeleteProspect(int id)
        {
            try
            {
                requete = "delete from prospects where IdPro = @ID";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@ID", Convert.ToString(id));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur DeleteProspect " + ex.Message);
            }
        }
        #endregion

        #endregion

        #region Client

        #region Lire
        public List<Client> GetClient()
        {
            try
            {
                requete = "select * from clients";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Client> cclients = new List<Client>();

                while (resultat.Read())
                {
                    Client client = new Client
                        (
                            Convert.ToInt32(resultat["IdCli"]),
                            Convert.ToString(resultat["NomCli"]),
                            Convert.ToString(resultat["PreCli"]),
                            Convert.ToString(resultat["MailCli"]),
                            Convert.ToInt32(resultat["TelCli"]),
                            Convert.ToString(resultat["AdrCli"]),
                            Convert.ToString(resultat["VilleCli"]),
                            Convert.ToInt32(resultat["CPCli"])
                        );

                    cclients.Add(client);
                }

                connexion.Close();

                return cclients;
            }
            catch (Exception ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetClient " + ex.Message);
                return new List<Client>();
            }
        }
        #endregion

        #region Créer
        public void PostClient(Client client)
        {
            try
            {
                requete = "INSERT INTO clients(NomCli, PreCli, MailCli, TelCli, AdrCli, VilleCli, CpCli) VALUES (@Nom, @Prenom, @Email, @Telephone, @Adresse, @Ville, @Code_Postal)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", client.Nom);
                commande.Parameters.AddWithValue("@Prenom", client.Prenom);
                commande.Parameters.AddWithValue("@Email", client.Email);
                commande.Parameters.AddWithValue("@Telephone", Convert.ToString(client.Telephone));
                commande.Parameters.AddWithValue("@Adresse", client.Adresse);
                commande.Parameters.AddWithValue("@Ville", client.Ville);
                commande.Parameters.AddWithValue("@Code_Postal", Convert.ToString(client.Code_Postal));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PostClient " + ex.Message);
            }
        }
        #endregion

        #region Modifier
        public void PutClient(Client client)
        {
            try
            {
                requete = "update clients set NomCli = @Nom, PreCli = @Prenom, MailCli = @Email, TelCli = @Telephone, AdrCli = @Adresse, VilleCli = @Ville, CpCli = @Code_Postal where IdCli = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id", Convert.ToString(client.Id));
                commande.Parameters.AddWithValue("@Nom", Convert.ToString(client.Nom));
                commande.Parameters.AddWithValue("@Prenom", Convert.ToString(client.Prenom));
                commande.Parameters.AddWithValue("@Email", Convert.ToString(client.Email));
                commande.Parameters.AddWithValue("@Telephone", Convert.ToInt32(client.Telephone));
                commande.Parameters.AddWithValue("@Adresse", Convert.ToString(client.Adresse));
                commande.Parameters.AddWithValue("@Ville", Convert.ToString(client.Ville));
                commande.Parameters.AddWithValue("@Code_Postal", Convert.ToInt32(client.Code_Postal));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PutClient" + ex.Message);
            }
        }
        #endregion

        #region Supprimer
        public void DeleteClient(int id)
        {
            try
            {
                requete = "delete from clients where IdCli = @ID";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@ID", Convert.ToString(id));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur DeleteClient " + ex.Message);
            }
        }
        #endregion

        #endregion

        #region Commercial

        #region Lire
        public List<Commercials> GetCommercial()
        {
            try
            {
                requete = "select * from commercials";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Commercials> cCommercials = new List<Commercials>();

                while (resultat.Read())
                {
                    Commercials tmpCommercials = new Commercials
                        (
                            Convert.ToInt32(resultat["IdCommercial"]),
                            Convert.ToString(resultat["NomCommercial"]),
                            Convert.ToString(resultat["PreCommercial"]),
                            Convert.ToString(resultat["MailCommercial"]),
                            Convert.ToInt32(resultat["TelCommercial"])
                        );

                    cCommercials.Add(tmpCommercials);
                }

                connexion.Close();

                return cCommercials;
            }
            catch (Exception ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetCommercial " + ex.Message);
                return new List<Commercials>();
            }
        }
        #endregion

        #region Créer
        public void PostCommercial(Commercials commercials)
        {
            try
            {
                requete = "INSERT INTO commercials(NomCommercial, PreCommercial, MailCommercial, TelCommercial) VALUES (@Nom, @Prenom, @Email, @Telephone)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id", Convert.ToString(commercials.Id));
                commande.Parameters.AddWithValue("@Nom", commercials.Nom);
                commande.Parameters.AddWithValue("@Prenom", commercials.Prenom);
                commande.Parameters.AddWithValue("@Email", commercials.Email);
                commande.Parameters.AddWithValue("@Telephone", Convert.ToString(commercials.Telephone));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PostCommercial " + ex.Message);
            }
        }
        #endregion

        #region Modifier
        public void PutCommercial(Commercials commercials)
        {
            try
            {
                requete = "update commercials set NomCommercial = @Nom, PreCommercial = @Prenom, MailCommercial = @Email, TelCommercial = @Telephone where IdCommercial = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id", Convert.ToString(commercials.Id));
                commande.Parameters.AddWithValue("@Nom", Convert.ToString(commercials.Nom));
                commande.Parameters.AddWithValue("@Prenom", Convert.ToString(commercials.Prenom));
                commande.Parameters.AddWithValue("@Email", Convert.ToString(commercials.Email));
                commande.Parameters.AddWithValue("@Telephone", Convert.ToInt32(commercials.Telephone));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch(MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PutCommercial" + ex.Message);
            }
        }
        #endregion

        #region Supprimer
        public void DeleteCommercial(int id)
        {
            try
            {
                requete = "delete from commercials where IdCommercial = @ID";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@ID", Convert.ToString(id));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur DeleteCommercial " + ex.Message);
            }
        }
        #endregion

        #endregion

        #region Rendez-vous

        #region Lire
        public List<Rendez_vous> GetRdv()
        {
            try
            {
                requete = "select * from rendez-vous";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Rendez_vous> cRendez_Vous = new List<Rendez_vous>();

                while (resultat.Read())
                {
                    Commercials commercials = new Commercials(Convert.ToInt32(resultat["IdCommercial"]));
                    Prospects prospects = new Prospects(Convert.ToInt32(resultat["IdPro"]));
                    Rendez_vous tmpRendez_Vous = new Rendez_vous
                        (
                            Convert.ToInt32(resultat["IdRdv"]),
                            Convert.ToDateTime(resultat["DateRdv"]),
                            commercials,
                            prospects
                        );

                    cRendez_Vous.Add(tmpRendez_Vous);
                }

                connexion.Clone();

                return cRendez_Vous;
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetRdv " + ex.Message);
                return new List<Rendez_vous>();
            }
        }
        #endregion

        #region Créer
        public void PostRdv(Rendez_vous rendez_vous)
        {
            try
            {
                requete = "INSERT INTO rendez-vous(IdRdv, DateRdv, IdCommercial, IdPro) VALUES (@IDRDV, @DATERDV, @IDCOMMERCIALS, @IDPROSPECTS)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@IDRDV", Convert.ToString(rendez_vous.Id));
                commande.Parameters.AddWithValue("@DATERDV", rendez_vous.Date);
                commande.Parameters.AddWithValue("@IDCOMMERCIALS", rendez_vous.Commercials.Id);
                commande.Parameters.AddWithValue("@IDPROSPECTS", rendez_vous.Prospects.Id);

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PostCommercial " + ex.Message);
            }
        }
        #endregion

        #region Modifier
        public void PutRdv(Rendez_vous rendez_Vous)
        {
            try
            {
                requete = "update rendez-vous set DateRdv = @DATERDV, IdCommercial = @IDCOMMERCIAL, IdPro = @IDPROSPECT where IdRdv = @IDRDV";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@DATERDV", rendez_Vous.Date);
                commande.Parameters.AddWithValue("@IDCOMMERCIAL", rendez_Vous.Commercials.Id);
                commande.Parameters.AddWithValue("@IDPROSPECT", rendez_Vous.Prospects.Id);
                commande.Parameters.AddWithValue("@IDRDV", rendez_Vous.Id);

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PutCommercial " + ex.Message);
            }
        }
        #endregion

        #region Supprimer
        public void DeleteRdv(int id)
        {
            try
            {
                requete = "delete from rendez-vous where id = @ID";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@ID", id);

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur DeleteCommercial " + ex.Message);
            }
        }
        #endregion

        #endregion

        #region Facture

        #region Lire
        public List<Facture> GetFacture()
        {
            connexion.Open();

            try
            {
                requete = "select * from facture";



                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Facture> cFacture = new List<Facture>();

                while (resultat.Read())
                {
                    Client client = new Client(Convert.ToInt32(resultat["IdCli"]));
                    Achats achats = new Achats(Convert.ToInt32(resultat["IdAchat"]));

                    Facture tmpFacture = new Facture
                        (
                            Convert.ToInt32(resultat["Id"]),
                            client,
                            achats,
                            Convert.ToDateTime(resultat["Date"])
                        );

                    cFacture.Add(tmpFacture);
                }

                connexion.Close();

                return cFacture;
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetFacture " + ex.Message);
                return new List<Facture>();
            }
        }
        #endregion

        #region Créer
        public void PostFacture(Facture facture)
        {
            try
            {
                requete = "INSERT INTO () VALUES (@)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@", Convert.ToString(facture.Id));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch(MySqlException ex)
            {
                connexion.Clone();
                Console.WriteLine("Erreur PostFacture " + ex.Message);
            }
        }
        #endregion

        #region Modifier
        #endregion

        #region Supprimer
        #endregion

        #endregion

        #endregion


    }
}