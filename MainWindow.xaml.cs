using StokTakip.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using StokTakip.Services;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace StokTakip
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private IntPtr hWnd = IntPtr.Zero;
        private AppWindow appW = null;
        private OverlappedPresenter presenter = null;
        public static List<NavigationViewItem> MenuItems { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();
            hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId wndId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            appW = AppWindow.GetFromWindowId(wndId);
            presenter = appW.Presenter as OverlappedPresenter;
            presenter.IsResizable = false;
            presenter.IsMaximizable = false;
            appW.Resize(new Windows.Graphics.SizeInt32(1400, 800));


        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Sayfa yüklenemedi " + e.SourcePageType.FullName);
        }

        private readonly List<(string Tag, Type Page)> _pages =
            new List<(string Tag, Type Page)>
        {
            ("home", typeof(HomePage)),
            ("list", typeof(ListPage)),
            ("add", typeof(AddPage)),
            ("report", typeof(ReportPage)),
            ("about", typeof(AboutPage)),
            ("addbulk", typeof(AddBulk)),
            ("changepswd", typeof(ChangePasswordPage)),
            ("details", typeof(DetailsPage)),
            ("currency", typeof(CurrencyPage))
        };

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigated += On_Navigated;
            NavView.SelectedItem = NavView.MenuItems[0];
            NavView_Navigate("home", new EntranceNavigationTransitionInfo());
        }

        private void NavView_ItemInvoked(NavigationView sender,
                                         NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                if(navItemTag == "cikis")
                {
                    var window = new LoginWindow();
                    window.Activate();
                    this.Close();
                }

                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }


        private void NavView_Navigate(
            string navItemTag,
            NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            
            var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
            _page = item.Page;

            var preNavPageType = ContentFrame.CurrentSourcePageType;

            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            NavView.IsBackEnabled = ContentFrame.CanGoBack;

            if (ContentFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);
                if (item.Page is null)
                    return;


                NavView.SelectedItem = NavView.MenuItems
                    .OfType<NavigationViewItem>()
                    .FirstOrDefault(n => n.Tag.Equals(item.Tag)) == null ? 
                    NavView.FooterMenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.Tag)) : NavView.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.Tag));

                NavView.Header =
                    ((NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();
            }
        }
    }
}
