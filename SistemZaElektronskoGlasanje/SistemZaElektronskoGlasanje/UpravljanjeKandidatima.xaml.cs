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
    public sealed partial class UpravljanjeKandidatima : Page
    {
        Izbori izbori;
        public UpravljanjeKandidatima()
        {
            Random b = new Random();
            this.InitializeComponent();
            Nacionalnost.Items.Add("Bošnjak");
            Nacionalnost.Items.Add("Hrvat");
            Nacionalnost.Items.Add("Srbin");
            Nacionalnost.Items.Add("Ostali");
            Nacionalnost.SelectedIndex = (b.Next()%4) ;
            Subjekat.Items.Add("");
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            izbori = (Izbori)e.Parameter;
            foreach (PSubjekat ps in izbori.Subjekti)
            {
                Subjekat.Items.Add(ps);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Subjekat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Subjekat.SelectedItem is Stranka)
                Predsjednik.IsEnabled = true;
            else
                Predsjednik.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Int64 jmb;
            if (Ime.Text == "")
            {
                Greska.Text = "UNESITE IME";
            }
            else if (Prezime.Text == "")
            {
                Greska.Text = "UNESITE PREZIME";
            }
            else if (MStanovanja.Text == "")
            {
                Greska.Text = "UNESITE MJESTO STANOVANJA";
            }
            else if (Jmbg.Text == "")
            {
                Greska.Text = "UNESITE JMBG";
            }
            else if (!Int64.TryParse(Jmbg.Text,out jmb))
            {
                Greska.Text = "POGREŠAN JMBG";
            }
            else if (jmb<1000000000000 || jmb>9999999999999)
            {
                Greska.Text = "POGREŠAN JMBG";
            }
            else
            {
                try
                {
                    Greska.Text = "";
                    izbori.DodajKandidata(Ime.Text,Prezime.Text,MStanovanja.Text,jmb,(Nacionalnost.SelectedIndex==0 ? Kandidat.Nacionalnost.Bosnjak : Nacionalnost.SelectedIndex == 1 ? Kandidat.Nacionalnost.Hrvat : Nacionalnost.SelectedIndex==2 ? Kandidat.Nacionalnost.Srbin :Kandidat.Nacionalnost.Ostali));
                    Kandidat k = izbori.DajKandidata(jmb);
                    if(Subjekat.SelectedItem is Stranka)
                    {
                        (Subjekat.SelectedItem as Stranka).DodajKandidata(k);
                        if (Predsjednik.IsChecked == true) (Subjekat.SelectedItem as Stranka).Predsjednik = k;
                    }
                    else if (Subjekat.SelectedItem is NezavisnaLista)
                    {
                        (Subjekat.SelectedItem as NezavisnaLista).DodajKandidata(k);
                    }
                    Ime.Text = "";
                    Prezime.Text = "";
                    MStanovanja.Text = "";
                    Jmbg.Text = "";
                }
                catch(Exception eks)
                {
                    Greska.Text = eks.Message;
                }
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Int64 jmb;
            if (!Int64.TryParse(bIme.Text, out jmb))
            {
                bGreska.Text = "POGREŠAN JMBG";
            }
            else if (jmb < 1000000000000 || jmb > 9999999999999)
            {
                bGreska.Text = "POGREŠAN JMBG";
            }
            else
            {
                try
                {
                    Kandidat brisanje = izbori.DajKandidata(jmb);
                    izbori.IzbaciClana(brisanje);
                    izbori.IzbrisiKandidata(jmb);
                }
                catch(Exception eks)
                {
                    bGreska.Text = eks.Message;
                }
            }
        }
    }
}
