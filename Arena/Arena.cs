using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Arena
    {
        List<Bojovnik> seznamBojovniku;
        Dictionary<Bojovnik, Bojovnik> seznamSouperu = new Dictionary<Bojovnik, Bojovnik>();
        List<Bojovnik> pomocnySeznamBojovniku;        
        
        public Arena()
        {
            seznamBojovniku = new List<Bojovnik> 
            { 
                new Bojovnik("Vojtech", 70, 40, 100, Zbrane.Palcat),
                new Bojovnik("Borivoj", 100, 50, 100, Zbrane.Mec),
                new Bojovnik("Jiri", 80, 30, 100, Zbrane.Palcat),
                new Bojovnik("Jan", 90, 20, 90, Zbrane.Mec),
                new Bojovnik("Řehoř", 60, 20, 100, Zbrane.Mec),
            };

            pomocnySeznamBojovniku = seznamBojovniku;

            VypisStavBojovniku();
            
            Boj();
            
           
        }
        public void VypisStavBojovniku ()
        {
            foreach(Bojovnik bojovnik in seznamBojovniku)
            {
                Console.WriteLine($"Rytir {bojovnik.Jmeno}: sila: {bojovnik.Sila}, brneni: {bojovnik.Brneni}, zivot: {bojovnik.Zivot}, zbran: {bojovnik.Zbran}");
            }
        }

        public void Boj()
        {
            string vitez = "";
            while (pomocnySeznamBojovniku.Count > 1) 
            {
                VyberSoupere();
                
                foreach (var item in seznamSouperu)
                {
                    while (item.Key.Zivot > 0 && item.Value.Zivot > 0)
                    {
                        item.Key.UtocNa(item.Value);
                        item.Value.UtocNa(item.Key);

                        Console.WriteLine($"Vysledek kola: {item.Key.Jmeno} (sila: {item.Key.Sila}, brneni: {item.Key.Brneni}, zivot: {item.Key.Zivot}) - {item.Value.Jmeno} (sila: {item.Value.Sila}, brneni: {item.Value.Brneni}, zivot: {item.Value.Zivot})");
                    }
                    if (item.Key.Zivot == 0)
                    {
                        Console.WriteLine($"{item.Key.Jmeno} je mrtvy. {item.Value.Jmeno} se uzdravuje a vyzbrojuje.");
                        item.Value.UzdraveniAVyzbrojeni();
                        pomocnySeznamBojovniku.Add(item.Value);
                    }
                    if (item.Value.Zivot == 0)
                    {
                        Console.WriteLine($"{item.Value.Jmeno} je mrtvy. {item.Key.Jmeno} se uzdravuje a vyzbrojuje.");
                        item.Key.UzdraveniAVyzbrojeni();
                        pomocnySeznamBojovniku.Add(item.Key);
                    }
                }

                seznamSouperu.Clear();
                Console.WriteLine("V arene zbyvaji:");
                foreach (var item in pomocnySeznamBojovniku)
                {
                    Console.WriteLine($"{item.Jmeno}, brneni: {item.Brneni}, zivot: {item.Zivot}");
                    vitez = item.Jmeno;
                }
            }
            Console.WriteLine($"Vitezem je {vitez}!");
        }

        public void VyberSoupere()
        {
            Bojovnik souper1;
            Bojovnik souper2;
            int nahodneCisloBojovnika = 0;            

            Random nahodneCislo = new Random();
            
            while (pomocnySeznamBojovniku.Count > 1)
            {
                nahodneCisloBojovnika = nahodneCislo.Next(0, pomocnySeznamBojovniku.Count);
                souper1 = pomocnySeznamBojovniku[nahodneCisloBojovnika];
                pomocnySeznamBojovniku.RemoveAt(nahodneCisloBojovnika);
                nahodneCisloBojovnika = nahodneCislo.Next(0, pomocnySeznamBojovniku.Count);
                souper2 = pomocnySeznamBojovniku[nahodneCisloBojovnika];
                pomocnySeznamBojovniku.RemoveAt(nahodneCisloBojovnika);

                seznamSouperu.Add(souper1, souper2);
            }

            Console.WriteLine("Bojovat spolu budou:");
            foreach(var item in seznamSouperu)
            {
                Console.WriteLine($"{item.Key.Jmeno} (sila: {item.Key.Sila}, brneni: {item.Key.Brneni}, zivot: {item.Key.Zivot}) - {item.Value.Jmeno} (sila: {item.Value.Sila}, brneni: {item.Value.Brneni}, zivot: {item.Value.Zivot})");
            }            
        }            
    }
}
