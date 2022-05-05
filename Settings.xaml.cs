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
using System.Windows.Shapes;
using System.IO;

namespace Application_Lourde_CRM
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();

            string SettingsFile = "Settings.xml";

            if (File.Exists(SettingsFile))
            {
                try
                {
                    txtIdUtil.Text = File.ReadLines(SettingsFile).Take(1).First();
                }
                catch (Exception ex)
                {
                    txtIdUtil.Text = "";
                }

                try
                {
                    txtMdpUtil.Password = File.ReadLines(SettingsFile).Skip(1).Take(1).First();
                }
                catch (Exception ex)
                {
                    txtMdpUtil.Password = "";
                }

                try
                {
                    txtHote.Text = File.ReadLines(SettingsFile).Skip(2).Take(1).First();
                }
                catch (Exception ex)
                {
                    txtHote.Text = "";
                }

                try
                {
                    txtBdd.Text = File.ReadLines(SettingsFile).Skip(3).Take(1).First();
                }
                catch (Exception ex)
                {
                    txtBdd.Text = "";
                }

                try
                {
                    txtIdServ.Text = File.ReadLines(SettingsFile).Skip(4).Take(1).First();
                }
                catch (Exception ex)
                {
                    txtIdServ.Text = "";
                }

                try
                {
                    txtMdpServ.Password = File.ReadLines(SettingsFile).Skip(5).Take(1).First();
                }
                catch (Exception ex)
                {
                    txtMdpServ.Password = "";
                }
            }
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            string SettingsFile = "Settings.xml";

            File.Delete(SettingsFile);

            string Text = txtIdUtil.Text + Environment.NewLine + txtMdpUtil.Password + Environment.NewLine + txtHote.Text + Environment.NewLine + txtBdd.Text + Environment.NewLine + txtIdServ.Text + Environment.NewLine + txtMdpServ.Password;

            File.AppendAllText(SettingsFile, Text);

            MessageBox.Show("Paramètres sauvegardés avec succès", "Succès");

            this.Close();
        }
    }
}
