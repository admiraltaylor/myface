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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // start with the login
            GenerateLoginScreen();
        }

        internal void GenerateLoginScreen()
        {
            Grid_Main.Children.Clear();
            uc_Login logIn = new uc_Login(this);
            Grid_Main.Children.Add(logIn);
        }

        internal void GenerateSignUpScreen()
        {
            Grid_Main.Children.Clear();
            uc_SignUp signUp = new uc_SignUp(this);
            Grid_Main.Children.Add(signUp);
        }
    }
}
