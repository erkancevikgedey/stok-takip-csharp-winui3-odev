using Microsoft.UI.Text;
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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace StokTakip.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReportPage : Page
    {
        private readonly IItemService _itemService;
        public ReportPage()
        {
            this.InitializeComponent();
            _itemService = new ItemService();
            List<Product> products = _itemService.GetProducts();
            string startText = "";
            foreach (Product product in products)
            {
                startText += $"Ürün Adı: {product.ProductName} - Ürün Stok: {product.ProductStock}\n";
            }
            richEditBox.IsReadOnly = false;
            richEditBox.Document.SetText(TextSetOptions.None, startText);
            richEditBox.IsReadOnly = true;
        }

        private void CopyEvent(object sender, RoutedEventArgs e)
        {
            var dataPackage = new DataPackage();
            var value = "";
            richEditBox.Document.GetText(Microsoft.UI.Text.TextGetOptions.AdjustCrlf, out value);
            dataPackage.SetText(value);
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
        }
    }
}
