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
        private readonly Data.DatabaseContext dbContext;

        // Public property om de ingelogde gebruiker door te geven
        public Models.User LoggedInUser { get; private set; }

        public LoginWindow()
        {
            InitializeComponent();
            dbContext = new Data.DatabaseContext();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Haal de gebruiker op basis van de ingevoerde inloggegevens
                var enteredUsername = UsernameTextBox.Text;
                var enteredPassword = PasswordBox.Password;

                var loggedInUser = dbContext.Users.FirstOrDefault(user => user.Username == enteredUsername && user.Password == enteredPassword);

                if (loggedInUser != null)
                {
                    // Inloggen was succesvol
                    LoggedInUser = loggedInUser;

                    // Stel de DialogResult in op true om aan te geven dat het inloggen succesvol was
                    DialogResult = true;
                    Close();
                }
                else
                {
                    // Toon een foutbericht als de inloggegevens onjuist zijn
                    MessageBox.Show("Ongeldige inloggegevens. Probeer opnieuw.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                // Toon een foutbericht bij andere fouten
                MessageBox.Show($"Fout bij het inloggen: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Voeg hier je logica toe voor het verwerken van het registratieverzoek
            // Open bijvoorbeeld een nieuw venster voor registratie of navigeer naar een registratiepagina
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
    }
}
