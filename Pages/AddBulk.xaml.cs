using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace StokTakip.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddBulk : Page
    {
        private readonly IItemService _itemService;

        public AddBulk()
        {
            this.InitializeComponent();
            _itemService = new ItemService();
        }
        private void UrunEkleClick(object sender, RoutedEventArgs e)
        {

            Random rnd = new Random();
            int howManyPieces = (int)GenerateCount.Value;
            var randomizerText = RandomizerFactory.GetRandomizer(new FieldOptionsTextWords { Min = 3, Max = 4 });
            for (int i = 0; i < howManyPieces; i++)
            {
                string randomProductName = randomizerText.Generate();
                int randomStock = rnd.Next(10, 150);
                _itemService.AddProduct(randomProductName, randomStock);
            }
            SuccessMessageBar.Visibility = Visibility.Visible;
        }
    }
}
