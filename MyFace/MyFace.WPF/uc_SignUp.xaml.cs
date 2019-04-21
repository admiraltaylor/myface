using MyFace.Common;
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
    /// Interaction logic for uc_SignUp.xaml
    /// </summary>
    public partial class uc_SignUp : UserControl
    {
        private MainWindow _Parent_MainWindow;
        private MyFace.BL.MyFace _MyFace = new MyFace.BL.MyFace();

        public uc_SignUp(MainWindow parent)
        {
            _Parent_MainWindow = parent;

            InitializeComponent();
        }

        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            // in parent, destroy this and create a signup control
            _Parent_MainWindow.GenerateLoginScreen();
        }

        private void Button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            // method to do actual sign up and log in new user
            AttemptUserSignUpFromUIInputs();
        }

        // TL - 03.30.19
        private void AttemptUserSignUpFromUIInputs()
        {
            // Here we're just validating that the passwords match each other; we should do more validation
            if (PasswordBox_Password.Password == PasswordBox_ConfirmPassword.Password)
            {
                // clean up the data 
                string firstName = TextBox_FirstName.Text.Trim();
                string lastName = TextBox_LastName.Text.Trim();

                // later, add validation to make sure this is an email
                string email = TextBox_Email.Text.Trim();

                // later, add validation to make sure password is secure enough
                string password = PasswordBox_Password.Password;

                try
                {
                    User newUser = _MyFace.SignUpNewUser(firstName, lastName, email, password);

                    if (newUser.Id != 0) // signing up will return the user with an Id
                    {
                        // Todo: Method to log in user
                        //  + Log User In with that method
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write(ex);
                }
            }
            else
            {
                L_Error.Content = "Passwords do not match";
            }
        }

        #region UI Methods

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = null;
        }

        #endregion
    }
}
