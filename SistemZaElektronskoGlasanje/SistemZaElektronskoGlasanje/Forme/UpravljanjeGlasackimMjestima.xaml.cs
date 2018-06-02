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
    ///
    public sealed partial class UpravljanjeGlasackimMjestima : Page
    {
        public UpravljanjeGlasackimMjestima()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Ime.Text == "")
                Greska.Text = "UNESITE LOKACIJU GLASAČKOG MJESTA";
            else
                try
                {
                    Izbori.DodajGMjesto(new GlasackoMjesto(Ime.Text));
                    Greska.Text = "";
                    Ime.Text = "";
                }
                catch(Exception eks)
                {
                    Greska.Text = eks.Message;
                }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Brisanje.Text == "")
               bGreska.Text = "UNESITE LOKACIJU GLASAČKOG MJESTA";
            else
                try
                {
                    Izbori.ObrisiGMjesto(Brisanje.Text);
                    bGreska.Text = "";
                    Brisanje.Text = "";
                }
                catch (Exception eks)
                {
                    bGreska.Text = eks.Message;
                }
        }
    }
}