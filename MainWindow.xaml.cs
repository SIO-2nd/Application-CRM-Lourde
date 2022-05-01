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

            public MainWindow()
            {
                InitializeComponent();

                /*
                 * List<Client> tempTableauClients = new List<Client>();
                 */
            }

            private void btnAjouterClient_Click(object sender, RoutedEventArgs e)
            {
                Client PersonneClient = new Client(Convert.ToInt32(txtID2.Text), Convert.ToString(txtNom2.Text), Convert.ToString(txtPrenom2.Text), Convert.ToString(txtAdresse2.Text), Convert.ToInt32(txtCP2.Text), Convert.ToString(txtVille2.Text), Convert.ToString(txtMail2.Text), Convert.ToInt32(txtTel2.Text));

                Base_de_donnee_SQL.Ajouter_Client(PersonneClient);
            }

            private void btnModifierClient_Click(object sender, RoutedEventArgs e)
            {
                Client PersonneClient = new Client(Convert.ToInt32(txtID2.Text), Convert.ToString(txtNom2.Text), Convert.ToString(txtPrenom2.Text), Convert.ToString(txtAdresse2.Text), Convert.ToInt32(txtCP2.Text), Convert.ToString(txtVille2.Text), Convert.ToString(txtMail2.Text), Convert.ToInt32(txtTel2.Text));

                Base_de_donnee_SQL.Modifier_Client(PersonneClient);
            }

            private void btnSupprimerClient_Click(object sender, RoutedEventArgs e)
            {
                Client PersonneClient = new Client(Convert.ToInt32(txtID2.Text), Convert.ToString(txtNom2.Text), Convert.ToString(txtPrenom2.Text), Convert.ToString(txtAdresse2.Text), Convert.ToInt32(txtCP2.Text), Convert.ToString(txtVille2.Text), Convert.ToString(txtMail2.Text), Convert.ToInt32(txtTel2.Text));

                Base_de_donnee_SQL.Supprimer_Client(PersonneClient);
            }

            private void btnAjouterPro_Click(object sender, RoutedEventArgs e)
            {
                Prospects ProspectsClient = new Prospects(Convert.ToInt32(txtID1.Text), Convert.ToString(txtNom1.Text), Convert.ToString(txtPrenom1.Text), Convert.ToString(txtMail1.Text), Convert.ToInt32(txtTel1.Text), Convert.ToString(txtAdresse1.Text), Convert.ToString(txtVille1.Text), Convert.ToInt32(txtCP1.Text));

                Base_de_donnee_SQL.Ajouter_Prospects(ProspectsClient);
            }

            private void btnModifierPro_Click(object sender, RoutedEventArgs e)
            {
                Prospects ProspectsClient = new Prospects(Convert.ToInt32(txtID1.Text), Convert.ToString(txtNom1.Text), Convert.ToString(txtPrenom1.Text), Convert.ToString(txtMail1.Text), Convert.ToInt32(txtTel1.Text), Convert.ToString(txtAdresse1.Text), Convert.ToString(txtVille1.Text), Convert.ToInt32(txtCP1.Text));

                Base_de_donnee_SQL.Modifier_Prospects(ProspectsClient);
            }

            private void btnSupprimerPro_Click(object sender, RoutedEventArgs e)
            {
                Prospects ProspectsClient = new Prospects(Convert.ToInt32(txtID1.Text), Convert.ToString(txtNom1.Text), Convert.ToString(txtPrenom1.Text), Convert.ToString(txtMail1.Text), Convert.ToInt32(txtTel1.Text), Convert.ToString(txtAdresse1.Text), Convert.ToString(txtVille1.Text), Convert.ToInt32(txtCP1.Text));

                Base_de_donnee_SQL.Supprimer_Prospects(ProspectsClient);
            }

            private void btnAjouterRdv_Click(object sender, RoutedEventArgs e)
            {
                Prospects prospectsTemp = new Prospects(Convert.ToInt32(txtProspect.Text));
                Commercials commercialsTemp = new Commercials(Convert.ToInt32(txtProspect.Text));
                Rendez_vous RdvClients = new Rendez_vous(Convert.ToInt32(txtID3.Text), prospectsTemp, commercialsTemp, Convert.ToDateTime(txtDate.Text));

                Base_de_donnee_SQL.Ajouter_Rendez_vous(RdvClients);
            }

            private void btnModifierRdv_Click(object sender, RoutedEventArgs e)
            {
                Prospects prospectsTemp = new Prospects(Convert.ToInt32(txtProspect.Text));
                Commercials commercialsTemp = new Commercials(Convert.ToInt32(txtProspect.Text));
                Rendez_vous RdvClients = new Rendez_vous(Convert.ToInt32(txtID3.Text), prospectsTemp, commercialsTemp, Convert.ToDateTime(txtDate.Text));

                Base_de_donnee_SQL.Modifier_Rendez_vous(RdvClients);
            }

            private void Supprimer_Click(object sender, RoutedEventArgs e)
            {
                Prospects prospectsTemp = new Prospects(Convert.ToInt32(txtProspect.Text));
                Commercials commercialsTemp = new Commercials(Convert.ToInt32(txtProspect.Text));
                Rendez_vous RdvClients = new Rendez_vous(Convert.ToInt32(txtID3.Text), prospectsTemp, commercialsTemp, Convert.ToDateTime(txtDate.Text));

                Base_de_donnee_SQL.Supprimer_Rendez_vous(RdvClients);
            }

            private void AjouerFact_Click(object sender, RoutedEventArgs e)
            {
                Client ClientId = new Client(Convert.ToInt32(txtIdCli.Text));
                Achats AchatsId = new Achats(Convert.ToInt32(txtIdAchat.Text));
                Facture FactureCli = new Facture(Convert.ToInt32(txtID4.Text), ClientId, AchatsId, Convert.ToDateTime(txtDtFact.Text));

                Base_de_donnee_SQL.Ajouter_Facture(FactureCli);
            }

            private void ModifierFact_Click(object sender, RoutedEventArgs e)
            {
                Client ClientId = new Client(Convert.ToInt32(txtIdCli.Text));
                Achats AchatsId = new Achats(Convert.ToInt32(txtIdAchat.Text));
                Facture FactureCli = new Facture(Convert.ToInt32(txtID4.Text), ClientId, AchatsId, Convert.ToDateTime(txtDtFact.Text));

                Base_de_donnee_SQL.Modifier_Facture(FactureCli);
            }

            private void SupprimerFact_Click(object sender, RoutedEventArgs e)
            {
                Client ClientId = new Client(Convert.ToInt32(txtIdCli.Text));
                Achats AchatsId = new Achats(Convert.ToInt32(txtIdAchat.Text));
                Facture FactureCli = new Facture(Convert.ToInt32(txtID4.Text), ClientId, AchatsId, Convert.ToDateTime(txtDtFact.Text));

                Base_de_donnee_SQL.Supprimer_Facture(FactureCli);
            }

            private void DataGrid_Factures_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }
        }
}
