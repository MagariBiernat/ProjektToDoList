<<<<<<< HEAD
﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E1D4349AF9FF74944A94DE772AA3D5A80C7AC947"
=======
﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "01E2330105E1E5C580D13C66C7FEF9EFD9B0787F7BC6E2F242AC5081E649C148"
>>>>>>> 5903312497222a073c2590b667ca9675881b9076
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using ToDoList;
using ToDoList.ViewModels;
using ToDoList.Views;


namespace ToDoList {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
<<<<<<< HEAD
        #line 65 "..\..\MainWindow.xaml"
=======
        #line 68 "..\..\MainWindow.xaml"
>>>>>>> 5903312497222a073c2590b667ca9675881b9076
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OnGoingTasks_Bttn;
        
        #line default
        #line hidden
        
        
<<<<<<< HEAD
        #line 66 "..\..\MainWindow.xaml"
=======
        #line 69 "..\..\MainWindow.xaml"
>>>>>>> 5903312497222a073c2590b667ca9675881b9076
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CompletedTasks_Bttn;
        
        #line default
        #line hidden
        
        
<<<<<<< HEAD
        #line 81 "..\..\MainWindow.xaml"
=======
        #line 85 "..\..\MainWindow.xaml"
>>>>>>> 5903312497222a073c2590b667ca9675881b9076
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Create_Task;
        
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
            System.Uri resourceLocater = new System.Uri("/ToDoList;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.OnGoingTasks_Bttn = ((System.Windows.Controls.Button)(target));
            
<<<<<<< HEAD
            #line 65 "..\..\MainWindow.xaml"
=======
            #line 68 "..\..\MainWindow.xaml"
>>>>>>> 5903312497222a073c2590b667ca9675881b9076
            this.OnGoingTasks_Bttn.Click += new System.Windows.RoutedEventHandler(this.OnGoingTasks_Bttn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CompletedTasks_Bttn = ((System.Windows.Controls.Button)(target));
            
<<<<<<< HEAD
            #line 66 "..\..\MainWindow.xaml"
=======
            #line 69 "..\..\MainWindow.xaml"
>>>>>>> 5903312497222a073c2590b667ca9675881b9076
            this.CompletedTasks_Bttn.Click += new System.Windows.RoutedEventHandler(this.CompletedTasks_Bttn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 70 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 77 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Create_Task = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

