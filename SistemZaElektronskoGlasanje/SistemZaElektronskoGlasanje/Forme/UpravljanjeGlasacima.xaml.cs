﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
    public sealed partial class UpravljanjeGlasacima : Page
    {
        public UpravljanjeGlasacima()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            foreach (GlasackoMjesto gm in Izbori.GMjesta)
                Mjesto.Items.Add(gm);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Int64 jmb;
            if(Ime.Text =="")
            {
                Greska.Text = "UNESITE IME";
            }
            else if(Prezime.Text=="")
            {
                Greska.Text = "UNESTIE PREZIME";
            }
            else if(Jmbg.Text=="")
            {
                Greska.Text = "UNESTIE JMBG";
            }
            else if (MStanovnja.Text == "")
            {
                Greska.Text = "UNESTIE MJESTO STANOVANJA";
            }
            else if (LKarta.Text == "")
            {
                Greska.Text = "UNESTIE BROJ LIČNE KARTE";
            }
            else if(LKarta.Text.Length!=9)
            {
                Greska.Text = "POGREŠAN BROJ LIČNE KARTE";
            }
            else if (!Int64.TryParse(Jmbg.Text, out jmb))
            {
                Greska.Text = "POGREŠAN JMBG";
            }
            else if (jmb < 1000000000000 || jmb > 9999999999999)
            {
                Greska.Text = "POGREŠAN JMBG";
            }
            else if(Mjesto.SelectedItem==null)
            {
                Greska.Text = "ODABERITE GLASAČKO MJESTO";
            }
            else
            {
                try
                {
                    Glasac novi = new Glasac(Ime.Text,Prezime.Text,jmb,LKarta.Text,MStanovnja.Text);
                    Izbori.DodajGLasaca(novi,Mjesto.SelectedItem as GlasackoMjesto);
                    Ime.Text = "";
                    Prezime.Text = "";
                    LKarta.Text = "";
                    Jmbg.Text = "";
                    MStanovnja.Text = "";
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
            Greska.Text = "";
            try
            {
                if (bLKarta.Text == "")
                {
                    bGreska.Text = "Unesite broj lične karte za brisanje";
                    return;
                }
                if (bLKarta.Text.Count() != 9)
                {
                    bGreska.Text = "Neispravan broj lične karte";
                    return;
                }
                Glasac g = Izbori.DajGlasaca(bLKarta.Text);
                Izbori.ObrisiGlasaca(g);
                bLKarta.Text = "";
                bGreska.Text = "Glasac uspjesno obrisan";
            }
            catch (Exception eks)
            {
                bGreska.Text = eks.Message;
            }
        }
    }
    
}
