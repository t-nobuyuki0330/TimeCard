using System;
using System.IO;
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
using TimeCard.Info;
using TimeCard.Utility;
using TimeCard.Window;

namespace TimeCard.Window.Page
{
    /// <summary>
    /// UsersPage.xaml の相互作用ロジック
    /// </summary>
    public partial class UsersPage : System.Windows.Controls.Page
    {
        private List< UserInfo > UsersList;

        public UsersPage()
        {
            InitializeComponent();
            UpdateUsersInfo();

        }

        public void UpdateUsersInfo()
        {
            if ( !File.Exists( InfoUri.UsersInfo ) )
            {
                return;
            }

            var users_data = FileUtility.LoadBinaryFile( InfoUri.UsersInfo );
            if ( users_data.file_data is List< UserInfo > )
            {
                UsersList = ( List< UserInfo > )users_data.file_data;
            }
            else
            {
                MessageBox.Show( "ユーザー定義ファイルを読み込めませんでした" );
                return;
            }

            UsersData.ItemsSource = UsersList;
            
        }

        public void add_click( object sender, RoutedEventArgs e )
        {
            UserAddWindow user_add_window = new UserAddWindow();
            user_add_window.ShowDialog();
        }

        public void edit_click( object sender, RoutedEventArgs e )
        {
            UserAddWindow user_add_window = new UserAddWindow();
            user_add_window.ShowDialog();
        }
    }
}
