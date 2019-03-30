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

namespace MyFace.WPF
{
    /// <summary>
    /// Interaction logic for uc_Login.xaml
    /// </summary>
    public partial class uc_Login : UserControl
    {
        private MainWindow _Parent_MainWindow;

        public uc_Login(MainWindow parent)
        {
            _Parent_MainWindow = parent;

            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = null;
        }

        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            // method for logging in
        }
        
        private void Button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            // In parent, clear parent and create a signup control
            _Parent_MainWindow.GenerateSignUpScreen();
        }
    }
}
