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

namespace StokTakip.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChangePasswordPage : Page
    {
        private readonly IMemberService _memberService;
        public ChangePasswordPage()
        {
            this.InitializeComponent();
            _memberService = new MemberService();
        }

        private void passwordChangeButtonClick(object sender, RoutedEventArgs e)
        {
            string password = passwordBox.Text;
            string username = usernameBox.Text;
            bool status = _memberService.ChangePassword(username, password);
            if (status)
            {
                infomsg.Visibility = Visibility.Visible;
            }
            
        }
    }
}
