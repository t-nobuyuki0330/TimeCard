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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TimeCard.window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer Timer;
        private string          UserNo;
        private string          UserName = "名称未設定";

        public MainWindow( string user_no )
        {
            InitializeComponent();

            UserNo = user_no;
            // ユーザー名取得処理
            UserNoLabel.Text = UserName;

            // タイマー生成処理
            Timer = CreateTimer();

            Timer.Start();
        }

        private DispatcherTimer CreateTimer() {
            // アイドル優先
            var timer = new DispatcherTimer( DispatcherPriority.Normal );
            // 100ミリでインターバル
            timer.Interval = TimeSpan.FromMilliseconds( 100 );

            timer.Tick += ( sender, e ) => {
                TimeView.Text = DateTime.Now.ToString( "MM/dd [dddd] HH:mm:ss" );
            };

            return timer;
        }

        public void AttendButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss" ) + "\n" + UserNo + " : " + UserName + "\n[ 出 ] 打刻しました" );
            Application.Current.Shutdown();
        }

        private void BreakButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss") + "\n" + UserNo + " : " + UserName + "\n[ 外 ] 打刻しました");
            Application.Current.Shutdown();
        }

        private void BreakEndButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss") + "\n" + UserNo + " : " + UserName + "\n[ 戻 ] 打刻しました");
            Application.Current.Shutdown();
        }

        private void LeavingButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss") + "\n" + UserNo + " : " + UserName + "\n[ 退 ] 打刻しました" );
            Application.Current.Shutdown();
        }
    }
}
