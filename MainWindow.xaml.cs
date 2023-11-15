using Examen.Net.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Examen.Net
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Data.DatabaseContext dbContext;
        private List<Models.Product> cart = new List<Models.Product>();
        private Models.User loggedInUser;

        public MainWindow()
        {
            InitializeComponent();
            dbContext = new Data.DatabaseContext();
            Data.Initializer.Initialize(dbContext);
            LoadProducts(); // Laad producten wanneer het venster wordt gestart
        }

        private void LoadProducts()
        {
            try
            {
                var products = dbContext.Products.ToList();
                ProductsListBox.ItemsSource = products;
            }
            catch (Exception ex)
            {
                ShowError("Fout bij het laden van producten.", ex.Message);
            }
        }

        private void ShowError(string status, string errorMessage)
        {
            StatusLabel.Text = status;
            ErrorStatus.Text = $"Fout: {errorMessage}";
            MessageBox.Show($"Fout: {errorMessage}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductsListBox.SelectedItem is Models.Product selectedProduct)
                {
                    cart.Add(selectedProduct);
                    RefreshCartListBox();
                    StatusLabel.Text = $"{selectedProduct.Name} toegevoegd aan het winkelmandje.";
                }
            }
            catch (Exception ex)
            {
                ErrorStatus.Text = $"Fout bij het toevoegen aan het winkelmandje: {ex.Message}";
            }
        }

        private void RefreshCartListBox()
        {
            CartListBox.ItemsSource = null;
            CartListBox.ItemsSource = cart;
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            // Voeg logica toe voor het plaatsen van een bestelling
            if (cart.Any())
            {
                MessageBox.Show("Bestelling geplaatst!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                cart.Clear();
                RefreshCartListBox();
            }
            else
            {
                MessageBox.Show("Winkelwagen is leeg. Voeg producten toe voordat je een bestelling plaatst.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Voeg logica toe voor het inloggen
            var loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            // Controleer of het inloggen succesvol was en update de UI
            if (loginWindow.DialogResult.HasValue && loginWindow.DialogResult.Value)
            {
                loggedInUser = loginWindow.LoggedInUser;
                UpdateUIForLoggedInUser();
            }
        }

        private void UpdateUIForLoggedInUser()
        {
            // Toon de gebruikersnaam en de "Uitloggen" knop
            UserNameLabel.Text = $"Welkom, {loggedInUser.Username}!";
            UserNameLabel.Visibility = Visibility.Visible;
            LogoutButton.Visibility = Visibility.Visible;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Voeg logica toe voor uitloggen
            loggedInUser = null;
            UserNameLabel.Visibility = Visibility.Collapsed;
            LogoutButton.Visibility = Visibility.Collapsed;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Voeg logica toe voor registreren
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
    }
}