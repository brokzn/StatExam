using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using WPFTechnoservice.Entities;

namespace WPFTechnoservice.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreatOrderPage.xaml
    /// </summary>
    public partial class CreatOrderPage : Page
    {
        private Entities.DBContext _context = new Entities.DBContext();
        private User CurrentUser {  get; set; }
        public CreatOrderPage(User user)
        {
            CurrentUser = user;
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var uniqueTypes = _context.TypesEquipments.Select(e => new { Id = e.Id, Name = e.Name }).Distinct().ToList();
            TypeOfEquipmentsComboBox.ItemsSource = uniqueTypes;

            WelcomeLabel.Content = "Добро пожаловать, " + CurrentUser.Name +" !" + " ваш уникальный индентификатор " + CurrentUser.Id;
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            string descProblems = DescriptionProblemsTextBox.Text;
            string typeMalfunction = TypeMalfunctionTextBox.Text;
            int curruserID = CurrentUser.Id;
            Order newOrder = new Order
            {
                EquipmentId = TypeOfEquipmentsComboBox.SelectedIndex,
                DescriptionProblems = descProblems,
                TypeMalfunction = typeMalfunction,
                ClientId = curruserID,
                OrderStatusId = 1
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            MessageBox.Show("Заказ успешно добавлен в базу данных!");
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
