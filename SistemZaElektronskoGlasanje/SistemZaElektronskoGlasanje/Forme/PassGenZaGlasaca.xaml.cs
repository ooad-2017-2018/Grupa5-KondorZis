using System;
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
    public sealed partial class PassGenZaGlasaca : Page
    {

        public PassGenZaGlasaca()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LicnaKarta.Text == "")
                { 
                    Greska.Text = "Polje prazno!\nUnesite broj lične karte korisnika za kojeg generisete password";
                    return;
                }
                if (LicnaKarta.Text.Count() != 9)
                {
                    Greska.Text = "Neispravan broj lične karte";
                    return;
                }
                Glasac g = Izbori.DajGlasaca(LicnaKarta.Text);
                Password.Text = g.genPass();
            }
            catch(Exception eks)
            {
                Greska.Text = eks.Message;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
