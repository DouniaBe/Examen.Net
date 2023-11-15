using Examen.Net.Data;
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
using Examen.Net.Models;

namespace Examen.Net
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly Data.DatabaseContext dbContext;

        public RegisterWindow()
        {
            InitializeComponent();
            dbContext = new Data.DatabaseContext();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Voeg registratielogica toe
                string name = RegisterNameTextBox.Text;
                string username = RegisterUsernameTextBox.Text;
                string email = RegisterEmailTextBox.Text;
                string password = RegisterPasswordBox.Password;
                string repeatPassword = RepeatPasswordBox.Password;

                // Controleer of het wachtwoord overeenkomt met de herhaling van het wachtwoord
                if (password != repeatPassword)
                {
                    MessageBox.Show("Wachtwoord komt niet overeen met de herhaling van het wachtwoord.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Voeg de gebruiker toe aan de database
                var newUser = new Models.User { Name = name, Username = username, Email = email, Password = password };
                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();

                MessageBox.Show("Registratie succesvol.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);

                // Sluit het registratievenster
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij registratie: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Sluit het registratievenster
            Close();
        }
    }
}
