using MyFace.Data;
using MyFace.Domain;
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

        UserSqliteRepository userRepo = new UserSqliteRepository();

        public MainWindow()
        {
            InitializeComponent();

            // start with the login
            GenerateLoginScreen();

            List<User> users = userRepo.DownloadAllUsers();

            bool deleteTest = userRepo.DeleteUserFromDb(users[0].Id);

            userRepo.SignUpNewUser("Tater", "Lowery", "taylor@gmail.com", "test");

            //userRepo.LogInUser("taylor@gmail.com", "test1");

            userRepo.LogInUser("taylor@gmail.com", "test");

            

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
