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
            //Création de l'objet BDD (permet de communiquer avec une base de donnée) prenant en paramètre le serveur + le nom de la base + user + password
            BDD Base_de_donnee_SQL = new BDD("localhost", "infotools", "root", "root");
            List<Prospects> cProspect = new List<Prospects>();
            List<Client> cClient = new List<Client>();
            List<Rendez_vous> cRendez_vous = new List<Rendez_vous>();
            List<Facture> cFacture = new List<Facture>();

        public MainWindow()
            {
                InitializeComponent();
            //Console.WriteLine(Base_de_donnee_SQL.Afficher_Prospects());
                DataGrid_Prospects.ItemsSource = cProspect;
                DataGrid_Clients.ItemsSource = cClient;
                DataGrid_RendezVous.ItemsSource = cRendez_vous;
                DataGrid_Factures.ItemsSource = cFacture;


        }

        private void DataGrid_Prospects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Prospects ProspectSelected = (Prospects)DataGrid_Prospects.SelectedItem;

            txtNom1.Text = Convert.ToString(ProspectSelected.NOM);
            txtPrenom1.Text = Convert.ToString(ProspectSelected.PRENOM);
            txtMail1.Text = Convert.ToString(ProspectSelected.MAIL);
            txtTel1.Text = Convert.ToString(ProspectSelected.TEL);
            txtAdresse1.Text = Convert.ToString(ProspectSelected.ADRESSE);
            txtVille1.Text = Convert.ToString(ProspectSelected.VILLE);
            txtCP1.Text = Convert.ToString(ProspectSelected.CODE_POSTAL);

            DataGrid_Prospects.Items.Refresh();
        }

        private void DataGrid_Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_RendezVous_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_Factures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAjouterPro_Click(object sender, RoutedEventArgs e)
            {
                Prospects ProspectsClient = new Prospects(Convert.ToInt32(txtID1.Text), Convert.ToString(txtNom1.Text), Convert.ToString(txtPrenom1.Text), Convert.ToString(txtMail1.Text), txtTel1.Text, Convert.ToString(txtAdresse1.Text), Convert.ToString(txtVille1.Text), Convert.ToInt32(txtCP1.Text));
                cProspect.Add(ProspectsClient);
                //Base_de_donnee_SQL.Ajouter_Prospects(ProspectsClient);
                DataGrid_Prospects.Items.Refresh();
        }

        private void btnModifierPro_Click(object sender, RoutedEventArgs e)
            {
                Prospects ProspectsClient = new Prospects(Convert.ToInt32(txtID1.Text), Convert.ToString(txtNom1.Text), Convert.ToString(txtPrenom1.Text), Convert.ToString(txtMail1.Text), Convert.ToString(txtTel1.Text), Convert.ToString(txtAdresse1.Text), Convert.ToString(txtVille1.Text), Convert.ToInt32(txtCP1.Text));

                //Base_de_donnee_SQL.Modifier_Prospects(ProspectsClient);
            }

        private void btnSupprimerPro_Click(object sender, RoutedEventArgs e)
            {
                Prospects ProspectsClient = new Prospects(Convert.ToInt32(txtID1.Text), Convert.ToString(txtNom1.Text), Convert.ToString(txtPrenom1.Text), Convert.ToString(txtMail1.Text), Convert.ToString(txtTel1.Text), Convert.ToString(txtAdresse1.Text), Convert.ToString(txtVille1.Text), Convert.ToInt32(txtCP1.Text));

                //Base_de_donnee_SQL.Supprimer_Prospects(ProspectsClient);
            }



        private void btnAjouterCli_Click(object sender, RoutedEventArgs e)
        {
            Client PersonneClient = new Client(Convert.ToInt32(txtID2.Text), Convert.ToString(txtNom2.Text), Convert.ToString(txtPrenom2.Text), Convert.ToString(txtAdresse2.Text), Convert.ToInt32(txtCP2.Text), Convert.ToString(txtVille2.Text), Convert.ToString(txtMail2.Text), Convert.ToInt32(txtTel2.Text));

            //Base_de_donnee_SQL.Ajouter_Client(PersonneClient);
        }

        private void btnModifierCli_Click(object sender, RoutedEventArgs e)
        {
            Client PersonneClient = new Client(Convert.ToInt32(txtID2.Text), Convert.ToString(txtNom2.Text), Convert.ToString(txtPrenom2.Text), Convert.ToString(txtAdresse2.Text), Convert.ToInt32(txtCP2.Text), Convert.ToString(txtVille2.Text), Convert.ToString(txtMail2.Text), Convert.ToInt32(txtTel2.Text));

            //Base_de_donnee_SQL.Modifier_Client(PersonneClient);
        }

        private void btnSupprimerCli_Click(object sender, RoutedEventArgs e)
        {
            Client PersonneClient = new Client(Convert.ToInt32(txtID2.Text), Convert.ToString(txtNom2.Text), Convert.ToString(txtPrenom2.Text), Convert.ToString(txtAdresse2.Text), Convert.ToInt32(txtCP2.Text), Convert.ToString(txtVille2.Text), Convert.ToString(txtMail2.Text), Convert.ToInt32(txtTel2.Text));

            //Base_de_donnee_SQL.Supprimer_Client(PersonneClient);
        }

        private void ButtonAjouterRdv_Click(object sender, RoutedEventArgs e)
        {
            Prospects prospectsTemp = new Prospects(Convert.ToInt32(txtProspect.Text));
            Commercials commercialsTemp = new Commercials(Convert.ToInt32(txtProspect.Text));
            Rendez_vous RdvClients = new Rendez_vous(Convert.ToInt32(txtID3.Text), prospectsTemp, commercialsTemp, Convert.ToDateTime(txtDate.Text));

            //Base_de_donnee_SQL.Ajouter_Rendez_vous(RdvClients);
        }

        private void ButtonModifierRdv_Click(object sender, RoutedEventArgs e)
        {
            Prospects prospectsTemp = new Prospects(Convert.ToInt32(txtProspect.Text));
            Commercials commercialsTemp = new Commercials(Convert.ToInt32(txtProspect.Text));
            Rendez_vous RdvClients = new Rendez_vous(Convert.ToInt32(txtID3.Text), prospectsTemp, commercialsTemp, Convert.ToDateTime(txtDate.Text));

            //Base_de_donnee_SQL.Modifier_Rendez_vous(RdvClients);
        }

        private void ButtonSupprimerRdv_Click(object sender, RoutedEventArgs e)
        {
            Prospects prospectsTemp = new Prospects(Convert.ToInt32(txtProspect.Text));
            Commercials commercialsTemp = new Commercials(Convert.ToInt32(txtProspect.Text));
            Rendez_vous RdvClients = new Rendez_vous(Convert.ToInt32(txtID3.Text), prospectsTemp, commercialsTemp, Convert.ToDateTime(txtDate.Text));

           // Base_de_donnee_SQL.Supprimer_Rendez_vous(RdvClients);
        }


        private void ButtonAjouterFact_Click(object sender, RoutedEventArgs e)
        {
            Client ClientId = new Client(Convert.ToInt32(txtIdCli.Text));
            Achats AchatsId = new Achats(Convert.ToInt32(txtIdAchat.Text));
            Facture FactureCli = new Facture(Convert.ToInt32(txtID4.Text), ClientId, AchatsId, Convert.ToDateTime(txtDtFact.Text));

            //Base_de_donnee_SQL.Ajouter_Facture(FactureCli);
        }

        private void ButtonModifierFact_Click(object sender, RoutedEventArgs e)
        {
            Client ClientId = new Client(Convert.ToInt32(txtIdCli.Text));
            Achats AchatsId = new Achats(Convert.ToInt32(txtIdAchat.Text));
            Facture FactureCli = new Facture(Convert.ToInt32(txtID4.Text), ClientId, AchatsId, Convert.ToDateTime(txtDtFact.Text));

            //Base_de_donnee_SQL.Modifier_Facture(FactureCli);
        }

        private void ButtonSupprimerFact_Click(object sender, RoutedEventArgs e)
        {
            Client ClientId = new Client(Convert.ToInt32(txtIdCli.Text));
            Achats AchatsId = new Achats(Convert.ToInt32(txtIdAchat.Text));
            Facture FactureCli = new Facture(Convert.ToInt32(txtID4.Text), ClientId, AchatsId, Convert.ToDateTime(txtDtFact.Text));

            //Base_de_donnee_SQL.Supprimer_Facture(FactureCli);
        }


    }
}
