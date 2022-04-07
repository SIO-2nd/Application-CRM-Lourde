using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Application_Lourde_CRM
{
    class Database
    {
        private static SqlConnection connection;
        public static void Initialize()
        {
            // Connexion à la base de donnée.
            connection = new SqlConnection("Server=srvSQL-ubuntu; Database=Infotools; Integrated Security=True;");
            try
            {
                connection.Open();
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return;
            }
        }

        #region Prospect

        #region Lire
        public static List<Prospects> GetProspect()
        {
            try
            {
                // Création de la requète SQL.
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from prospect";

                //Lecture de la requète et ajout à une liste.
                SqlDataReader dataReader = command.ExecuteReader();
                List<Prospects> cProspect = new List<Prospects>();
                while (dataReader.Read())
                {
                    Prospects tmpProspect = new Prospects(
                        Convert.ToInt32(dataReader["Id"]),
                        Convert.ToString(dataReader["NomPro"]),
                        Convert.ToString(dataReader["PrePro"]),
                        Convert.ToString(dataReader["MailPro"]),
                        Convert.ToInt32(dataReader["TelPro"]),
                        Convert.ToString(dataReader["AdrPro"]),
                        Convert.ToString(dataReader["VillePro"]),
                        Convert.ToInt32(dataReader["CPPro"])
                    );
                    cProspect.Add(tmpProspect);
                }
                dataReader.Close();
                return cProspect;
            }
            catch
            {
                Console.WriteLine("Erreur GetProspects");
                return new List<Prospects>();
            }
        }
        #endregion

        #region Créer
        public static void PostProspect(Prospects pro)
        {
            try
            {
                String requete = "INSERT INTO prospect(NomPro, PrePro, MailPro, TelPro, AdrPro, VillePro, CpPro) VALUES (@Nom, @Prenom, @Email, @Telephone, @Adresse, @Ville, @Code_Postal)";

                SqlCommand command = new SqlCommand(requete, connection);

                command.Parameters.AddWithValue("@Id", Convert.ToString(pro.Id));
                command.Parameters.AddWithValue("@Nom", pro.Nom);
                command.Parameters.AddWithValue("@Prenom", pro.Prenom);
                command.Parameters.AddWithValue("@Email", pro.Email);
                command.Parameters.AddWithValue("@Telephone", Convert.ToString(pro.Telephone));
                command.Parameters.AddWithValue("@Adresse", pro.Adresse);
                command.Parameters.AddWithValue("@Ville", pro.Ville);
                command.Parameters.AddWithValue("@Code_Postal", Convert.ToString(pro.Code_Postal));

                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur PostProspect");
            }
        }
        #endregion

        #region Modifier
        public static void PutProspect(Prospects pro)
        {
            try
            {
                String requete = "update prospect set NomPro = @Nom, PrePro = @Prenom, MailPro = @Email, TelPro = @Telephone, AdrPro = @Adresse, VillePro = @Ville, CpPro = @Code_Postal where Id = @Id";

                SqlCommand command = new SqlCommand(requete, connection);

                command.Parameters.AddWithValue("@Id", Convert.ToString(pro.Id));
                command.Parameters.AddWithValue("@Nom", Convert.ToString(pro.Nom));
                command.Parameters.AddWithValue("@Prenom", Convert.ToString(pro.Prenom));
                command.Parameters.AddWithValue("@Email", Convert.ToString(pro.Email));
                command.Parameters.AddWithValue("@Telephone", Convert.ToInt32(pro.Telephone));
                command.Parameters.AddWithValue("@Adresse", Convert.ToString(pro.Adresse));
                command.Parameters.AddWithValue("@Ville", Convert.ToString(pro.Ville));
                command.Parameters.AddWithValue("@Code_Postal", Convert.ToInt32(pro.Code_Postal));

                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur PutProspect");
            }
        }
        #endregion

        #region Supprimer
        public static void DeleteProspect(string id)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "delete from prospect where id = " + id;
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur DeleteProspect");
            }
        }
        #endregion

        #endregion

        #region Client

        #region Lire
        public static List<Client> GetClient()
        {
            try
            {
                // Création de la requète SQL.
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from client";

                //Lecture de la requète et ajout à une liste.
                SqlDataReader dataReader = command.ExecuteReader();
                List<Client> cClient = new List<Client>();
                while (dataReader.Read())
                {
                    Client tmpClient = new Client(
                        Convert.ToInt32(dataReader["Id"]),
                        Convert.ToString(dataReader["NomCli"]),
                        Convert.ToString(dataReader["PreCli"]),
                        Convert.ToString(dataReader["MailCli"]),
                        Convert.ToInt32(dataReader["TelCli"]),
                        Convert.ToString(dataReader["AdrCli"]),
                        Convert.ToString(dataReader["VilleCli"]),
                        Convert.ToInt32(dataReader["CPCli"])
                    );
                    cClient.Add(tmpClient);
                }
                dataReader.Close();
                return cClient;
            }
            catch
            {
                Console.WriteLine("Erreur GetClient");
                return new List<Client>();
            }
        }
        #endregion

        #region Créer
        public static void PostClient(Client cli)
        {
            try
            {
                String requete = "INSERT INTO client(NomCli, PreCli, MailCli, TelCli, AdrCli, VilleCli, CpCli) VALUES (@Nom, @Prenom, @Email, @Telephone, @Adresse, @Ville, @Code_Postal)";

                SqlCommand command = new SqlCommand(requete, connection);

                command.Parameters.AddWithValue("@Id", Convert.ToString(cli.Id));
                command.Parameters.AddWithValue("@Nom", cli.Nom);
                command.Parameters.AddWithValue("@Prenom", cli.Prenom);
                command.Parameters.AddWithValue("@Email", cli.Email);
                command.Parameters.AddWithValue("@Telephone", Convert.ToString(cli.Telephone));
                command.Parameters.AddWithValue("@Adresse", cli.Adresse);
                command.Parameters.AddWithValue("@Ville", cli.Ville);
                command.Parameters.AddWithValue("@Code_Postal", Convert.ToString(cli.Code_Postal));

                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur PostClient");
            }
        }
        #endregion

        #region Modifier
        public static void PutClient(Client cli)
        {
            try
            {
                String requete = "update client set NomCli = @Nom, PreCli = @Prenom, MailCli = @Email, TelCli = @Telephone, AdrCli = @Adresse, VilleCli = @Ville, CpCli = @Code_Postal where Id = @Id";

                SqlCommand command = new SqlCommand(requete, connection);

                command.Parameters.AddWithValue("@Id", Convert.ToString(cli.Id));
                command.Parameters.AddWithValue("@Nom", Convert.ToString(cli.Nom));
                command.Parameters.AddWithValue("@Prenom", Convert.ToString(cli.Prenom));
                command.Parameters.AddWithValue("@Email", Convert.ToString(cli.Email));
                command.Parameters.AddWithValue("@Telephone", Convert.ToInt32(cli.Telephone));
                command.Parameters.AddWithValue("@Adresse", Convert.ToString(cli.Adresse));
                command.Parameters.AddWithValue("@Ville", Convert.ToString(cli.Ville));
                command.Parameters.AddWithValue("@Code_Postal", Convert.ToInt32(cli.Code_Postal));

                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur PutClient");
            }
        }
        #endregion

        #region Supprimer
        public static void DeleteClient(string id)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "delete from client where id = " + id;
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur DeleteClient");
            }
        }
        #endregion

        #endregion

        #region Commercial

        #region Lire
        public static List<Commercials> GetCommercial()
        {
            try
            {
                // Création de la requète SQL.
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from commercial";

                //Lecture de la requète et ajout à une liste.
                SqlDataReader dataReader = command.ExecuteReader();
                List<Commercials> cCommercial = new List<Commercials>();
                while (dataReader.Read())
                {
                    Commercials tmpCommercial = new Commercials(
                        Convert.ToInt32(dataReader["Id"]),
                        Convert.ToString(dataReader["NomCom"]),
                        Convert.ToString(dataReader["PreCom"]),
                        Convert.ToString(dataReader["MailCom"]),
                        Convert.ToInt32(dataReader["TelCom"])
                    );
                    cCommercial.Add(tmpCommercial);
                }
                dataReader.Close();
                return cCommercial;
            }
            catch
            {
                Console.WriteLine("Erreur GetCommercial");
                return new List<Commercials>();
            }
        }
        #endregion

        #region Créer
        public static void PostCommercial(Commercials com)
        {
            try
            {
                String requete = "INSERT INTO commercial(NomCom, PreCom, MailCom, TelCom) VALUES (@Nom, @Prenom, @Email, @Telephone)";

                SqlCommand command = new SqlCommand(requete, connection);

                command.Parameters.AddWithValue("@Id", Convert.ToString(com.Id));
                command.Parameters.AddWithValue("@Nom", com.Nom);
                command.Parameters.AddWithValue("@Prenom", com.Prenom);
                command.Parameters.AddWithValue("@Email", com.Email);
                command.Parameters.AddWithValue("@Telephone", Convert.ToString(com.Telephone));

                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur PostCommercial");
            }
        }
        #endregion

        #region Modifier
        public static void PutCommercial(Commercials com)
        {
            try
            {
                String requete = "update commercial set NomCom = @Nom, PreCom = @Prenom, MailCom = @Email, TelCom = @Telephone where Id = @Id";

                SqlCommand command = new SqlCommand(requete, connection);

                command.Parameters.AddWithValue("@Id", Convert.ToString(com.Id));
                command.Parameters.AddWithValue("@Nom", Convert.ToString(com.Nom));
                command.Parameters.AddWithValue("@Prenom", Convert.ToString(com.Prenom));
                command.Parameters.AddWithValue("@Email", Convert.ToString(com.Email));
                command.Parameters.AddWithValue("@Telephone", Convert.ToInt32(com.Telephone));

                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur PutCommercial");
            }
        }
        #endregion

        #region Supprimer
        public static void DeleteCommercial(string id)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "delete from commercial where id = " + id;
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur DeleteCommercial");
            }
        }
        #endregion

        #endregion

        #region Rendez-vous

        #region Lire
        public static List<Rendez_vous> GetRdv()
        {
            try
            {
                // Création de la requète SQL.
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from rendez_vous";

                //Lecture de la requète et ajout à une liste.
                SqlDataReader dataReader = command.ExecuteReader();
                List<Rendez_vous> cRendez_vous = new List<Rendez_vous>();

                while (dataReader.Read())
                {
                    string NomPrenom = Convert.ToString(dataReader["Prospect"]);
                    string Nom;
                    string Prenom;
                    bool confirm = false;
                    int compteur = 0;

                    // Si possible mettre une colonne nom et prénom sur SQL afin d'éviter ce genre de calcul
                    for(int i = 0; i<NomPrenom.Length; i++)
                    {
                        if(NomPrenom[i] != ' ' && confirm == false)
                        {
                            Prenom[compteur] = NomPrenom[i];
                            compteur++;
                        }
                        else
                        {
                            if(confirm == false)
                            {
                                confirm = true;
                            }
                        }
                    }
                    Prospects prospects = new Prospects();
                    Commercials commercials = new Commercials();
                    Rendez_vous tmpRdv = new Rendez_vous();
                        Convert.ToInt32(dataReader["Id"]),
                        Convert.ToString(dataReader["Date"]),
                        
                        Convert.ToString(dataReader["Commercial"])
                    );
                    cRendez_vous.Add(tmpRdv);
                }
                dataReader.Close();
                return cRendez_vous;
            }
            catch
            {
                Console.WriteLine("Erreur GetRdv");
                return new List<Rendez_vous>();
            }
        }
        #endregion

        #region Créer
        public static void PostCommercial(Commercials com)
        {
            try
            {
                String requete = "INSERT INTO commercial(NomCom, PreCom, MailCom, TelCom) VALUES (@Nom, @Prenom, @Email, @Telephone)";

                SqlCommand command = new SqlCommand(requete, connection);

                command.Parameters.AddWithValue("@Id", Convert.ToString(com.Id));
                command.Parameters.AddWithValue("@Nom", com.Nom);
                command.Parameters.AddWithValue("@Prenom", com.Prenom);
                command.Parameters.AddWithValue("@Email", com.Email);
                command.Parameters.AddWithValue("@Telephone", Convert.ToString(com.Telephone));

                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur PostCommercial");
            }
        }
        #endregion

        #region Modifier
        public static void PutCommercial(Commercials com)
        {
            try
            {
                String requete = "update commercial set NomCom = @Nom, PreCom = @Prenom, MailCom = @Email, TelCom = @Telephone where Id = @Id";

                SqlCommand command = new SqlCommand(requete, connection);

                command.Parameters.AddWithValue("@Id", Convert.ToString(com.Id));
                command.Parameters.AddWithValue("@Nom", Convert.ToString(com.Nom));
                command.Parameters.AddWithValue("@Prenom", Convert.ToString(com.Prenom));
                command.Parameters.AddWithValue("@Email", Convert.ToString(com.Email));
                command.Parameters.AddWithValue("@Telephone", Convert.ToInt32(com.Telephone));

                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur PutCommercial");
            }
        }
        #endregion

        #region Supprimer
        public static void DeleteCommercial(string id)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "delete from commercial where id = " + id;
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur DeleteCommercial");
            }
        }
        #endregion

        #region Facture

        #region Lire
        public static List<Facture> GetFacture()
        {
            try
            {
                // Création de la requète SQL.
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from facture";

                //Lecture de la requète et ajout à une liste.
                SqlDataReader dataReader = command.ExecuteReader();
                List<Facture> cFacture = new List<Facture>();

                while (dataReader.Read())
                {
                    Client client = new Client(Convert.ToInt32(dataReader["IdCli"]));
                    Achats achats = new Achats(Convert.ToInt32(dataReader["IdAchat"]));

                    Facture facture = new Facture(Convert.ToInt32(dataReader["Id"]), client, achats, Convert.ToDateTime(dataReader["Date"]));

                    cFacture.Add(facture);
                }
                dataReader.Close();
                return cFacture;
            }
            catch
            {
                Console.WriteLine("Erreur GetFacture");
                return new List<Facture>();
            }
        }
        #endregion

        #endregion
    }
}