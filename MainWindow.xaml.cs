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
                list_prospects = database.GetProspect();
                list_client = database.GetClient();
                list_commercials = database.GetCommercial();
                list_rendez_vous = database.GetRdv();
                list_factures = database.GetFacture();
                list_contact = database.GetContact();
                list_produit = database.GetProduit();

                cboContact.ItemsSource = list_contact;
                cboCommercial.ItemsSource = list_commercials;

                DataGrid_Prospects.ItemsSource = list_prospects;
                DataGrid_Clients.ItemsSource = list_client;
                DataGrid_Commercials.ItemsSource = list_commercials;
                DataGrid_Factures.ItemsSource = list_factures;
                //DataGrid_RendezVous.ItemsSource = list_rendez_vous; 
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
                database.DeleteProspect(Convert.ToInt32(txtIdPro.Text));
                refreshProspect();
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
                database.DeleteClient(Convert.ToInt32(txtIdCli.Text));
                refreshClients();
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
                database.DeleteCommercial(Convert.ToInt32(txtIdCom.Text));
                refreshCommercials();
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
                    txtPrenomCli.Text = Convert.ToString(rendez_vous.COMMERCIAL.ID);
                    txtMailCli.Text = Convert.ToString(rendez_vous.COMMERCIAL.ID);
                }
                else
                {
                    txtIdRdv.Text = "";
                txtDateRdv.Text = "";
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
            private void ButtonAjouterRdv_Click(object sender, RoutedEventArgs e)
            {

            }
            #endregion

            #region Modifier
            private void ButtonModifierRdv_Click(object sender, RoutedEventArgs e)
            {

            }
            #endregion

            #region Supprimer
            private void ButtonSupprimerRdv_Click(object sender, RoutedEventArgs e)
            {

            }
            #endregion

            #endregion

            #region Facture

            #region Actualiser
            private void refreshFacture()
            {
                list_factures = database.GetFacture();
                DataGrid_Factures.ItemsSource = list_factures;
            }
            #endregion

            #region Sélection
            private void DataGrid_Factures_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (DataGrid_Factures.SelectedItem != null)
                {
                    Facture factureSelected = (Facture)DataGrid_Factures.SelectedItem;

                    txtIdFact.Text = Convert.ToString(factureSelected.ID);
                    txtIdAchat.Text = Convert.ToString(factureSelected.PRODUIT.ID);
                    txtIdClient.Text = Convert.ToString(factureSelected.CLIENT.ID);
                    txtDtFact.Text = Convert.ToString(factureSelected.DATE);
                }
                else
                {
                    txtIdFact.Text = "";
                    txtIdAchat.Text = "";
                    txtIdClient.Text = "";
                    txtDtFact.Text = "";
                }
            }
        #endregion

        #endregion

            #region Contact

            #region Actualiser
            private void refreshContact()
            {
                list_contact = database.GetContact();
                DataGrid_Contacts.ItemsSource = list_contact;
            }
            #endregion

            #region Sélection
            private void DataGrid_Contact_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (DataGrid_Contacts.SelectedItem != null)
                {
                    contact = (Contact)DataGrid_Commercials.SelectedItem;

                    txtIdCon.Text = Convert.ToString(contact.ID);
                    txtNomCon.Text = Convert.ToString(contact.NOM);
                    txtPrenomCon.Text = Convert.ToString(contact.PRENOM);
                    txtMailCon.Text = Convert.ToString(contact.EMAIL);
                    txtTelCon.Text = Convert.ToString(contact.TELEPHONE);
                    txtAdresseCon.Text = Convert.ToString(contact.ADRESSE);
                    txtVilleCon.Text = Convert.ToString(contact.VILLE);
                    txtCpCon.Text = Convert.ToString(contact.CODE_POSTAL);
                }
                else
                {
                    txtIdCon.Text = "";
                    txtNomCon.Text = "";
                    txtPrenomCon.Text = "";
                    txtMailCon.Text = "";
                    txtTelCon.Text = "";
                    txtAdresseCon.Text = "";
                    txtVilleCon.Text = "";
                    txtCpCon.Text = "";
                }
            }
        #endregion

            #region Ajouter
            private void btnAjouterCon_Click(object sender, RoutedEventArgs e)
            {
                contact = new Contact(txtNomCon.Text, txtPrenomCon.Text, txtTelCon.Text, txtMailCon.Text, Convert.ToString(txtAdresseCon), Convert.ToString(txtVilleCon), Convert.ToString(txtCpCon));

                database.PostContact(contact);

                refreshContact();
            }
        #endregion

            #region Modifier
            private void btnModifierCon_Click(object sender, RoutedEventArgs e)
            {
                contact = new Contact(Convert.ToInt32(txtIdCom.Text), txtNomCom.Text, txtPrenomCom.Text, txtTelCom.Text, txtMailCom.Text,Convert.ToString(txtAdresseCon), Convert.ToString(txtVilleCon), Convert.ToString(txtCpCon));

                database.PutContact(contact);
                refreshContact();
            }
        #endregion

            #region Supprimer
            private void btnSupprimerCon_Click(object sender, RoutedEventArgs e)
            {
                database.DeleteContact(Convert.ToInt32(txtIdCon.Text));
                refreshContact();
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
                if (DataGrid_Produits.SelectedItem != null)
                {
                    produit = (Produit)DataGrid_Commercials.SelectedItem;

                    txtIdPro.Text = Convert.ToString(produit.ID);
                    txtNomPro.Text = Convert.ToString(produit.NOM);
                    txtDescriptionProd.Text = Convert.ToString(produit.DESCRIPTION);
                    txtPrixProd.Text = Convert.ToString(produit.PRIX);
                }
                else
                {
                    txtIdPro.Text = "";
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
                produit = new Produit(Convert.ToInt32(txtIdProd.Text), txtNomProd.Text, txtDescriptionProd.Text, Convert.ToDouble(txtPrixProd.Text));

                database.PutProduit(produit);
                refreshProduit();
            }
            #endregion

            #region Supprimer
            private void btnSupprimerProd_Click(object sender, RoutedEventArgs e)
            {
                database.DeleteProduit(Convert.ToInt32(txtIdProd.Text));
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
