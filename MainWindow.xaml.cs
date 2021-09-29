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
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Création de 3 collections pour stocker les objets
            List<Prospects> cProspects = new List<Prospects>();
            List<Client> cClients = new List<Client>();
            List<Rendez_vous> cRDV = new List<Rendez_vous>();
            List<Facture> cFacture = new List<Facture>();

            InitializeComponent();

            // Ajout d'objets temporaires pour tester l'application
            Prospects P1 = new Prospects(1, "REQUISTON", "Timothé", "tim-req.pro@outlook.fr", 0123456789, "16 avenue lambourg", "Chalon sur Saône", 71100);

            Client C1 = new Client(1, "PEYRONNET", "Philippe", "philippe@gmail.com", 789456123, "18 rue de la république", "Dijon", 21000);

            Rendez_vous R1 = new Rendez_vous(1, 1, 1, DateTime.Parse("29/09/2021"));

            Produits Pr1 = new Produits(1, "Pomme", "Fruit", 1);

            Facture F1 = new Facture(1, C1, Pr1, DateTime.Parse("29/09/2021"), 50);

            // Remplissage des collections avec les objets
            cProspects.Add(P1);

            cClients.Add(C1);

            cRDV.Add(R1);

            cFacture.Add(F1);

            // Binding des datagrids avec les collections
            datagrid1.ItemsSource = cProspects;
            datagrid2.ItemsSource = cClients;
            datagrid3.ItemsSource = cRDV;
            datagrid4.ItemsSource = cFacture;
        }

        private void btnAjouter1_Click(object sender, RoutedEventArgs e)
        {
            //Prospects tmpProspect = new Prospects(Convert.ToInt16(txtID1.Text), txtNom1.Text, txtPrenom1.Text, txtMail1.Text, Convert.ToInt16(txtTel1.Text), txtAdresse1.Text, txtVille1.Text, Convert.ToInt16(txtCP1.Text));
            //cProspects.Add(tmpProspect);//
            //datagrid1.Items.Refresh();//
        }
    }
}