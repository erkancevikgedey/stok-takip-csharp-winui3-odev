using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using StokTakip.Models;
using StokTakip.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace StokTakip.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private readonly ILoginService _loginService;
        public Member _member;
        public LoginPage()
        {
            this.InitializeComponent();
            _loginService = new LoginService();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string inputUsername = UsernameTextBox.Text;
            string inputPassword = PasswordTextBox.Text;

            bool isLoggedIn = _loginService.LoginApp(inputUsername, inputPassword);

            if (isLoggedIn) // giriş başarılı
            {
                this.Frame.Navigate(typeof(HomePage));
                MainWindow.MenuItems[0].IsEnabled = false;
            }
            else // giriş başarısız
            {
                ErrorMessageBar.Visibility = Visibility.Visible;
            }

        }
    }
}
