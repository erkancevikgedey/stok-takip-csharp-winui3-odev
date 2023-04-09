using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using StokTakip.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace StokTakip
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginWindow : Window
    {
        private IntPtr hWnd = IntPtr.Zero;
        private AppWindow appW = null;
        private OverlappedPresenter presenter = null;
        private readonly ILoginService _loginService;
        public LoginWindow()
        {
            this.InitializeComponent();
            hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId wndId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            appW = AppWindow.GetFromWindowId(wndId);
            presenter = appW.Presenter as OverlappedPresenter;
            presenter.IsResizable = false;
            presenter.IsMaximizable = false;
            appW.Resize(new Windows.Graphics.SizeInt32(900, 800));
            _loginService = new LoginService();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string inputUsername = UsernameTextBox.Text;
            string inputPassword = PasswordTextBox.Password;

            bool isLoggedIn = _loginService.LoginApp(inputUsername, inputPassword);

            if (isLoggedIn) // giriş başarılı
            {
                var window = new MainWindow();
                window.Activate();
                this.Close();
            }
            else // giriş başarısız
            {
                ErrorMessageBar.Visibility = Visibility.Visible;
            }
        }
    }
}
