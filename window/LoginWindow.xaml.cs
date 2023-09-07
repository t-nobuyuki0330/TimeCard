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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if ( LoginUserNo.Text == "" )
            {
                MessageBox.Show( this, "社員番号を入力してください" );
                return;
            }

            if ( LoginPassword.Password == "" )
            {
                MessageBox.Show( this, "パスワードを入力してください" );
                return;
            }

            var main_window = new MainWindow( LoginUserNo.Text );
            main_window.Show();
            this.Close();
        }
    }
}
