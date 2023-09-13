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
using TimeCard.controll;

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
            if ( LoginUserNo.Text == "" || LoginPassword.Password == "" )
            {
                MessageBox.Show( this, "社員番号・パスワードを入力してください" );
                return;
            }

            var login_result = LoginControll.LocalCertification ( LoginUserNo.Text, LoginPassword.Password );

            // ログイン可否処理

            switch ( login_result.error )
            {
                case LoginControll.L_LOGIN_ERROR.SUCCESS:

                    if ( login_result.user_info != null )
                    {
                        if ( login_result.admin_mode )
                        {
                            var admin_window = new AdminWindow( login_result.user_info );
                            admin_window.Show();
                        }
                        else
                        {
                            var stamp_window = new StampWindow( login_result.user_info );
                            stamp_window.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show( this, "ログイン処理に失敗しました\n再起動してください" );
                    }
                    break;

                case LoginControll.L_LOGIN_ERROR.NO_USER:
                case LoginControll.L_LOGIN_ERROR.MISS_PASS:
                    MessageBox.Show( this,　"社員番号またはパスワードが違います" );
                    return;

                case LoginControll.L_LOGIN_ERROR.NO_USERINFO:
                    MessageBox.Show( this, "ユーザーの登録を行ってください" );
                    return;
            }

            this.Close();
        }

    }
}
