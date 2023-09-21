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
using TimeCard.Info;
using TimeCard.Utility;
using TimeCard.Controller;

namespace TimeCard.Window
{
    /// <summary>
    /// UserAddWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class UserAddWindow : System.Windows.Window
    {
        public UserAddWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Click( object sender, RoutedEventArgs e )
        {
            this.Close();
        }

        private void Regist_Click( object sender, RoutedEventArgs e )
        {
            if ( UserNoBox.Text.Length == 0 && PasswordBox.Password.Length == 0 )
            {
                MessageBox.Show( this, "社員番号とパスワードを入力してください" );
                return;
            }

            if ( PasswordBox.Password.Length < 8 )
            {
                MessageBox.Show( this, "パスワードはセキュリティの為\n8文字以上でお願いします" );
                return;
            }

            if ( PasswordBox.Password != RePasswordBox.Password )
            {
                MessageBox.Show( this, "確認のパスワードが異なってます" );
                return;
            }

            UserInfo user_info;
            string password = Sha256.CreateSHA256( PasswordBox.Password );

            if ( UserNameBox.Text.Length == 0 )
            {
                user_info = new UserInfo( UserNoBox.Text, password );
            }
            else
            {
                user_info = new UserInfo( UserNoBox.Text, password, UserNameBox.Text );
            }

            var result = UserController.AddUser( user_info );

            if ( !result.success )
            {
                MessageBox.Show( this, result.message );
                return;
            }

            MessageBox.Show( this, user_info.UserNo + "\n" + user_info.Name + "\n登録完了しました" );
            this.Close();
        }
    }
}
