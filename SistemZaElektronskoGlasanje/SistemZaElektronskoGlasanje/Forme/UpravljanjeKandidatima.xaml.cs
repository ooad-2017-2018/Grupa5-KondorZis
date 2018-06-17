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
            foreach (PSubjekat ps in Izbori.Subjekti)
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
                    Kandidat.Nacionalnost kn=new Kandidat.Nacionalnost();
                    switch(Nacionalnost.SelectedIndex)
                    {
                        case 0:
                            kn = Kandidat.Nacionalnost.Bosnjak;
                            break;
                        case 1:
                            kn = Kandidat.Nacionalnost.Hrvat;
                            break;
                        case 2:
                            kn = Kandidat.Nacionalnost.Srbin;
                            break;
                        case 3:
                            kn = Kandidat.Nacionalnost.Ostali;
                            break;
                    }

                    Izbori.DodajKandidata(Ime.Text,Prezime.Text,MStanovanja.Text,jmb,kn);
                    Kandidat k = Izbori.DajKandidata(jmb);
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
                    Greska.Text = "";
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
                    Kandidat brisanje = Izbori.DajKandidata(jmb);
                    Izbori.IzbaciClana(brisanje);
                    Izbori.IzbrisiKandidata(jmb);
                }
                catch(Exception eks)
                {
                    bGreska.Text = eks.Message;
                }
            }
        }
    }
}
