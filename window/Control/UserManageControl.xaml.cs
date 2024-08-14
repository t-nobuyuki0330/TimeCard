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

namespace TimeCard.Window.Control
{
    /// <summary>
    /// UserManageControl.xaml の相互作用ロジック
    /// </summary>
    public partial class UserManageControl : UserControl
    {

        public event EventHandler AddButtonEvent;
        public event EventHandler EventButtonEvent;

        public UserManageControl()
        {
            InitializeComponent();
        }

        private void AddButton_Click( object sender, RoutedEventArgs e )
        {
            AddButtonEvent( sender, e );
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EventButtonEvent( sender, e );
        }
    }
}
