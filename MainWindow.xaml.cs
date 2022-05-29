using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;

namespace Application_Lourde_CRM
{
        public partial class MainWindow : Window
        {
            MySql_Database database = new MySql_Database();

            List<Prospect> list_prospects = null;
            List<Client> list_client = null;
            List<Commercial> list_commercials = null;
            List<Rendez_Vous> list_rendez_vous = null;
            List<Facture> list_factures = null;
            List<Contact> list_contact = null;
            List<Produit> list_produit = null;

            Prospect prospect = null;
            Client client = null;
            Commercial commercial = null;
            Rendez_Vous rendez_vous = null;
            Facture facture = null;
            Produit produit = null;
            Contact contact = null;

            public MainWindow()
            {
                InitializeComponent();

                string SettingsFile = "Settings.xml";

                if (File.Exists(SettingsFile))
                {
                    string hote;
                    string bdd;
                    string user;
                    string mdp;

                    try
                    {
                        hote = File.ReadLines(SettingsFile).Skip(2).Take(1).First();
                    }
                    catch (Exception ex)
                    {
                        hote = "";
                    }

                    try
                    {
                        bdd = File.ReadLines(SettingsFile).Skip(3).Take(1).First();
                    }
                    catch (Exception ex)
                    {
                        bdd= "";
                    }

                    try
                    {
                        user = File.ReadLines(SettingsFile).Skip(4).Take(1).First();
                    }
                    catch (Exception ex)
                    {
                        user = "";
                    }

                    try
                    {
                        mdp = File.ReadLines(SettingsFile).Skip(5).Take(1).First();
                    }
                    catch (Exception ex)
                    {
                        mdp = "";
                    }
                    
                    database = new MySql_Database(hote, user, mdp, bdd);
                }

                //Collection
                list_prospects = database.GetProspect();
                list_client = database.GetClient();
                list_commercials = database.GetCommercial();
                list_contact = database.GetContact();
                list_rendez_vous = database.GetRdv();
                list_factures = database.GetFacture();
                list_produit = database.GetProduit();

                //DataGrid
                DataGrid_Prospects.ItemsSource = list_prospects;
                DataGrid_Clients.ItemsSource = list_client;
                DataGrid_Commercials.ItemsSource = list_commercials;
                DataGrid_Contact.ItemsSource = list_contact;
                DataGrid_Produits.ItemsSource = list_produit;
                DataGrid_Facture.ItemsSource = list_factures;

                DataGrid_Facture.ItemsSource = list_factures;
                DataGrid_RendezVous.ItemsSource = list_rendez_vous;

                // Combox box
                cboContact.ItemsSource = list_contact;
                cboCommercial.ItemsSource = list_commercials;
                cboProduit.ItemsSource = list_produit;
                cboClient.ItemsSource = list_client;
            }
        
            #region Prospects

            #region Actualiser
            private void refreshProspect()
            {
                list_prospects = database.GetProspect();
                DataGrid_Prospects.ItemsSource = list_prospects;
            }
            #endregion

            #region Sélection
            private void DataGrid_Prospects_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (DataGrid_Prospects.SelectedItem != null)
                {
                    prospect = (Prospect)DataGrid_Prospects.SelectedItem;

                    txtIdPro.Text = Convert.ToString(prospect.ID);
                    txtNomPro.Text = Convert.ToString(prospect.NOM);
                    txtPrenomPro.Text = Convert.ToString(prospect.PRENOM);
                    txtTelPro.Text = Convert.ToString(prospect.TELEPHONE);
                    txtMailPro.Text = Convert.ToString(prospect.EMAIL);
                    txtAdressePro.Text = Convert.ToString(prospect.ADRESSE);
                    txtVillePro.Text = Convert.ToString(prospect.VILLE);
                    txtCpPro.Text = Convert.ToString(prospect.CODE_POSTAL);
                }
                else
                {
                    txtIdPro.Text = "";
                    txtNomPro.Text = "";
                    txtPrenomPro.Text = "";
                    txtMailPro.Text = "";
                    txtTelPro.Text = "";
                    txtAdressePro.Text = "";
                    txtVillePro.Text = "";
                    txtCpPro.Text = "";
                }
            }
            #endregion

            #region Ajout Prospects
            private void btnAjouterPro_Click(object sender, RoutedEventArgs e)
            {
                prospect = new Prospect(txtNomPro.Text, txtPrenomPro.Text, txtTelPro.Text, txtMailPro.Text, txtAdressePro.Text, txtVillePro.Text, txtCpPro.Text);

                database.PostProspect(prospect);
                refreshProspect();
            }
            #endregion

            #region Modifier
            private void btnModifierPro_Click(object sender, RoutedEventArgs e)
            {
                prospect = new Prospect(txtNomPro.Text, txtPrenomPro.Text, txtTelPro.Text, txtMailPro.Text, txtAdressePro.Text, txtVillePro.Text, txtCpPro.Text);

                database.PutProspect(prospect);
                refreshProspect();
            }
            #endregion

            #region Supprimer
            private void btnSupprimerPro_Click(object sender, RoutedEventArgs e)
            {
                if(DataGrid_Prospects.SelectedItem != null)
                {
                    database.DeleteProspect(Convert.ToInt32(txtIdPro.Text));
                    refreshProspect();
                }
            }
            #endregion

            #endregion

            #region Clients

            #region Actualiser
            private void refreshClients()
            {
                list_client = database.GetClient();
                DataGrid_Clients.ItemsSource = list_client;
            }
            #endregion

            #region Sélection
            private void DataGrid_Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (DataGrid_Clients.SelectedItem != null)
                {
                    client = (Client)DataGrid_Clients.SelectedItem;

                    txtIdCli.Text = Convert.ToString(client.ID);
                    txtNomCli.Text = Convert.ToString(client.NOM);
                    txtPrenomCli.Text = Convert.ToString(client.PRENOM);
                    txtMailCli.Text = Convert.ToString(client.EMAIL);
                    txtTelCli.Text = Convert.ToString(client.TELEPHONE);
                    txtAdresseCli.Text = Convert.ToString(client.ADRESSE);
                    txtVilleCli.Text = Convert.ToString(client.VILLE);
                    txtCpCli.Text = Convert.ToString(client.CODE_POSTAL);
                }
                else
                {
                    txtIdCli.Text = "";
                    txtNomCli.Text = "";
                    txtPrenomCli.Text = "";
                    txtMailCli.Text = "";
                    txtTelCli.Text = "";
                    txtAdresseCli.Text = "";
                    txtVilleCli.Text = "";
                    txtCpCli.Text = "";
                }
            }
            #endregion

            #region Ajouter
            private void btnAjouterCli_Click(object sender, RoutedEventArgs e)
            {
                client = new Client(txtNomCli.Text, txtPrenomCli.Text, txtTelCli.Text, txtMailCli.Text, txtAdresseCli.Text, txtVilleCli.Text, txtCpCli.Text);

                database.PostClient(client);
                refreshClients();
            }
            #endregion

            #region Modifier
            private void btnModifierCli_Click(object sender, RoutedEventArgs e)
            {
                client = new Client(Convert.ToInt32(txtIdCli.Text), txtNomCli.Text, txtPrenomCli.Text, txtTelCli.Text, txtMailCli.Text, txtAdresseCli.Text, txtVilleCli.Text, txtCpCli.Text);

                database.PutClient(client);
                refreshClients();
            }
            #endregion

            #region Supprimer
            private void btnSupprimerCli_Click(object sender, RoutedEventArgs e)
            {
                if(DataGrid_Clients.SelectedItem != null)
                {
                    database.DeleteClient(Convert.ToInt32(txtIdCli.Text));
                    refreshClients();
                }
            }
            #endregion

            #endregion

            #region Commercials

            #region Actualiser
            private void refreshCommercials()
            {
                list_commercials = database.GetCommercial();
                DataGrid_Commercials.ItemsSource = list_commercials;
            }
            #endregion

            #region Sélection
            private void DataGrid_Commercials_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (DataGrid_Commercials.SelectedItem != null)
                {
                    commercial = (Commercial)DataGrid_Commercials.SelectedItem;

                    txtIdCom.Text = Convert.ToString(commercial.ID);
                    txtNomCom.Text = Convert.ToString(commercial.NOM);
                    txtPrenomCom.Text = Convert.ToString(commercial.PRENOM);
                    txtMailCom.Text = Convert.ToString(commercial.EMAIL);
                    txtTelCom.Text = Convert.ToString(commercial.TELEPHONE);
                }
                else
                {
                    txtIdCom.Text = "";
                    txtNomCom.Text = "";
                    txtPrenomCom.Text = "";
                    txtMailCom.Text = "";
                    txtTelCom.Text = "";
                }
            }
            #endregion

            #region Ajouter
            private void btnAjouterCom_Click(object sender, RoutedEventArgs e)
            {
                commercial = new Commercial(txtNomCom.Text, txtPrenomCom.Text, txtTelCom.Text, txtMailCom.Text);
                
                database.PostCommercial(commercial);

                refreshCommercials();
            }
            #endregion

            #region Modifier
            private void btnModifierCom_Click(object sender, RoutedEventArgs e)
            {
                commercial = new Commercial(Convert.ToInt32(txtIdCom.Text), txtNomCom.Text, txtPrenomCom.Text, txtTelCom.Text, txtMailCom.Text);

                database.PutCommercial(commercial);
                refreshCommercials();
            }
            #endregion

            #region Supprimer
            private void btnSupprimerCom_Click(object sender, RoutedEventArgs e)
            {
                if(DataGrid_Commercials.SelectedItem != null)
                {
                    database.DeleteCommercial(Convert.ToInt32(txtIdCom.Text));
                    refreshCommercials();
                }
            }
            #endregion

            #endregion

            #region Rendez_Vous

            #region Actualiser
            private void refreshRendez_Vous()
            {
                list_rendez_vous = database.GetRdv();
                DataGrid_RendezVous.ItemsSource = list_rendez_vous;
            }
            #endregion

            #region Sélection
            private void DataGrid_RendezVous_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (DataGrid_RendezVous.SelectedItem != null)
                {
                    rendez_vous = (Rendez_Vous)DataGrid_RendezVous.SelectedItem;

                    txtIdRdv.Text = Convert.ToString(rendez_vous.ID);
                    txtDateRdv.Text = Convert.ToString(rendez_vous.DATE);
                    cboCommercial.Text = Convert.ToString(rendez_vous.COMMERCIAL);
                    cboContact.Text = Convert.ToString(rendez_vous.CONTACT);
                    
                }
                else
                {
                    txtIdRdv.Text = "";
                    txtDateRdv.Text = "";
                    cboCommercial.Text = "";
                    cboContact.Text = "";
                }
            }
            #endregion

            #region Ajouter
            private void ButtonAjouterRdv_Click(object sender, RoutedEventArgs e)
            {
                commercial = (Commercial)cboCommercial.SelectedItem;
                contact = (Contact)cboContact.SelectedItem;

                rendez_vous = new Rendez_Vous(Convert.ToInt32(txtIdRdv.Text), Convert.ToDateTime(txtDateRdv.Text), commercial, contact);

                database.PostRdv(rendez_vous);

                refreshRendez_Vous();
            }
            #endregion

            #region Modifier
            private void ButtonModifierRdv_Click(object sender, RoutedEventArgs e)
            {
                commercial = (Commercial)cboCommercial.SelectedItem;
                contact = (Contact)cboContact.SelectedItem;

                rendez_vous = new Rendez_Vous(Convert.ToInt32(txtIdRdv.Text), Convert.ToDateTime(txtDateRdv.Text), commercial, contact);

                database.PutRdv(rendez_vous);
                refreshRendez_Vous();
            }
            #endregion

            #region Supprimer
            private void ButtonSupprimerRdv_Click(object sender, RoutedEventArgs e)
            {
                if(DataGrid_RendezVous.SelectedItem != null)
                {
                    database.DeleteRdv(Convert.ToInt32(txtIdRdv.Text));
                    refreshRendez_Vous();
                }
            }
            #endregion

            #endregion

            #region Facture

            #region Actualiser
            private void refreshFacture()
            {
                list_factures = database.GetFacture();
                DataGrid_Facture.ItemsSource = list_factures;
            }
            #endregion

            #region Sélection
            private void DataGrid_Facture_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (DataGrid_Facture.SelectedItem != null)
                {
                    facture = (Facture)DataGrid_Facture.SelectedItem;

                    cboProduit.Text = Convert.ToString(facture.PRODUIT);
                    cboClient.Text = Convert.ToString(facture.CLIENT);
                    txtDateFactures.Text = Convert.ToString(facture.DATE);
                    txtIdFact.Text = Convert.ToString(facture.ID);
                    txtQuantiteFact.Text = Convert.ToString(facture.QUANTITE);
                    txtMontantFact.Text = Convert.ToString(facture.MONTANT);
                }
                else
                {
                    cboProduit.Text = "";
                    cboClient.Text = "";
                    txtDateFactures.Text = "";
                    txtIdFact.Text = "";
                    txtQuantiteFact.Text = "";
                    txtMontantFact.Text = "";
                }
            }
            #endregion

            #region Ajouter
            private void btnAjouterFactures_Click(object sender, RoutedEventArgs e)
            {
                produit = (Produit)cboProduit.SelectedItem;
                client = (Client)cboClient.SelectedItem;
                
                int quantite = Convert.ToInt32(txtQuantiteFact.Text);
                double montant = quantite * produit.PRIX;

                txtMontantFact.Text = Convert.ToString(montant);

                facture = new Facture(client, produit, quantite, Convert.ToDateTime(txtDateFactures.Text), montant);

                database.PostFacture(facture);

                refreshFacture();
            }
            #endregion

            #region Modifier
            private void btnModifierFactures_Click(object sender, RoutedEventArgs e)
            {
                produit = (Produit)cboProduit.SelectedItem;
                client = (Client)cboClient.SelectedItem;

                int quantite = Convert.ToInt32(txtQuantiteFact.Text);
                double montant = 0;

                montant = quantite * produit.PRIX;

                txtMontantFact.Text = Convert.ToString(montant);

                facture = new Facture(client, produit, quantite, Convert.ToDateTime(txtDateFactures.Text), montant);

                database.PutFacture(facture);
                refreshFacture();
            }
            #endregion

            #region Supprimer
            private void btnSupprimerFactures_Click(object sender, RoutedEventArgs e)
            {
                if(DataGrid_Facture.SelectedItem != null)
                {
                    database.DeleteFacture(Convert.ToInt32(txtIdFact.Text));
                    refreshFacture();
                }
            }
            #endregion

            #region Autre
            private void txtQuantiteFact_TextChanged(object sender, TextChangedEventArgs e)
            {
                if(null != (produit = (Produit)cboProduit.SelectedItem))
                {
                    double montant = Convert.ToInt32(txtQuantiteFact.Text) * produit.PRIX;

                    txtMontantFact.Text = Convert.ToString(montant);
                }
                else
                {
                    txtMontantFact.Text = "?";
                }
            }
            #endregion

            #endregion

            #region Contact

            #region Actualiser
            private void refreshContact()
            {
                list_contact = database.GetContact();
                DataGrid_Contact.ItemsSource = list_contact;
            }
            #endregion

            #region Sélection
            private void DataGrid_Contact_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (DataGrid_Contact.SelectedItem != null)
                {
                    contact = (Contact)DataGrid_Contact.SelectedItem;

                    txtIdContact.Text = Convert.ToString(contact.ID);
                    txtNomContact.Text = Convert.ToString(contact.NOM);
                    txtPrenomContact.Text = Convert.ToString(contact.PRENOM);
                    txtMailContact.Text = Convert.ToString(contact.EMAIL);
                    txtTelContact.Text = Convert.ToString(contact.TELEPHONE);
                    txtAdresseContact.Text = Convert.ToString(contact.ADRESSE);
                    txtVilleContact.Text = Convert.ToString(contact.VILLE);
                    txtCpContact.Text = Convert.ToString(contact.CODE_POSTAL);
                }
                else
                {
                    txtIdContact.Text = "";
                    txtNomContact.Text = "";
                    txtPrenomContact.Text = "";
                    txtMailContact.Text = "";
                    txtTelContact.Text = "";
                    txtAdresseContact.Text = "";
                    txtVilleContact.Text = "";
                    txtCpContact.Text = "";
                }
            }
            #endregion

            #region Ajouter
            private void btnAjouterContact_Click(object sender, RoutedEventArgs e)
            {
                contact = new Contact(txtNomContact.Text, txtPrenomContact.Text, txtTelContact.Text, txtMailContact.Text, Convert.ToString(txtAdresseContact), Convert.ToString(txtVilleContact), Convert.ToString(txtCpContact));

                database.PostContact(contact);

                refreshContact();
            }
            #endregion

            #region Modifier
            private void btnModifierContact_Click(object sender, RoutedEventArgs e)
            {
                contact = new Contact(Convert.ToInt32(txtIdCom.Text), txtNomCom.Text, txtPrenomCom.Text, txtTelCom.Text, txtMailCom.Text,Convert.ToString(txtAdresseContact), Convert.ToString(txtVilleContact), Convert.ToString(txtCpContact));

                database.PutContact(contact);
                refreshContact();
            }
            #endregion

            #region Supprimer
            private void btnSupprimerContact_Click(object sender, RoutedEventArgs e)
            {
                if(DataGrid_Contact.SelectedItem != null)
                {
                    database.DeleteContact(Convert.ToInt32(txtIdContact.Text));
                    refreshContact();
                }
            }
            #endregion

            #endregion

            #region Produit

            #region Actualiser
            private void refreshProduit()
            {
                list_produit = database.GetProduit();
                DataGrid_Produits.ItemsSource = list_produit;
            }
            #endregion

            #region Sélection
            private void DataGrid_Produit_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if(DataGrid_Produits.SelectedItem != null)
                {
                    produit = (Produit)DataGrid_Produits.SelectedItem;

                    txtIdProduit.Text = Convert.ToString(produit.ID);
                    txtNomProduit.Text = Convert.ToString(produit.NOM);
                    txtDescriptionProd.Text = Convert.ToString(produit.DESCRIPTION);
                    txtPrixProd.Text = Convert.ToString(produit.PRIX);
                }
                else
                {
                    txtIdProduit.Text = "";
                    txtNomPro.Text = "";
                    txtDescriptionProd.Text = "";
                    txtPrixProd.Text = "";
                }
            }
            #endregion

            #region Ajouter
            private void btnAjouterProd_Click(object sender, RoutedEventArgs e)
            {
                produit = new Produit(txtNomPro.Text, txtDescriptionProd.Text, Convert.ToDouble(txtPrixProd.Text));

                database.PostProduit(produit);

                refreshProduit();
            }
            #endregion

            #region Modifier
            private void btnModifierProd_Click(object sender, RoutedEventArgs e)
            {
                produit = new Produit(Convert.ToInt32(txtIdProduit.Text), txtNomProduit.Text, txtDescriptionProd.Text, Convert.ToDouble(txtPrixProd.Text));

                database.PutProduit(produit);
                refreshProduit();
            }
            #endregion

            #region Supprimer
            private void btnSupprimerProd_Click(object sender, RoutedEventArgs e)
            {
                database.DeleteProduit(Convert.ToInt32(txtIdProduit.Text));
                refreshProduit();
            }
            #endregion

            #endregion

            #region Autres
            void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
            {
                Regex regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
                e.Handled = !regex.IsMatch(e.Text);
            }

            private void btnSettings_Click(object sender, RoutedEventArgs e)
            {
                Settings Settings = new Settings();
                Settings.ShowDialog();
            }
        #endregion
        }
}