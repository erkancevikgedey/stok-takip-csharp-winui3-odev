﻿#pragma checksum "C:\Users\erkan\source\repos\StokTakip\StokTakip\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2D1194F774EE8CB55B612B0C5CE92E240FC0E4CF0D7D32E7D77680C513F629D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakip
{
    partial class MainWindow : 
        global::Microsoft.UI.Xaml.Window, 
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
            case 2: // MainWindow.xaml line 11
                {
                    this.NavView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationView>(target);
                    ((global::Microsoft.UI.Xaml.Controls.NavigationView)this.NavView).ItemInvoked += this.NavView_ItemInvoked;
                    ((global::Microsoft.UI.Xaml.Controls.NavigationView)this.NavView).Loaded += this.NavView_Loaded;
                }
                break;
            case 3: // MainWindow.xaml line 13
                {
                    this.test5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationViewItem>(target);
                }
                break;
            case 4: // MainWindow.xaml line 25
                {
                    this.MainPagesHeader = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationViewItemHeader>(target);
                }
                break;
            case 5: // MainWindow.xaml line 27
                {
                    this.test = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationViewItem>(target);
                }
                break;
            case 6: // MainWindow.xaml line 33
                {
                    this.test2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationViewItem>(target);
                }
                break;
            case 7: // MainWindow.xaml line 39
                {
                    this.test4 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationViewItem>(target);
                }
                break;
            case 8: // MainWindow.xaml line 47
                {
                    this.test3 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationViewItem>(target);
                }
                break;
            case 9: // MainWindow.xaml line 51
                {
                    this.ContentFrame = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Frame>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Frame)this.ContentFrame).NavigationFailed += this.ContentFrame_NavigationFailed;
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
