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

namespace SistemZaElektronskoGlasanje
{
    public sealed partial class DodavanjeClanova: Page
    {
        ClanKomisije korisnik;
        public DodavanjeClanova()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            korisnik = (ClanKomisije)e.Parameter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Int64 jmb;
            if(Ime.Text=="")
            {
                Greska.Text = "Unesite ime";
                return;
            }
            if (Prezime.Text == "")
            {
                Greska.Text = "Unesite prezime";
                return;
            }
            if (Jmbg.Text == "" || !Int64.TryParse(Jmbg.Text, out jmb))
            {
                Greska.Text = "Pogresan jmbg";
                return;
            }
            if(apass.Text!="adminpass")
            {
                Greska.Text = "Pogresan administratorski password";
                return;
            }
            try
            {
                Izbori.DodajClana(new ClanKomisije(Ime.Text,Prezime.Text,jmb,"password",(up.IsChecked==true ? ClanKomisije.Ovlastenja.Upravljanje : ClanKomisije.Ovlastenja.Nadgledanje)));
                Greska.Text = "";
                Ime.Text = "";
                Prezime.Text = "";
                Jmbg.Text = "";
                apass.Text = "";
            }
            catch(Exception eks)
            {
                Greska.Text = eks.Message;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Int64 jmb;
            if(bLKarta.Text=="" || !Int64.TryParse(Jmbg.Text, out jmb))
            {
                bGreska.Text = "Pogresan jmbg";
                return;
            }
            if (apass_br.Text != "adminpass")
            {
                bGreska.Text = "Pogresan administratorski password";
                return;
            }
            try
            {
                Izbori.ObrisiClana(jmb);
                bLKarta.Text = "";
                apass_br.Text = "";
                bGreska.Text = "";
            }
            catch(Exception eks)
            {
                bGreska.Text = eks.Message;
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            korisnik.Password = passnovi.Text;
            passnovi.Text = "";
        }
    }
}
