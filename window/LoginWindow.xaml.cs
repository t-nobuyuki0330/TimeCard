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

namespace TimeCard.window
{
    /// <summary>
    /// LoginWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
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

            if ( LoginUserNo.Text == "99999" )
            {
                if ( LoginPassword.Password == "admin" )
                {
                    var admin_window = new AdminWindow();
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
