using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Application_Lourde_CRM
{
    public class MySql_Database
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
            string chaine_connexion = "server=" + serveur + ";userid=" + user + ";password=" + password + ";database=" + database + "; Convert Zero Datetime=true; persist security info=True;";

            try
            {
                // Instancie un objet MySqlConnection pour gère les connexions à la base de donnée
                connexion = new MySqlConnection(chaine_connexion);

                //Test de connexion à la base de donnée
                connexion.Open();

                MessageBox.Show("Connexion réussit", "succès MySql", MessageBoxButton.OK);

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                //Gestion des exceptions
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

                List<Commercial> list_commercials = new List<Commercial>();

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

                    list_commercials.Add(tmpCommercial);
                }

                connexion.Close();

                return list_commercials;
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

                List<Contact> list_contact = new List<Contact>();

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

                    list_contact.Add(contact);
                }

                connexion.Close();

                return list_contact;
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

        #region Supprimer
        public void DeleteContact(int id)
        {
            try
            {
                requete = "delete from contact where id = @ID";

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

        #region Produit

        #region Lire
        public List <Produit> GetProduit()
        {
            try
            {
                requete = "select * from produit";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Produit> list_produit = new List<Produit>();

                while(resultat.Read())
                {
                    Produit produit = new Produit(
                            Convert.ToInt32(resultat["id"]),
                            Convert.ToString(resultat["nom"]),
                            Convert.ToString(resultat["description"]),
                            Convert.ToDouble(resultat["prix"])
                        );

                    list_produit.Add(produit);
                }

                connexion.Close();

                return list_produit;
            }
            catch(MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetProduit " + ex.Message);
                return new List<Produit>();
            }
        }
        #endregion

        #region Créer
        public void PostProduit(Produit produit)
        {
            try
            {
                requete = "INSERT INTO contact(nom, prix, description) VALUES (@Nom, @Prix, @Description)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", produit.NOM);
                commande.Parameters.AddWithValue("@Prix", produit.PRIX);
                commande.Parameters.AddWithValue("@Description", produit.DESCRIPTION);

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch(MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PostClient " + ex.Message);
            }
        }
        #endregion

        #region Modifier
        public void PutProduit(Produit produit)
        {
            try
            {
                requete = "update contact set nom = @Nom, prix = @Prix, description = @Description where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Nom", produit.NOM);
                commande.Parameters.AddWithValue("@Prix", produit.PRIX);
                commande.Parameters.AddWithValue("@Description", produit.DESCRIPTION);
                commande.Parameters.AddWithValue("@Id", produit.ID);

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
        public void DeleteProduit(int id)
        {
            try
            {
                requete = "delete from produit where id = @ID";

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

        #region Cible
        
        public Rendez_Vous GetTarget(int ID)
        {
            try
            {
                requete = "select rendez_vous.id, rendez_vous.date_heure, rendez_vous.id_commercial, rendez_vous.id_contact, rendez_vous.lieux,commercial.nom as nom_commercial, commercial.prenom as prenom_commercial, commercial.telephone as telephone_commercial, commercial.email as email_commercial, contact.nom as nom_contact, contact.prenom as prenom_contact, contact.telephone as telephone_contact, contact.email as email_contact, contact.adresse as adresse_contact, contact.ville as ville_contact, contact.code_postal as code_postal_contact from rendez_vous INNER JOIN commercial ON rendez_vous.id_commercial = commercial.id INNER JOIN contact ON rendez_vous.id_contact = contact.id WHERE rendez_vous.id = @ID;";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                Rendez_Vous rendez_vous = null;
                Commercial commercial = null;
                Contact contact = null;

                while (resultat.Read())
                {
                    commercial = new Commercial(
                        Convert.ToInt32(resultat["id_commercial"]),
                        Convert.ToString(resultat["nom_commercial"]),
                        Convert.ToString(resultat["prenom_commercial"]),
                        Convert.ToString(resultat["telephone_commercial"]),
                        Convert.ToString(resultat["email_commercial"])
                    );

                    contact = new Contact(
                        Convert.ToInt32(resultat["id_contact"]),
                        Convert.ToString(resultat["nom_contact"]),
                        Convert.ToString(resultat["prenom_contact"]),
                        Convert.ToString(resultat["telephone_contact"]),
                        Convert.ToString(resultat["email_contact"]),
                        Convert.ToString(resultat["adresse_contact"]),
                        Convert.ToString(resultat["ville_contact"]),
                        Convert.ToString(resultat["code_postal_contact"])
                    );

                    rendez_vous = new Rendez_Vous
                        (
                            Convert.ToInt32(resultat["id"]),
                            Convert.ToDateTime(resultat["date_heure"]),
                            commercial,
                            contact,
                            Convert.ToString(resultat["lieux"])
                        );
                }

                return rendez_vous;
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetTarget " + ex.Message);
                return new Rendez_Vous();
            }
        }
        
        #endregion

        #region Lire
        public List<Rendez_Vous> GetRdv()
        {
            try
            {
                requete = "select rendez_vous.id, rendez_vous.date_heure, rendez_vous.id_commercial, rendez_vous.id_contact, rendez_vous.lieux,commercial.nom as nom_commercial, commercial.prenom as prenom_commercial, commercial.telephone as telephone_commercial, commercial.email as email_commercial, contact.nom as nom_contact, contact.prenom as prenom_contact, contact.telephone as telephone_contact, contact.email as email_contact, contact.adresse as adresse_contact, contact.ville as ville_contact, contact.code_postal as code_postal_contact from rendez_vous INNER JOIN commercial ON rendez_vous.id_commercial = commercial.id INNER JOIN contact ON rendez_vous.id_contact = contact.id;";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Rendez_Vous> cRendez_Vous = new List<Rendez_Vous>();

                while (resultat.Read())
                {
                    Commercial commercial = new Commercial(
                            Convert.ToInt32(resultat["id_commercial"]), 
                            Convert.ToString(resultat["nom_commercial"]), 
                            Convert.ToString(resultat["prenom_commercial"]), 
                            Convert.ToString(resultat["telephone_commercial"]), 
                            Convert.ToString(resultat["email_commercial"])
                        );

                    Contact contact = new Contact(
                            Convert.ToInt32(resultat["id_contact"]),
                            Convert.ToString(resultat["nom_contact"]),
                            Convert.ToString(resultat["prenom_contact"]),
                            Convert.ToString(resultat["telephone_contact"]),
                            Convert.ToString(resultat["email_contact"]),
                            Convert.ToString(resultat["adresse_contact"]),
                            Convert.ToString(resultat["ville_contact"]),
                            Convert.ToString(resultat["code_postal_contact"])
                        );

                    Rendez_Vous Rendez_Vous = new Rendez_Vous
                        (
                            Convert.ToInt32(resultat["id"]),
                            Convert.ToDateTime(resultat["date_heure"]),
                            commercial,
                            contact,
                            Convert.ToString(resultat["lieux"])
                        );



                    cRendez_Vous.Add(Rendez_Vous);
                }

                connexion.Close();

                return cRendez_Vous;
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetRdv " + ex.Message);
                return new List<Rendez_Vous>();
            }
        }
        #endregion

        #region Créer
        public void PostRdv(Rendez_Vous rendez_vous)
        {
            try
            {
                requete = "INSERT INTO rendez_vous(date_heure, id_commercial, id_contact, lieux) VALUES (@Date_Heure, @Id_Commercial, @Id_Contact, @lieux)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Date_Heure", rendez_vous.DATE);
                commande.Parameters.AddWithValue("@Id_Commercial", rendez_vous.COMMERCIAL.ID);
                commande.Parameters.AddWithValue("@Id_Contact", rendez_vous.CONTACT.ID);
                commande.Parameters.AddWithValue("@lieux", rendez_vous.LIEUX);

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
        public void PutRdv(Rendez_Vous rendez_Vous)
        {
            try
            {
                requete = "update rendez_vous set date_heure = @Date_Heure, id_commercial = @Id_Commercial, id_contact = @Id_Contact, lieux = @lieux where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Date_Heure", rendez_Vous.DATE);
                commande.Parameters.AddWithValue("@Id_Commercial", rendez_Vous.COMMERCIAL.ID);
                commande.Parameters.AddWithValue("@Id_Contact", rendez_Vous.CONTACT.ID);
                commande.Parameters.AddWithValue("@Id", rendez_Vous.ID);
                commande.Parameters.AddWithValue("@lieux", rendez_Vous.LIEUX);

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
                requete = "delete from rendez_vous where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id", id);

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
            try
            {
                requete = "SELECT facture.id, facture.id_client, facture.id_produit, facture.quantite, facture.date_heure, facture.montant, client.nom as nom_client, client.prenom as prenom_client, client.telephone as telephone_client, client.email as email_client, client.adresse as adresse_client, client.ville as ville_client, client.code_postal as code_postal_client, produit.nom as nom_produit, produit.prix as prix_produit, produit.description as description_produit FROM `facture` INNER JOIN client ON facture.id_client = client.id INNER JOIN produit ON facture.id_produit = produit.id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<Facture> list_facture = new List<Facture>();

                while (resultat.Read())
                {
                    Client client = new Client(
                            Convert.ToInt32(resultat["id_client"]),
                            Convert.ToString(resultat["nom_client"]),
                            Convert.ToString(resultat["prenom_client"]),
                            Convert.ToString(resultat["telephone_client"]),
                            Convert.ToString(resultat["email_client"]),
                            Convert.ToString(resultat["adresse_client"]),
                            Convert.ToString(resultat["ville_client"]),
                            Convert.ToString(resultat["code_postal_client"])
                        );

                    Produit produit = new Produit(
                            Convert.ToInt32(resultat["id_produit"]),
                            Convert.ToString(resultat["nom_produit"]),
                            Convert.ToString(resultat["description_produit"]),
                            Convert.ToDouble(resultat["prix_produit"])
                        );

                    Facture facture = new Facture(
                            Convert.ToInt32(resultat["id"]),
                            client,
                            produit,
                            Convert.ToInt32(resultat["quantite"]),
                            Convert.ToDateTime(resultat["date_heure"]),
                            Convert.ToDouble(resultat["montant"])
                        );

                    list_facture.Add(facture);
                }

                connexion.Close();

                return list_facture;
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
                requete = "INSERT INTO `facture`(`id_client`, `id_produit`, `quantite`, `date_heure`, `montant`) VALUES (@Id_Client, @Id_Produit, @Quantite, @Date_Heure, @Montant)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id_Client", facture.CLIENT.ID);
                commande.Parameters.AddWithValue("@Id_Produit", facture.PRODUIT.ID);
                commande.Parameters.AddWithValue("@Quantite", facture.QUANTITE);
                commande.Parameters.AddWithValue("@Date_Heure", facture.DATE);
                commande.Parameters.AddWithValue("@Montant", facture.MONTANT);

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
        public void PutFacture(Facture facture)
        {
            try
            {
                requete = "update facture set id_client = @Id_Client, id_produit = @Id_Produit, quantite = @Quantite, date_heure = @Date_Heure montant = @Montant where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id_Client", facture.CLIENT.ID);
                commande.Parameters.AddWithValue("@Id_Produit", facture.PRODUIT.ID);
                commande.Parameters.AddWithValue("@Quantite", facture.QUANTITE);
                commande.Parameters.AddWithValue("@Date_Heure", facture.DATE);
                commande.Parameters.AddWithValue("@Montant", facture.MONTANT);
                commande.Parameters.AddWithValue("@Id", facture.ID);

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
        public void DeleteFacture(int id)
        {
            try
            {
                requete = "delete from facture where id = @Id";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Id", id);

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

        #region User
        #endregion

        #endregion
    }
}