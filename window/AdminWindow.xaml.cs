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
using TimeCard.info;
using TimeCard.window.page;
// using System.Windows.Navigation;

namespace TimeCard.window
{
    /// <summary>
    /// AdminWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class AdminWindow : Window
    {
        private const string PageDirUri = "/window/page";
        private Uri AdminPageUri = new Uri( PageDirUri + "/AdminPage.xaml", UriKind.Relative );
        private Uri UsersPageUri = new Uri( PageDirUri + "/UsersPage.xaml", UriKind.Relative );
        private Uri StampPageUri = new Uri( PageDirUri + "/StampManagePage.xaml", UriKind.Relative );

        public AdminWindow( UserInfo user_info )
        {
            InitializeComponent();
            AdminWindowFrame.Navigate( AdminPageUri );
        }

        private void LoginWindowButton_Click( object sender, RoutedEventArgs e )
        {
            var login_window = new LoginWindow();
            login_window.Show();

            this.Close();
        }

        private void AdminManageButton_Click( object sender, RoutedEventArgs e )
        {
            AdminWindowFrame.Navigate( AdminPageUri );
        }

        private void UserManageButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindowFrame.Navigate( UsersPageUri );
        }

        private void StampManageButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindowFrame.Navigate( StampPageUri );
        }
    }
}
