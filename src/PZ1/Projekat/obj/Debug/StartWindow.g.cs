﻿#pragma checksum "..\..\StartWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3AAE1A6397591DC7BBEF83078BAA69E930F88E9E58F8A6C65BEA6A9CEE4EF9DC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekat;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Projekat {
    
    
    /// <summary>
    /// StartWindow
    /// </summary>
    public partial class StartWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 57 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelNaslov;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridIgraci;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDodavanje;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonObrisi;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonIzlaz;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Projekat;component/startwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StartWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\StartWindow.xaml"
            ((Projekat.StartWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.labelNaslov = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.dataGridIgraci = ((System.Windows.Controls.DataGrid)(target));
            
            #line 60 "..\..\StartWindow.xaml"
            this.dataGridIgraci.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridIgraci_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 60 "..\..\StartWindow.xaml"
            this.dataGridIgraci.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DataGridIgraci_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonDodavanje = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\StartWindow.xaml"
            this.buttonDodavanje.Click += new System.Windows.RoutedEventHandler(this.ButtonDodavanje_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttonObrisi = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\StartWindow.xaml"
            this.buttonObrisi.Click += new System.Windows.RoutedEventHandler(this.ButtonObrisi_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttonIzlaz = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\StartWindow.xaml"
            this.buttonIzlaz.Click += new System.Windows.RoutedEventHandler(this.ButtonIzlaz_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 66 "..\..\StartWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.CbBrisanje_MouseEnter);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 76 "..\..\StartWindow.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.Hyperlink_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

