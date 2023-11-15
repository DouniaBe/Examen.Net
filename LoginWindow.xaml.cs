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

namespace Examen.Net
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Voeg inloglogica toe
            MessageBox.Show("Inloggen...");
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Open het registratievenster
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
    }
}
