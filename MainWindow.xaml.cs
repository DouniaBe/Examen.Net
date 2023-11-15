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

        public MainWindow()
        {
            InitializeComponent();
            dbContext = new Data.DatabaseContext();
            Data.Initializer.Initialize(dbContext);
            LoadProducts(); // Load products when the window starts
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
                ShowError("Error loading products.", ex.Message);
            }
        }

        private void ShowError(string status, string errorMessage)
        {
            StatusLabel.Text = status;
            ErrorStatus.Text = $"Error: {errorMessage}";
            MessageBox.Show($"Error: {errorMessage}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            // Add logic for placing an order
            if (cart.Any())
            {
                MessageBox.Show("Order placed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                cart.Clear();
                RefreshCartListBox();
            }
            else
            {
                MessageBox.Show("Shopping cart is empty. Add products before placing an order.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Add logic for logging in
            var loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Add logic for registering
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
    }
}