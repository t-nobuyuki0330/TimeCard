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
using TimeCard.info;

namespace TimeCard.window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StampWindow : Window
    {
        private DispatcherTimer Timer;
        private UserInfo UserInfoData;

        public StampWindow( UserInfo user_info )
        {
            InitializeComponent();

            UserInfoData = user_info;

            UserNoLabel.Text = UserInfoData.Name;

            // タイマー生成処理
            Timer = CreateTimer();

            Timer.Start();
        }

        private DispatcherTimer CreateTimer() {
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
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss" ) + "\n" + UserInfoData.UserNo + " : " + UserInfoData.Name + "\n[ 出 ] 打刻しました" );
            Application.Current.Shutdown();
        }

        private void BreakButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss") + "\n" + UserInfoData.UserNo + " : " + UserInfoData.Name + "\n[ 外 ] 打刻しました");
            Application.Current.Shutdown();
        }

        private void BreakEndButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss") + "\n" + UserInfoData.UserNo + " : " + UserInfoData.Name + "\n[ 戻 ] 打刻しました");
            Application.Current.Shutdown();
        }

        private void LeavingButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss") + "\n" + UserInfoData.UserNo + " : " + UserInfoData.Name + "\n[ 退 ] 打刻しました" );
            Application.Current.Shutdown();
        }
    }
}
