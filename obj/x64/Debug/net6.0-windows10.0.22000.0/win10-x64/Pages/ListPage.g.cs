﻿#pragma checksum "C:\Users\erkan\source\repos\StokTakip\StokTakip\Pages\ListPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AA7502B74FDEC7BA758CD1F12A73F9DCCBA35031774480F8ED657DAE2D512CA4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakip.Pages
{
    partial class ListPage : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\ListPage.xaml line 21
                {
                    this.ErrorMessageBar = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.InfoBar>(target);
                }
                break;
            case 3: // Pages\ListPage.xaml line 35
                {
                    this.SuccessMessageBar = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.InfoBar>(target);
                }
                break;
            case 4: // Pages\ListPage.xaml line 49
                {
                    this.WelcomeMessage = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Border>(target);
                }
                break;
            case 5: // Pages\ListPage.xaml line 59
                {
                    this.lvDataBinding = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
                }
                break;
            case 9: // Pages\ListPage.xaml line 87
                {
                    global::Microsoft.UI.Xaml.Controls.Button element9 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element9).Click += this.UrunSilButonu;
                }
                break;
            case 10: // Pages\ListPage.xaml line 88
                {
                    global::Microsoft.UI.Xaml.Controls.Button element10 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element10).Click += this.ProductEditButtonClicked;
                }
                break;
            case 11: // Pages\ListPage.xaml line 89
                {
                    global::Microsoft.UI.Xaml.Controls.Button element11 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element11).Click += this.UrunStokEkleButonu;
                }
                break;
            case 12: // Pages\ListPage.xaml line 90
                {
                    global::Microsoft.UI.Xaml.Controls.Button element12 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element12).Click += this.UrunStokAzaltButonu;
                }
                break;
            case 13: // Pages\ListPage.xaml line 53
                {
                    this.FilterByLName = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)this.FilterByLName).TextChanged += this.FilteredLV_LNameChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
