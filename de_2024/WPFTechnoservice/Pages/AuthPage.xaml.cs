using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPFTechnoservice.Pages
{
    public partial class AuthPage : Page
    {
        Entities.DBContext _context = new Entities.DBContext();

        public AuthPage()
        {
            InitializeComponent();
        }

        private async void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            var user = await _context.Users
                .Where(x => x.Password == PasswordTextBox.Text && x.Login == LoginTextBox.Text)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }
            App.CurrentUser = user;

            switch (user.UserRoleId)
            {
                case 1:
                    MessageBox.Show("Вы вошли как менеджер!");
                     NavigationService.Navigate(new ManagerPage(user));
                    break;
                case 2:
                    MessageBox.Show("Вы вошли как администратор!");
                     NavigationService.Navigate(new AdminPage(user));
                    break;
                case 3:
                    MessageBox.Show("Вы вошли как мастер!");
                    NavigationService.Navigate(new MasterPage(user));
                    break;
                case 4:
                    MessageBox.Show("Вы вошли как клиент!");
                    NavigationService.Navigate(new CreatOrderPage(user));
                    break;
            }
        }


        private void BackToRegButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

    }
}
