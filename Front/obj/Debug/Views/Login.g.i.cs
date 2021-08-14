﻿#pragma checksum "..\..\..\Views\Login.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A8F1FAA325A656383D9B1287594D9FDB5E1A95AD182332F3E6A76C2372256420"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Front.Views;
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


namespace Front.Views {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCaption;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUsername;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPasswd;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUsername;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPasswd;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
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
            System.Uri resourceLocater = new System.Uri("/Front;component/views/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Login.xaml"
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
            this.lblCaption = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblUsername = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblPasswd = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.tbUsername = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\Views\Login.xaml"
            this.tbUsername.GotFocus += new System.Windows.RoutedEventHandler(this.tbUsername_GotFocus);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Views\Login.xaml"
            this.tbUsername.LostFocus += new System.Windows.RoutedEventHandler(this.tbUsername_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbPasswd = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\Views\Login.xaml"
            this.tbPasswd.GotFocus += new System.Windows.RoutedEventHandler(this.tbPasswd_GotFocus);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\Views\Login.xaml"
            this.tbPasswd.LostFocus += new System.Windows.RoutedEventHandler(this.tbPasswd_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Views\Login.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

