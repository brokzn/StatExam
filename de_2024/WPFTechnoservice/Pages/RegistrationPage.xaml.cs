using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Windows;
using System.Windows.Controls;

using WPFTechnoservice.Entities;

namespace WPFTechnoservice.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Entities.DBContext _context = new Entities.DBContext();

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var user = await _context.Users
                .Where(x => x.Login == LoginTextBox.Text)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                MessageBox.Show("Логин занят!");
                return;
            }

            string NewUserLogin = LoginTextBox.Text;
            string NewUserPass = PasswordTextBox.Text;
            int NewUserRole = 4;
            string NewUserFullName = UserFIOTextBox.Text;

            User addUser = new User
            {
                Name = UserFIOTextBox.Text,
                UserRoleId = NewUserRole,
                Login = NewUserLogin,
                Password = NewUserPass,
            };
            _context.Users.Add(addUser);
            _context.SaveChanges();
            MessageBox.Show("Успешная регистрация!!!");

        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

    }
}
