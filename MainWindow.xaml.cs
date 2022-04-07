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

namespace Application_Lourde_CRM
{
        public partial class MainWindow : Window
        {
            List<Rendez_vous> cRendez_vous = new List<Rendez_vous>();

        public MainWindow()
            {
                InitializeComponent();
                Database.Initialize();
                List<Prospects> cProspect = Database.GetProspect();
                List<Client> cClient = Database.GetClient();
                List<Commercials> cCommercial = Database.GetCommercial();
                List<Facture> cFacture = Database.GetFacture();
                DataGrid_Prospects.ItemsSource = cProspect;
                DataGrid_Clients.ItemsSource = cClient;
                DataGrid_Commercials.ItemsSource = cCommercial;
                DataGrid_RendezVous.ItemsSource = cRendez_vous;
                DataGrid_Factures.ItemsSource = cFacture;


        }

        #region Prospects
        private void refreshProspect()
        {
            List<Prospects> cProspect = Database.GetProspect();
            DataGrid_Prospects.ItemsSource = cProspect;
        }

        private void DataGrid_Prospects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_Prospects.SelectedItem != null)
            {
                Prospects prospectSelected = (Prospects)DataGrid_Prospects.SelectedItem;

                txtIdPro.Text = Convert.ToString(prospectSelected.Id);
                txtNomPro.Text = Convert.ToString(prospectSelected.Nom);
                txtPrenomPro.Text = Convert.ToString(prospectSelected.Prenom);
                txtMailPro.Text = Convert.ToString(prospectSelected.Email);
                txtTelPro.Text = Convert.ToString(prospectSelected.Telephone);
                txtAdressePro.Text = Convert.ToString(prospectSelected.Adresse);
                txtVillePro.Text = Convert.ToString(prospectSelected.Ville);
                txtCpPro.Text = Convert.ToString(prospectSelected.Code_Postal);
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

        private void btnAjouterPro_Click(object sender, RoutedEventArgs e)
        {
            Prospects tmpProspect = new Prospects
            {
                Nom = txtNomPro.Text,
                Prenom = txtPrenomPro.Text,
                Email = txtMailPro.Text,
                Telephone = Convert.ToInt32(txtTelPro.Text),
                Adresse = txtAdressePro.Text,
                Ville = txtVillePro.Text,
                Code_Postal = Convert.ToInt32(txtCpPro.Text)
            };
            Database.PostProspect(tmpProspect);
            refreshProspect();
        }

        private void btnModifierPro_Click(object sender, RoutedEventArgs e)
        {
            Prospects tmpProspect = new Prospects
            {
                Id = Convert.ToInt32(txtIdPro.Text),
                Nom = txtNomPro.Text,
                Prenom = txtPrenomPro.Text,
                Email = txtMailPro.Text,
                Telephone = Convert.ToInt32(txtTelPro.Text),
                Adresse = txtAdressePro.Text,
                Ville = txtVillePro.Text,
                Code_Postal = Convert.ToInt32(txtCpPro.Text)
            };
            Database.PutProspect(tmpProspect);
            refreshProspect();
        }

        private void btnSupprimerPro_Click(object sender, RoutedEventArgs e)
        {
            Database.DeleteProspect(txtIdPro.Text);
            refreshProspect();
        }
        #endregion

        #region Clients
        private void refreshClients()
        {
            List<Client> cClient = Database.GetClient();
            DataGrid_Clients.ItemsSource = cClient;
        }

        private void DataGrid_Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_Clients.SelectedItem != null)
            {
                Client clientSelected = (Client)DataGrid_Clients.SelectedItem;

                txtIdCli.Text = Convert.ToString(clientSelected.Id);
                txtNomCli.Text = Convert.ToString(clientSelected.Nom);
                txtPrenomCli.Text = Convert.ToString(clientSelected.Prenom);
                txtMailCli.Text = Convert.ToString(clientSelected.Email);
                txtTelCli.Text = Convert.ToString(clientSelected.Telephone);
                txtAdresseCli.Text = Convert.ToString(clientSelected.Adresse);
                txtVilleCli.Text = Convert.ToString(clientSelected.Ville);
                txtCpCli.Text = Convert.ToString(clientSelected.Code_Postal);
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

        private void btnAjouterCli_Click(object sender, RoutedEventArgs e)
        {
            Client tmpClient = new Client
            {
                Nom = txtNomCli.Text,
                Prenom = txtPrenomCli.Text,
                Email = txtMailCli.Text,
                Telephone = Convert.ToInt32(txtTelCli.Text),
                Adresse = txtAdresseCli.Text,
                Ville = txtVilleCli.Text,
                Code_Postal = Convert.ToInt32(txtCpCli.Text)
        };
                Database.PostClient(tmpClient);
                refreshClients();
        }

        private void btnModifierCli_Click(object sender, RoutedEventArgs e)
        {
            Client tmpClient = new Client
            {
                Id = Convert.ToInt32(txtIdCli.Text),
                Nom = txtNomCli.Text,
                Prenom = txtPrenomCli.Text,
                Email = txtMailCli.Text,
                Telephone = Convert.ToInt32(txtTelCli.Text),
                Adresse = txtAdresseCli.Text,
                Ville = txtVilleCli.Text,
                Code_Postal = Convert.ToInt32(txtCpCli.Text)
            };

            Database.PutClient(tmpClient);
            refreshClients();
        }

        private void btnSupprimerCli_Click(object sender, RoutedEventArgs e)
        {
            Database.DeleteClient(txtIdCli.Text);
            refreshClients();
        }
        #endregion

        #region Commercials
        private void refreshCommercials()
        {
            List<Commercials> cCommercial = Database.GetCommercial();
            DataGrid_Commercials.ItemsSource = cCommercial;
        }

        private void DataGrid_Commercials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_Commercials.SelectedItem != null)
            {
                Commercials commercialSelected = (Commercials)DataGrid_Commercials.SelectedItem;

                txtIdCom.Text = Convert.ToString(commercialSelected.Id);
                txtNomCom.Text = Convert.ToString(commercialSelected.Nom);
                txtPrenomCom.Text = Convert.ToString(commercialSelected.Prenom);
                txtMailCom.Text = Convert.ToString(commercialSelected.Email);
                txtTelCom.Text = Convert.ToString(commercialSelected.Telephone);
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

        private void btnAjouterCom_Click(object sender, RoutedEventArgs e)
        {
            Commercials tmpCommercial = new Commercials
            {
                Nom = txtNomCom.Text,
                Prenom = txtPrenomCom.Text,
                Email = txtMailCom.Text,
                Telephone = Convert.ToInt32(txtTelCom.Text)
            };
            Database.PostCommercial(tmpCommercial);
            refreshCommercials();
        }

        private void btnModifierCom_Click(object sender, RoutedEventArgs e)
        {
            Commercials tmpCommercial = new Commercials
            {
                Id = Convert.ToInt32(txtIdCom.Text),
                Nom = txtNomCom.Text,
                Prenom = txtPrenomCom.Text,
                Email = txtMailCom.Text,
                Telephone = Convert.ToInt32(txtTelCom.Text)
            };

            Database.PutCommercial(tmpCommercial);
            refreshCommercials();
        }

        private void btnSupprimerCom_Click(object sender, RoutedEventArgs e)
        {
            Database.DeleteCommercial(txtIdCom.Text);
            refreshCommercials();
        }
        #endregion

        #region Rendez_Vous
        private void refreshRendez_Vous()
        {
            //List<Rendez_vous> cRendez_vous = Database.GetRendezVous();
            DataGrid_RendezVous.ItemsSource = cRendez_vous;
        }

        private void DataGrid_RendezVous_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonAjouterRdv_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonModifierRdv_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSupprimerRdv_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Facture
        private void refreshFacture()
        {
            List<Facture> cFacture = Database.GetFacture();
            DataGrid_Factures.ItemsSource = cFacture;
        }

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
    }
}
