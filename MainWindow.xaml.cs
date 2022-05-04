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

            Prospect prospect = null;
            Client client = null;
            Commercial commercials = null;
            Rendez_Vous rendez_vous = null;
            Facture facture = null;

            public MainWindow()
            {
                InitializeComponent();
                list_prospects = database.GetProspect();
                list_client = database.GetClient();
                list_commercials = database.GetCommercial();
                list_rendez_vous = database.GetRdv();
                list_factures = database.GetFacture();


                DataGrid_Prospects.ItemsSource = list_prospects;
                DataGrid_Clients.ItemsSource = list_client;
                DataGrid_Commercials.ItemsSource = list_commercials;
                DataGrid_RendezVous.ItemsSource = list_rendez_vous;
                DataGrid_Factures.ItemsSource = list_factures;
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
                    prospect = (Prospects)DataGrid_Prospects.SelectedItem;

                    txtIdPro.Text = Convert.ToString(prospect.Id);
                    txtNomPro.Text = Convert.ToString(prospect.Nom);
                    txtPrenomPro.Text = Convert.ToString(prospect.Prenom);
                    txtMailPro.Text = Convert.ToString(prospect.Email);
                    txtTelPro.Text = Convert.ToString(prospect.Telephone);
                    txtAdressePro.Text = Convert.ToString(prospect.Adresse);
                    txtVillePro.Text = Convert.ToString(prospect.Ville);
                    txtCpPro.Text = Convert.ToString(prospect.Code_Postal);
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
                prospect = new Prospects(txtNomPro.Text, txtPrenomPro.Text, txtMailPro.Text, Convert.ToInt32(txtTelPro.Text), txtAdressePro.Text, txtVillePro.Text, Convert.ToInt32(txtCpPro.Text));

                database.PostProspect(prospect);
                refreshProspect();
            }
            #endregion

            #region Modifier
            private void btnModifierPro_Click(object sender, RoutedEventArgs e)
            {
                prospect = new Prospects(txtNomPro.Text, txtPrenomPro.Text, txtMailPro.Text, Convert.ToInt32(txtTelPro.Text), txtAdressePro.Text, txtVillePro.Text, Convert.ToInt32(txtCpPro.Text));

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

                    txtIdCli.Text = Convert.ToString(client.Id);
                    txtNomCli.Text = Convert.ToString(client.Nom);
                    txtPrenomCli.Text = Convert.ToString(client.Prenom);
                    txtMailCli.Text = Convert.ToString(client.Email);
                    txtTelCli.Text = Convert.ToString(client.Telephone);
                    txtAdresseCli.Text = Convert.ToString(client.Adresse);
                    txtVilleCli.Text = Convert.ToString(client.Ville);
                    txtCpCli.Text = Convert.ToString(client.Code_Postal);
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
                client = new Client(txtNomCli.Text, txtPrenomCli.Text, txtMailCli.Text, Convert.ToInt32(txtTelCli.Text), txtAdresseCli.Text, txtVilleCli.Text, Convert.ToInt32(txtCpCli.Text));

                database.PostClient(client);
                refreshClients();
            }
            #endregion

            #region Modifier
            private void btnModifierCli_Click(object sender, RoutedEventArgs e)
            {
                client = new Client(Convert.ToInt32(txtIdCli.Text), txtNomCli.Text, txtPrenomCli.Text, txtMailCli.Text, Convert.ToInt32(txtTelCli.Text), txtAdresseCli.Text, txtVilleCli.Text, Convert.ToInt32(txtCpCli.Text));

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
                    commercials = (Commercials)DataGrid_Commercials.SelectedItem;

                    txtIdCom.Text = Convert.ToString(commercials.Id);
                    txtNomCom.Text = Convert.ToString(commercials.Nom);
                    txtPrenomCom.Text = Convert.ToString(commercials.Prenom);
                    txtMailCom.Text = Convert.ToString(commercials.Email);
                    txtTelCom.Text = Convert.ToString(commercials.Telephone);
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
                commercials = new Commercials(txtNomCom.Text, txtPrenomCom.Text, txtMailCom.Text, Convert.ToInt32(txtTelCom.Text));
                
                database.PostCommercial(commercials);

                refreshCommercials();
            }
            #endregion

            #region Modifier
            private void btnModifierCom_Click(object sender, RoutedEventArgs e)
            {
                commercials = new Commercials(Convert.ToInt32(txtIdCom.Text), txtNomCom.Text, txtPrenomCom.Text, txtMailCom.Text, Convert.ToInt32(txtTelCom.Text));

                database.PutCommercial(commercials);
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

                    txtIdFact.Text = Convert.ToString(factureSelected.Id);
                    txtIdAchat.Text = Convert.ToString(factureSelected.Achats.ID);
                    txtIdClient.Text = Convert.ToString(factureSelected.Client.Id);
                    txtDtFact.Text = Convert.ToString(factureSelected.Date);
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
            
            #region Autres
            private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
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
