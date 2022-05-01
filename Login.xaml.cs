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
using System.DirectoryServices;

namespace Application_Lourde_CRM
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = "admin";
            int password = 911;

            /*
            try
            {
                DirectoryEntry AD = new DirectoryEntry("LDAP://nom_de_domaine", "Login", "Password");
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            */

            if(user == txtLogin.Text && password == Convert.ToInt32(txtMdp.Text))
            {
                Window Window_main = new Window();

                Window_main.Show();
                this.Close();
                
            }
            else
            {
                Console.WriteLine("Mot de passe incorrecte");
            }
        }
    }
}
