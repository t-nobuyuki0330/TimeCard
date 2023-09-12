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
using TimeCard.utility;
using TimeCard.info;

namespace TimeCard.window
{
    /// <summary>
    /// LoginWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserInfo AdminInfo;

        public LoginWindow()
        {
            InitializeComponent();
            var load_data = FileUtility.LoadBinaryFile( FileUtility.GetAppDataPath() + "\\info\\admin_info.dat" );
            AdminInfo = ( UserInfo )load_data.file_data;
        }

        private void LoginButton_Click( object sender, RoutedEventArgs e )
        {
            Login();
        }

        private void Login()
        {
            var login_allow = false;

            if ( LoginUserNo.Text == "" || LoginPassword.Password == "" )
            {
                MessageBox.Show( this, "社員番号・パスワードを入力してください" );
                return;
            }

            if ( LoginUserNo.Text == AdminInfo.UserNo )
            {
                if ( Sha256.CreateSHA256( LoginPassword.Password ) == AdminInfo.Password )
                {
                    var admin_window = new AdminWindow( AdminInfo );
                    admin_window.Show();
                    login_allow = true;
                }
            }
            else // 仮処理
            {
                var main_window = new MainWindow( LoginUserNo.Text );
                main_window.Show();

                login_allow = true;
            }

            // ログイン可否処理

            if ( login_allow )
            {

            }
            else
            {
                MessageBox.Show( this, "社員番号またはパスワードが違います" );
                return;
            }

            this.Close();
        }

    }
}
