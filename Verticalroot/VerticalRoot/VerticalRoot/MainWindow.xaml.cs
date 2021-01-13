using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int userId { get; set; }

        public MainWindow()
        {
            this.Title = "Login";
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername2.Text;
            string password = tbPassword2.Text;
            Login login = new Login();
            int isLoggedIn = login.checkLogin(username, password);
            userId = isLoggedIn;
            
            if (isLoggedIn > 0)
            {
                Hide();
                Dashboard dash = new Dashboard();
                dash.Show();
            }
            if (isLoggedIn == 0)
            {
                MessageBox.Show("Login unsuccessfull, please try again");
            }
        }

        private void SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                this.Button_Click(sender, e);
            }
        }
    }
}
