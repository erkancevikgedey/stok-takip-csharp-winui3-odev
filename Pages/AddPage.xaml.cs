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
    public sealed partial class AddPage : Page
    {
        private readonly IItemService _itemService;
        public AddPage()
        {
            this.InitializeComponent();
            _itemService = new ItemService();
        }

        private void AddProductButtonClick(object sender, RoutedEventArgs e)
        {
            string productName = ProductNameTextBox.Text;
            int productQuantity = (int)ProductQuantityBox.Value;
            if (String.IsNullOrEmpty(ProductNameTextBox.Text))
            {
                ErrorMessageBar.Visibility = Visibility.Visible;
            }
            else
            {
                _itemService.AddProduct(productName, productQuantity);
            }

        }
    }
}
