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
    public sealed partial class CurrencyPage : Page
    {
        private readonly ICurrencyService _currencyService;
        public CurrencyPage()
        {
            this.InitializeComponent();
            _currencyService = new CurrencyService();
            CurDatePicker.SelectedDate = DateTime.Now;
            CurDatePicker.IsEnabled = false;
        }

        private async void GetCurrencyButtonClicked(object sender, RoutedEventArgs e)
        {
            if(termsOfCurrency.IsChecked == true)
            {
                ErrorMessageBar.Visibility = Visibility.Collapsed;
                string kur = await _currencyService.GetCurrency();
                SuccessMessageBar.Message = $"1 Dolar Alış Fiyatı {kur} TL";
                SuccessMessageBar.Visibility = Visibility.Visible;
            }
            else
            {
                ErrorMessageBar.Visibility = Visibility.Visible;
            }
            
        }
    }
}
