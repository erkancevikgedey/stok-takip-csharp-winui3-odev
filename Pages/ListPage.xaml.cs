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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace StokTakip.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage : Page
    {
        private readonly IItemService _itemService;
        List<Product> items;
        ObservableCollection<Product> PeopleFiltered;

        public ListPage()
        {
            this.InitializeComponent();
            _itemService = new ItemService();
            items = _itemService.GetProducts();
            PeopleFiltered = new ObservableCollection<Product>(items);
            lvDataBinding.ItemsSource = PeopleFiltered;
        }
        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public override string ToString()
            {
                return this.Name + ", " + this.Age + " years old";
            }
        }


        private void FilteredLV_LNameChanged(object sender, TextChangedEventArgs e)
        {
            /* Perform a Linq query to find all Person objects (from the original People collection)
            that fit the criteria of the filter, save them in a new List called TempFiltered. */
            List<Product> TempFiltered;

            /* Make sure all text is case-insensitive when comparing, and make sure 
            the filtered items are in a List object */
            
            TempFiltered = items.Where(x => x.ProductName.Contains(FilterByLName.Text, StringComparison.InvariantCultureIgnoreCase)).ToList();

            /* Go through TempFiltered and compare it with the current PeopleFiltered collection,
            adding and subtracting items as necessary: */

            // First, remove any Person objects in PeopleFiltered that are not in TempFiltered
            for (int i = PeopleFiltered.Count - 1; i >= 0; i--)
            {
                var item = PeopleFiltered[i];
               
                if (!TempFiltered.Contains(item))
                {
                    PeopleFiltered.Remove(item);
                }
            }

            /* Next, add back any Person objects that are included in TempFiltered and may 
            not currently be in PeopleFiltered (in case of a backspace) */

            foreach (var item in TempFiltered)
            {
                if (!PeopleFiltered.Contains(item))
                {
                    PeopleFiltered.Add(item);
                }
            }
        }

        private async void ProductEditButtonClicked(object sender, RoutedEventArgs e)
        {
            Button _myButton = (Button)sender;
            int value = (int)_myButton.CommandParameter;

            var dialogPage = new EditPage(_itemService.GetProductName(value), _itemService.GetProductQuantity(value));

            var contentDialog = new ContentDialog()
            {
                PrimaryButtonText = "Düzenle",
                SecondaryButtonText = "",
                CloseButtonText = "İptal",
                DefaultButton = ContentDialogButton.Secondary,
                Content = dialogPage,
                XamlRoot = this.Content.XamlRoot
            };
            var result = await contentDialog.ShowAsync();
           


            if (result == ContentDialogResult.Primary)
            {
                bool status = _itemService.EditProduct(value, dialogPage.ItemName, dialogPage.ItemQuantity);
                if (status)
                {
                    SuccessMessageBar.Visibility = Visibility.Visible;
                    items = _itemService.GetProducts();
                    PeopleFiltered = new ObservableCollection<Product>(items);
                    lvDataBinding.ItemsSource = PeopleFiltered;
                }
                else
                {
                    ErrorMessageBar.Visibility = Visibility.Visible;
                }
            }
            else
            {
                // iptal butonu
            }
        }

        private async void UrunStokAzaltButonu(object sender, RoutedEventArgs e)
        {
            Button _myButton = (Button)sender;
            int value = (int)_myButton.CommandParameter;
            var dialogPage = new AddStockPage();

            var contentDialog = new ContentDialog()
            {
                PrimaryButtonText = "Azalt",
                SecondaryButtonText = "",
                CloseButtonText = "İptal",
                DefaultButton = ContentDialogButton.Secondary,
                Content = dialogPage,
                XamlRoot = this.Content.XamlRoot
            };

            var result = await contentDialog.ShowAsync();
            var neyleGidecegi = dialogPage.Sayi;
            if (result == ContentDialogResult.Primary)
            {
                bool status = _itemService.RemoveStockFromProduct(value, dialogPage.Sayi);
                if (status)
                {
                    SuccessMessageBar.Visibility = Visibility.Visible;
                    items = _itemService.GetProducts();
                    PeopleFiltered = new ObservableCollection<Product>(items);
                    lvDataBinding.ItemsSource = PeopleFiltered;
                }
                else
                {
                    ErrorMessageBar.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Debug.WriteLine("iptal butonu");
            }
        }

        private async void UrunStokEkleButonu(object sender, RoutedEventArgs e)
        {
            Button _myButton = (Button)sender;
            int value = (int)_myButton.CommandParameter;

            var dialogPage = new AddStockPage();

            var contentDialog = new ContentDialog()
            {
                PrimaryButtonText = "Ekle",
                SecondaryButtonText = "",
                CloseButtonText = "İptal",
                DefaultButton = ContentDialogButton.Secondary,
                Content = dialogPage,
                XamlRoot = this.Content.XamlRoot
            };

            var result = await contentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                bool status = _itemService.AddStockToProduct(value, dialogPage.Sayi);
                if (status)
                {
                    SuccessMessageBar.Visibility = Visibility.Visible;
                    items = _itemService.GetProducts();
                    PeopleFiltered = new ObservableCollection<Product>(items);
                    lvDataBinding.ItemsSource = PeopleFiltered;
                }
                else
                {
                    ErrorMessageBar.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Debug.WriteLine("iptal butonu");
            }
        }

        private async void UrunSilButonu(object sender, RoutedEventArgs e)
        {
            Button _myButton = (Button)sender;
            int value = (int)_myButton.CommandParameter;
            var contentDialog = new ContentDialog()
            {
                Title = "Silmek istediğinizden emin misiniz?",
                PrimaryButtonText = "Evet",
                CloseButtonText = "Vazgeç",
                DefaultButton = ContentDialogButton.Secondary,
                Content = "Ürün tamamen silinecek.",
                XamlRoot = this.Content.XamlRoot
            };

            var result = await contentDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                bool deleteProductStatus = _itemService.DeleteProduct(value);
                if (deleteProductStatus)
                {
                    // başarıyla sildi
                    items = _itemService.GetProducts();
                    PeopleFiltered = new ObservableCollection<Product>(items);
                    lvDataBinding.ItemsSource = PeopleFiltered;
                }
                else
                {
                    // başarısız 
                    ErrorMessageBar.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Debug.WriteLine("iptal butonu");
            }
        }


    }

}
