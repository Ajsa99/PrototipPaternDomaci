using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrototipPaternDomaci.Program;

namespace PrototipPaternDomaci
{
    class Program
    {
        static void Main(string[] args)
        {

            // Kreiranje korisnika
            Korisnik korisnik = new Korisnik
            {
                Ime = "Ajsa",
                Prezime = "Alibasic",
                JMBG = "111111111111",
                BrojTelefona = "063111333"
            };

            //Kloniranje korisnika
            Korisnik korisnik1 = korisnik.Clone() as Korisnik;

            // Kreiranje sluzbenika
            Sluzbenik sluzbenik = new Sluzbenik
            {
                Ime = "Sejla",
                Prezime = "Dolicanin",
                BrojRadneKnjizice = "12345",
                BrojTelefona = "064222555"
            };

            // Zakazivanje termina
            ZakaziTermin zakazi = new ZakaziTermin(korisnik, new DateTime(2023, 7, 15), sluzbenik);

            // Prikazivanje informacija o korisniku
            Console.WriteLine("Podaci o korisniku:");
            Console.WriteLine("Ime: " + korisnik.Ime);
            Console.WriteLine("Prezime: " + korisnik.Prezime);
            Console.WriteLine("JMBG: " + korisnik.JMBG);
            Console.WriteLine("Broj telefona: " + korisnik.BrojTelefona);

            Console.WriteLine();

            // Prikazivanje informacija o kloniranom korisniku
            Console.WriteLine("Podaci o kloniranom korisniku:");
            Console.WriteLine("Ime: " + korisnik1.Ime);
            Console.WriteLine("Prezime: " + korisnik1.Prezime);
            Console.WriteLine("JMBG: " + korisnik1.JMBG);
            Console.WriteLine("Broj telefona: " + korisnik1.BrojTelefona);

            Console.WriteLine();

            Console.WriteLine("Podaci o sluzbeniku:");
            Console.WriteLine("Ime: " + sluzbenik.Ime);
            Console.WriteLine("Prezime: " + sluzbenik.Prezime);
            Console.WriteLine("JMBG: " + sluzbenik.BrojRadneKnjizice);
            Console.WriteLine("Broj telefona: " + sluzbenik.BrojTelefona);

            Console.WriteLine();

            Console.WriteLine("Podaci o zakazanom terminu:");
            Console.WriteLine("Korisnik: " + zakazi.Korisnik.Ime + " " + zakazi.Korisnik.Prezime);
            Console.WriteLine("Sluzbenik: " + zakazi.Sluzbenik.Ime + " " + zakazi.Sluzbenik.Prezime);
            Console.WriteLine("Datum i vreme: " + zakazi.DatumIVreme);

            Console.WriteLine();

        }


        public abstract class ZakazivanjeTerminaPrototip
        {
            public abstract string Ime { get; set; }
            public abstract string Prezime { get; set; }
            public abstract ZakazivanjeTerminaPrototip Clone();
        }

        public class Korisnik : ZakazivanjeTerminaPrototip
        {
            public override string Ime { get; set; }
            public override string Prezime { get; set; }
            public string JMBG { get; set; }
            public string BrojTelefona { get; set; }

            public override ZakazivanjeTerminaPrototip Clone()
            {
                return MemberwiseClone() as ZakazivanjeTerminaPrototip;
            }
        }

        public class Sluzbenik : ZakazivanjeTerminaPrototip
        {
            public override string Ime { get; set; }
            public override string Prezime { get; set; }
            public string BrojRadneKnjizice { get; set; }
            public string BrojTelefona { get; set; }

            public override ZakazivanjeTerminaPrototip Clone()
            {
                return MemberwiseClone() as ZakazivanjeTerminaPrototip;
            }
        }

        public class ZakaziTermin
        {
            public ZakazivanjeTerminaPrototip Korisnik { get; set; }
            public ZakazivanjeTerminaPrototip Sluzbenik { get; set; }

            public DateTime DatumIVreme { get; set; }

            public ZakaziTermin(ZakazivanjeTerminaPrototip korisnik, DateTime datumIVreme, ZakazivanjeTerminaPrototip sluzbenik)
            {
                Korisnik = korisnik.Clone();
                Sluzbenik = sluzbenik.Clone();
                DatumIVreme = datumIVreme;
            }
        }

    }
}