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
using TimeCard.Info;
using TimeCard.Controller;

namespace TimeCard.Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StampWindow : System.Windows.Window
    {
        private DispatcherTimer Timer;
        private UserInfo UserInfoData;
        string Status = "[ 退勤 ]";

        public StampWindow( UserInfo user_info )
        {
            InitializeComponent();

            this.StateChanged += new EventHandler( WindowStateChanged );

            UserInfoData = user_info;

            UserNoLabel.Text = UserInfoData.Name;

            Status = StampController.GetStatus( user_info );
            if ( Status.Equals( "[ 出勤 ]" ) )
            {
                StatusLabel.Foreground = new SolidColorBrush( Colors.Blue );
            }
            else
            {
                StatusLabel.Foreground = new SolidColorBrush( Colors.Red );
            }

            StatusLabel.Text = Status;

            // タイマー生成処理
            Timer = CreateTimer();

            Timer.Start();
        }

        public void WindowStateChanged( object sender, EventArgs e )
        {
            if ( this.WindowState == WindowState.Minimized )
            {
                Timer.Stop();
                Timer = null;
            }

            if ( this.WindowState == WindowState.Normal )
            {
                Timer = CreateTimer();
                Timer.Start();
            }
        }

        private DispatcherTimer CreateTimer() {
            var timer = new DispatcherTimer( DispatcherPriority.Background );
            // 100ミリでインターバル
            timer.Interval = TimeSpan.FromMilliseconds( 300 );

            timer.Tick += ( sender, e ) => {
                TimeView.Text = DateTime.Now.ToString( "MM/dd [dddd] HH:mm:ss" );
            };

            return timer;
        }

        public void AttendButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss" ) + "\n" + UserInfoData.UserNo + " : " + UserInfoData.Name + "\n[ 出 ] 打刻しました" );
            StampController.Attend( UserInfoData );
            StatusLabel.Text = "[ 出勤 ]";
            StatusLabel.Foreground = new SolidColorBrush( Colors.Blue );
            //Application.Current.Shutdown();
        }

        private void BreakButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss") + "\n" + UserInfoData.UserNo + " : " + UserInfoData.Name + "\n[ 休 ] 打刻しました");
            StampController.Break( UserInfoData );
            StatusLabel.Text = "[ 休憩 ]";
            StatusLabel.Foreground = new SolidColorBrush( Colors.Red );

            //Application.Current.Shutdown();
        }

        private void BreakEndButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss") + "\n" + UserInfoData.UserNo + " : " + UserInfoData.Name + "\n[ 戻 ] 打刻しました");
            StampController.BreakEnd( UserInfoData );
            StatusLabel.Text = "[ 出勤 ]";
            StatusLabel.Foreground = new SolidColorBrush( Colors.Blue );
            //Application.Current.Shutdown();
        }

        private void LeavingButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( this, DateTime.Now.ToString( "yyy/MM/dd ddd HH:mm:ss") + "\n" + UserInfoData.UserNo + " : " + UserInfoData.Name + "\n[ 退 ] 打刻しました" );
            StampController.Leaving( UserInfoData );
            StatusLabel.Text = "[ 退勤 ]";
            StatusLabel.Foreground = new SolidColorBrush( Colors.Red );

            //Application.Current.Shutdown();
        }
    }
}
