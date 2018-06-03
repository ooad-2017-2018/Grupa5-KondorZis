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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SistemZaElektronskoGlasanje
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            if(Izbori.Glasaci.Count==0)
            {
                Izbori.DodajClana(new ClanKomisije("Kenan", "Karahodzic", 2502998170039, "password", ClanKomisije.Ovlastenja.Nadgledanje));
                Izbori.DodajClana(new ClanKomisije("Damad", "Butkovic", 1234567890123, "password", ClanKomisije.Ovlastenja.Upravljanje));
                Izbori.DodajGMjesto(new GlasackoMjesto("Staro Hrasno"));
                Izbori.DodajGLasaca(new Glasac("ime", "prezime", 1122334455667, "123456789", "Sarajevo"), new GlasackoMjesto("Staro Hrasno"));
            }
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClanKomisije korisnik = Izbori.DajClana(User.Text);
                if (korisnik.Password != Pass.Password)
                {
                    Greska.Text = "Pogrešan password";
                    Pass.Password = "";
                }
                else
                {
                    if (korisnik.Ovlasti == ClanKomisije.Ovlastenja.Nadgledanje)
                    { 
                        this.Frame.Navigate(typeof(PassGenZaGlasaca));
                    }
                    else
                        this.Frame.Navigate(typeof(AdminForma),korisnik);
                }
            }
            catch(Exception eks)
            {
                Greska.Text = eks.Message;
            }
        }
    }
}
