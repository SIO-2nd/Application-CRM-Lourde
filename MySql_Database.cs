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
                    Prospect tmpProspect = new Prospect(
                        Convert.ToInt32(resultat["id"]), 
                        Convert.ToString(resultat["Nom"]), 
                        Convert.ToString(resultat["Prenom"]), 
                        Convert.ToString(resultat["telephone"]), 
                        Convert.ToString(resultat["email"]), 
                        Convert.ToString(resultat["adresse"]), 
                        Convert.ToString(resultat["ville"]), 
                        Convert.ToString(resultat["code_postal"]));
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
        public void PostProspect(Prospect prospect)
        {
            try
            {
                requete = "INSERT INTO prospect(nom, prenom, telephone, email, adresse, ville, code_postal) VALUES (@Nom, @Prenom, @Telephone, @Email, @Adresse, @Ville, @Code_Postal)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", prospect.NOM);
                commande.Parameters.AddWithValue("@Prenom", prospect.PRENOM);
                commande.Parameters.AddWithValue("@Telephone", prospect.TELEPHONE);
                commande.Parameters.AddWithValue("@Email", prospect.EMAIL);
                commande.Parameters.AddWithValue("@Adresse", prospect.ADRESSE);
                commande.Parameters.AddWithValue("@Ville", prospect.VILLE);
                commande.Parameters.AddWithValue("@Code_Postal", prospect.CODE_POSTAL);

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
        public void PutProspect(Prospect prospect)
        {
            try
            {
                requete = "update prospect set nom = @Nom, prenom = @Prenom, telephone = @Telephone, email = @Email, adresse = @Adresse, ville = @Ville, code_postal = @Code_Postal where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", Convert.ToString(prospect.NOM));
                commande.Parameters.AddWithValue("@Prenom", Convert.ToString(prospect.PRENOM));
                commande.Parameters.AddWithValue("@Telephone", Convert.ToString(prospect.TELEPHONE));
                commande.Parameters.AddWithValue("@Email", Convert.ToString(prospect.EMAIL));
                commande.Parameters.AddWithValue("@Adresse", Convert.ToString(prospect.ADRESSE));
                commande.Parameters.AddWithValue("@Ville", Convert.ToString(prospect.VILLE));
                commande.Parameters.AddWithValue("@Code_Postal", Convert.ToString(prospect.CODE_POSTAL));
                commande.Parameters.AddWithValue("@Id", Convert.ToString(prospect.ID));

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
                requete = "delete from prospect where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id", Convert.ToString(id));

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
                requete = "select * from client";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Client> cclients = new List<Client>();

                while (resultat.Read())
                {
                    Client client = new Client(
                            Convert.ToInt32(resultat["id"]), 
                            Convert.ToString(resultat["nom"]), 
                            Convert.ToString(resultat["prenom"]),
                            Convert.ToString(resultat["telephone"]),
                            Convert.ToString(resultat["email"]),
                            Convert.ToString(resultat["adresse"]),
                            Convert.ToString(resultat["ville"]),
                            Convert.ToString(resultat["code_postal"])
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
                requete = "INSERT INTO client(nom, prenom, telephone, email, adresse, ville, code_postal) VALUES (@Nom, @Prenom, @Telephone, @Email, @Adresse, @Ville, @Code_Postal)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", client.NOM);
                commande.Parameters.AddWithValue("@Prenom", client.PRENOM);
                commande.Parameters.AddWithValue("@Telephone", client.TELEPHONE);
                commande.Parameters.AddWithValue("@Email", client.EMAIL);
                commande.Parameters.AddWithValue("@Adresse", client.ADRESSE);
                commande.Parameters.AddWithValue("@Ville", client.VILLE);
                commande.Parameters.AddWithValue("@Code_Postal", client.CODE_POSTAL);

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
                requete = "update client set nom = @Nom, prenom = @Prenom, telephone = @Telephone, email = @Email, adresse = @Adresse, ville = @Ville, code_postal = @Code_Postal where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", client.NOM);
                commande.Parameters.AddWithValue("@Prenom", client.PRENOM);
                commande.Parameters.AddWithValue("@Telephone", client.TELEPHONE);
                commande.Parameters.AddWithValue("@Email", client.EMAIL);
                commande.Parameters.AddWithValue("@Adresse", client.ADRESSE);
                commande.Parameters.AddWithValue("@Ville", client.VILLE);
                commande.Parameters.AddWithValue("@Code_Postal", client.CODE_POSTAL);
                commande.Parameters.AddWithValue("@Id", Convert.ToInt32(client.ID));

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
                requete = "delete from client where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id", Convert.ToString(id));

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
        public List<Commercial> GetCommercial()
        {
            try
            {
                requete = "select * from commercial";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Commercial> cCommercials = new List<Commercial>();

                while (resultat.Read())
                {
                    Commercial tmpCommercial = new Commercial
                        (
                            Convert.ToInt32(resultat["id"]),
                            Convert.ToString(resultat["nom"]),
                            Convert.ToString(resultat["prenom"]),
                            Convert.ToString(resultat["telephone"]),
                            Convert.ToString(resultat["email"])
                        );

                    cCommercials.Add(tmpCommercial);
                }

                connexion.Close();

                return cCommercials;
            }
            catch (Exception ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetCommercial " + ex.Message);
                return new List<Commercial>();
            }
        }
        #endregion

        #region Créer
        public void PostCommercial(Commercial commercial)
        {
            try
            {
                requete = "INSERT INTO commercial(nom, prenom, telephone, email) VALUES (@Nom, @Prenom, @Telephone, @Email)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", commercial.NOM);
                commande.Parameters.AddWithValue("@Prenom", commercial.PRENOM);
                commande.Parameters.AddWithValue("@Telephone", commercial.TELEPHONE);
                commande.Parameters.AddWithValue("@Email", commercial.EMAIL);

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
        public void PutCommercial(Commercial commercial)
        {
            try
            {
                requete = "update commercial set nom = @Nom, prenom = @Prenom, telephone = @Telephone, email = @Email where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", commercial.NOM);
                commande.Parameters.AddWithValue("@Prenom", commercial.PRENOM);
                commande.Parameters.AddWithValue("@Telephone", commercial.TELEPHONE);
                commande.Parameters.AddWithValue("@Email", commercial.TELEPHONE);
                commande.Parameters.AddWithValue("@Id", commercial.ID);

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
                requete = "delete from commercial where id = @ID";

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

        #region Contact

        #region Lire
        public List<Contact> GetContact()
        {
            try
            {
                requete = "select * from contact";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Contact> list_contacts = new List<Contact>();

                while (resultat.Read())
                {
                    Contact contact = new Contact(
                            Convert.ToInt32(resultat["id"]),
                            Convert.ToString(resultat["nom"]),
                            Convert.ToString(resultat["prenom"]),
                            Convert.ToString(resultat["telephone"]),
                            Convert.ToString(resultat["email"]),
                            Convert.ToString(resultat["adresse"]),
                            Convert.ToString(resultat["ville"]),
                            Convert.ToString(resultat["code_postal"])
                        );

                    list_contacts.Add(contact);
                }

                connexion.Close();

                return list_contacts;
            }
            catch (Exception ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetClient " + ex.Message);
                return new List<Contact>();
            }
        }
        #endregion

        #region Créer
        public void PostContact(Contact contact)
        {
            try
            {
                requete = "INSERT INTO contact(nom, prenom, telephone, email, adresse, ville, code_postal) VALUES (@Nom, @Prenom, @Telephone, @Email, @Adresse, @Ville, @Code_Postal)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", contact.NOM);
                commande.Parameters.AddWithValue("@Prenom", contact.PRENOM);
                commande.Parameters.AddWithValue("@Telephone", contact.TELEPHONE);
                commande.Parameters.AddWithValue("@Email", contact.EMAIL);
                commande.Parameters.AddWithValue("@Adresse", contact.ADRESSE);
                commande.Parameters.AddWithValue("@Ville", contact.VILLE);
                commande.Parameters.AddWithValue("@Code_Postal", contact.CODE_POSTAL);

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
        public void PutContact(Contact contact)
        {
            try
            {
                requete = "update contact set nom = @Nom, prenom = @Prenom, telephone = @Telephone, email = @Email, adresse = @Adresse, ville = @Ville, code_postal = @Code_Postal where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", contact.NOM);
                commande.Parameters.AddWithValue("@Prenom", contact.PRENOM);
                commande.Parameters.AddWithValue("@Telephone", contact.TELEPHONE);
                commande.Parameters.AddWithValue("@Email", contact.EMAIL);
                commande.Parameters.AddWithValue("@Adresse", contact.ADRESSE);
                commande.Parameters.AddWithValue("@Ville", contact.VILLE);
                commande.Parameters.AddWithValue("@Code_Postal", contact.CODE_POSTAL);
                commande.Parameters.AddWithValue("@Id", Convert.ToInt32(contact.ID));

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

        #endregion

        #region Rendez-vous

        #region Lire
        public List<Rendez_Vous> GetRdv()
        {
            try
            {
                requete = "select * from rendez-vous";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Rendez_Vous> cRendez_Vous = new List<Rendez_Vous>();

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