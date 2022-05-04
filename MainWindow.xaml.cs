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
            Commercial commercial = null;
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
                /*DataGrid_RendezVous.ItemsSource = list_rendez_vous;
                DataGrid_Factures.ItemsSource = list_factures;*/
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
