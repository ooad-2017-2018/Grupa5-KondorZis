﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemZaElektronskoGlasanjeASP.Models
{
    public class Utrka
    {
        string naziv;
        List<GlasackoMjesto> mjestaZaUtrku;
        List<Kandidat> kandidati;
        List<PSubjekat> subjekti;

        public Utrka(string naziv)
        {
            Naziv = naziv;
            MjestaZaUtrku = new List<GlasackoMjesto>();
            Kandidati = new List<Kandidat>();
            Subjekti = new List<PSubjekat>();
        }
        [Key]
        public string Naziv { get => naziv; set => naziv = value; }
        public List<GlasackoMjesto> MjestaZaUtrku { get => mjestaZaUtrku; set => mjestaZaUtrku = value; }
        public List<Kandidat> Kandidati { get => kandidati; set => kandidati = value; }
        public List<PSubjekat> Subjekti { get => subjekti; set => subjekti = value; }
    }
}
