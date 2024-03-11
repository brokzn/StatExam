using Microsoft.EntityFrameworkCore;

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

using WPFTechnoservice.Entities;

namespace WPFTechnoservice.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        private Entities.DBContext _context = new Entities.DBContext();
        private User CurrentUser { get; set; }
        public Order order { get; set; }
        public ManagerPage(User user)
        {
            CurrentUser = user;
            InitializeComponent();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var orders = await _context.Orders.ToListAsync();
            Orders.ItemsSource = orders;    
        }

        private void Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
