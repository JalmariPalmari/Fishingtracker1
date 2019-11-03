using System;
using System.Collections.Generic;
using System.Text;

namespace Fishingtracker1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Valikon toiminnallisuuksien luominen applikaatiolle
            {
                // Listat tietojen tallentamista varten
                List<Fishingtrip> kalastusmatka = new List<Fishingtrip>();
                List<Fishingsession> kalastussuoritus = new List<Fishingsession>();
                List<Catch> saaliit = new List<Catch>();


                Mainoperations.TulostaValikko();
                bool jatkaohjelmaa = true;

                while (jatkaohjelmaa)
                {
                    Console.WriteLine("Valitse toiminto");
                    string komento = Console.ReadLine();

                    switch (komento)
                    {
                        case "m": // aloitetaan kalastus ja lisätään kalastusmatkan tiedot
                            Console.WriteLine("Anna kalastusmatkan tiedot \n");
                           Console.Write("Paikka: ");
                            String place = Console.ReadLine();
                            Console.Write("Kalastajan nimi: ");
                            String fisherName = Console.ReadLine();

                            bool competition = false;
                            bool valinta = true;
                            do
                            {
                                // Ohjelma kysyy käyttäjältä onko kalastusmatka kisa. Ohjelma tarkistaa syötetyn arvon, että se on oikein.
                                Console.Write("Onko kalastusmatka kisa? Kyllä/Ei: ");
                                String vastaus = Console.ReadLine();
                                if (vastaus == "Kyllä")
                                {
                                    
                                    Console.WriteLine("Kalastusmatka on kisa!");
                                    competition = true;
                                    valinta = false;

                                }
                       
                                if (vastaus == "Ei")
                                {
                                    
                                    Console.WriteLine("Kalastusmatka ei ole kilpailu");
                                    competition = false;
                                    valinta = false;
                                }
                                else
                                {
                                    Console.WriteLine("Väärä arvo");
                                }

                            } while (valinta);

                          
                            if (competition == true)
                            {
                                Console.Write("Anna kalastuskisan nimi:");
                                String competitionName = Console.ReadLine();
                                
                            }

                            DateTime startTime = DateTime.Now;
                            string format1 = "d.M.yyyy HH:mm";
                            Console.WriteLine($"Päivämäärä ja aika: { startTime.ToString(format1) }\n");



                            // Lisätään kalastusmatkan tiedot listaan ja tulostetaan

                            kalastusmatka.Add(new Fishingtrip(place, fisherName, competition, startTime));


                            Console.WriteLine("Uusi kalastusmatka aloitettu!\n");

                     
                           Console.WriteLine("Seuraavaksi voit aloittaa kalastussuorituksen\n");

                            Mainoperations.TulostaSuoritusValikko();


                            break;


                        case "s": // aloiteaan kalastussuoritus ja kysytään käyttäjältä vieheen tiedot ja aloitusaika

                            Console.Write("Anna vieheen nimi: ");
                            String lureName = Console.ReadLine();
                            Console.Write("Anna vieheen tyyppi: ");
                            String lureType = Console.ReadLine();
                            Console.Write("Anna kalastustapa: ");
                            String fishingStyle = Console.ReadLine();
                            Console.Write(" \n");
                            DateTime sessionStartTime = DateTime.Now;
                            string format2 = "d.M.yyyy HH:mm";
                            Console.WriteLine($"Päivämäärä ja aika: { sessionStartTime.ToString(format2) }\n");


                            // Luodaan ilmentymä ja tallennetaan tiedot listaan
                            kalastussuoritus.Add(new Fishingsession(lureName, lureType, fishingStyle, sessionStartTime));

                            Console.WriteLine("Kalastus suoritus aloitettu\n");

                            // Kalastus suoritukselle voidaan luoda useita saaliita ja suoritus päätetään käyttäjän niin valitessa ja syöttämällä lopetusaika.

                            bool jatkasessiota = true;
                            while (jatkasessiota)
                            {
                                Console.WriteLine("Lisää saalis valitsemalla [1] \n");
                                Console.WriteLine("Lopeta kalastussuoritus valitsemalla [0] \n");
                                string valitse = Console.ReadLine();
                                switch (valitse)
                                {
                                    case "1":



                                        Console.WriteLine("Anna saalin tiedot\n");
                                        Console.Write("Kalalaji: ");
                                        string fish = Console.ReadLine();
                                        Console.Write("Kalan paino (kg): ");
                                        int weight = int.Parse(Console.ReadLine());
                                        Console.Write("Kalan pituus (cm): ");
                                        int lenght = int.Parse(Console.ReadLine());

                                        saaliit.Add(new Catch(fish, weight, lenght));
                                        Console.WriteLine($"Saalis {fish}, {weight}, {lenght} lisätty suoritukselle\n");
                                    break;
                                    case "0":

                                        kalastussuoritus[0].SetSessionEndTime(DateTime.Now);
                                        Console.WriteLine($"Kalastus suoritus lopetettiin kello {kalastussuoritus[0].GetSessionEndTime()} ");

                                        foreach (Catch item in saaliit)
                                        {
                                            Console.Write($"{item.GetFishSpecies()} ");
                                            Console.Write($"{item.GetFishWeight()} Kg ");
                                            Console.Write($"{item.GetFishLenght()} Cm ");
                                            Console.WriteLine("");
                                        }
                                        Mainoperations.TulostaMatkaKeskenValikko();
                                        jatkasessiota = false;
                                        break;
                                }
                            }
                            
     
                            break;
                        case "a":

                            break;

                        case "1":
                            kalastusmatka[0].SetTripEndTime(DateTime.Now);
                            Console.WriteLine($"Kalastusmatka lopetettiin aikaan: {kalastusmatka[0].GetTripEndTime()} ");

                            break;

                        case "q":
                            jatkaohjelmaa = false;

                            break;

                    }
                }
            }
        }
    }
}
