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
    public sealed partial class GlasanjeViseKandidata : Page
    {
        Parametri p;
        Utrka u;
        public GlasanjeViseKandidata()
        {
            this.InitializeComponent();
            List<Stranka> lists = new List<Stranka>();
            Stranka apple = new Stranka("Apple","Silicon valley");
            Stranka ms = new Stranka("Microsoft", "Silicon valley");
            ms.DodajKandidata(new Kandidat("William Henry", "Gates III", "Silicon Walley", 1472583691476, Kandidat.Nacionalnost.Ostali));
            apple.DodajKandidata(new Kandidat("Steve", "Jobs", "Silicon Walley", 1472583691477, Kandidat.Nacionalnost.Ostali));
            apple.DodajKandidata(new Kandidat("Steve", "Wozniack", "Silicon Walley", 1472583691478, Kandidat.Nacionalnost.Ostali));
            lists.Add(apple);
            lists.Add(ms);
            groupListView.ItemsSource = lists;
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*if (Kandidati.SelectedItem is Kandidat)
                p.gl.Izbor.Add(new StavkaListica(u, Kandidati.SelectedItem as Kandidat));*/
            if (p.utrke.Count == 0)
                this.Frame.Navigate(typeof(PredajaListica), p);
            else if (p.utrke[0].t == Utrka.Tip.Vise)
                this.Frame.Navigate(typeof(GlasanjeViseKandidata), p);
            else
                this.Frame.Navigate(typeof(GlasanjeJedanKandidat), p);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
