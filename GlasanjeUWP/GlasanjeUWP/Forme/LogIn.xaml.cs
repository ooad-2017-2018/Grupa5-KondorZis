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
                GlasackoMjesto gmpom=new GlasackoMjesto("Staro Hrasno");
                Izbori.DodajGMjesto(gmpom);
                Izbori.DodajGLasaca(new Glasac("ime", "prezime", 1122334455667, "123456789", "Sarajevo"), gmpom);
                Utrka pom = new Utrka("OS President",Utrka.Tip.Jedan);
                pom.Kandidati.Add(new Kandidat("Linus","Torvalds","Silicon Walley",1472583691475,Kandidat.Nacionalnost.Ostali));
                pom.Kandidati.Add(new Kandidat("William Henry", "Gates III", "Silicon Walley", 1472583691476, Kandidat.Nacionalnost.Ostali));
                pom.MjestaZaUtrku.Add(gmpom);
                //Izbori.Utrke.Add(pom);

                pom = new Utrka("OS Parlament",Utrka.Tip.Vise);
                pom.Kandidati.Add(new Kandidat("Richard", "Stallman", "Silicon Walley", 1472583691475, Kandidat.Nacionalnost.Ostali));
                pom.Kandidati.Add(new Kandidat("Steve", "Wozniack", "Silicon Walley", 1472583691476, Kandidat.Nacionalnost.Ostali));
                pom.MjestaZaUtrku.Add(gmpom);
                Izbori.Utrke.Add(pom);

            }
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Glasac g = Izbori.DajGlasaca(User.Text);
                if (g.genPass() != Pass.Password)
                {
                    Greska.Text = "Pogrešan password";
                    Pass.Password = "";
                }
                else
                {
                    List<Utrka> utrke =Izbori.dajUtrkeGlasaca(g);
                    Parametri p = new Parametri();
                    p.utrke = utrke;
                    p.gl = new GlasackiListic();
                    if (utrke.Count == 0)
                        this.Frame.Navigate(typeof(PredajaListica),p);
                    if (utrke[0].t==Utrka.Tip.Jedan)
                        this.Frame.Navigate(typeof(GlasanjeJedanKandidat),p);
                    else
                        this.Frame.Navigate(typeof(GlasanjeViseKandidata),p);

                }
            }
            catch(Exception eks)
            {
                Greska.Text = eks.Message;
            }
        }
    }
}
