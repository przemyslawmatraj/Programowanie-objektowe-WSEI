﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A1D289870628EC031DF544AFDDB7BC74FFD4DACD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Aplikacja;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Aplikacja {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputAmount;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OutputAmount;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CalcBtn;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox OutputCurrency;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox InputCurrency;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadFileButton;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveFileJsonButton;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenFileJsonButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Aplikacja;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.InputAmount = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\MainWindow.xaml"
            this.InputAmount.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidation);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OutputAmount = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.OutputAmount.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidation);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CalcBtn = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\MainWindow.xaml"
            this.CalcBtn.Click += new System.Windows.RoutedEventHandler(this.CalcResult);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OutputCurrency = ((System.Windows.Controls.ComboBox)(target));
            
            #line 55 "..\..\..\MainWindow.xaml"
            this.OutputCurrency.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.InputCurrency = ((System.Windows.Controls.ComboBox)(target));
            
            #line 56 "..\..\..\MainWindow.xaml"
            this.InputCurrency.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.InputCurrency_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LoadFileButton = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\MainWindow.xaml"
            this.LoadFileButton.Click += new System.Windows.RoutedEventHandler(this.LoadFileButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SaveFileJsonButton = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\MainWindow.xaml"
            this.SaveFileJsonButton.Click += new System.Windows.RoutedEventHandler(this.SaveFileJson);
            
            #line default
            #line hidden
            return;
            case 8:
            this.OpenFileJsonButton = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\MainWindow.xaml"
            this.OpenFileJsonButton.Click += new System.Windows.RoutedEventHandler(this.OpenFileJson);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

