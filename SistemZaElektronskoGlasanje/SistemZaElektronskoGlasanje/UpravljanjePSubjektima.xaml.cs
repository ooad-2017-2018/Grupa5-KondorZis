﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SistemZaElektronskoGlasanje
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpravljanjePSubjektima : Page
    {
        bool a;
        public UpravljanjePSubjektima()
        {
            this.InitializeComponent();
            a = false;
        }
        
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Sjediste.IsEnabled = false;
            a = true;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            if(a)
                Sjediste.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
