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
    public sealed partial class GlasanjeJedanKandidat : Page
    {
        Parametri p;
        Utrka u;
        public GlasanjeJedanKandidat()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            p = (Parametri)e.Parameter;
            u = p.utrke[0];
            Naziv.Text = u.Naziv;
            p.utrke.Remove(u);
            base.OnNavigatedTo(e);
            foreach (Kandidat k in u.Kandidati)
                Kandidati.Items.Add(k);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Kandidati.SelectedItem is Kandidat)
                p.gl.Izbor.Add(new StavkaListica(u,Kandidati.SelectedItem as Kandidat));
            if(p.utrke.Count==0)
                this.Frame.Navigate(typeof(PredajaListica),p);
            else if(p.utrke[0].t ==Utrka.Tip.Vise)
                this.Frame.Navigate(typeof(GlasanjeViseKandidata),p);
            else
                this.Frame.Navigate(typeof(GlasanjeJedanKandidat),p);
        }
    }
}
