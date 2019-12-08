using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace Fishingtracker1
{
    class Program
    {
        private static int weight = 0;
        private static int lenght = 0;

        static async System.Threading.Tasks.Task Main(string[] args)
        {

            // Luodaan tietokantayhteys
            // tietokannan SQL scripti löytyy Githubin repositoriosta
            SQL.SqlConnection(); 
            {
                // Listat tietojen tallentamista varten  
                List<Fishingsession> kalastussuoritus = new List<Fishingsession>();
                List<Fishingtrip> kalastusmatka = new List<Fishingtrip>();
                List<Catch> Catch = new List<Catch>();

                // Tulostetaan valikko
                Mainoperations.TulostaValikko();

                // Jatketaan ohjelmaa
                bool jatkaohjelmaa = true;
                while (jatkaohjelmaa)
                {
                    // Kysytään käyttäjältä suoritettava toiminto
                    string komento = Console.ReadLine();
                    switch (komento)
                    {
                        case "m": // aloitetaan kalastusmatka ja lisätään kalastusmatkan tiedot
                            Console.Clear();
                            Console.WriteLine("Anna kalastusmatkan tiedot");
                            Console.WriteLine("-----------------------------------------------");
                            Console.Write("Paikka: ");
                            string place = Console.ReadLine();
                            Console.Write("Kalastajan nimi: ");
                            String fisherName = Console.ReadLine();

                            bool competition = false;
                            bool valinta = true;
                            do // Ohjelma kysyy käyttäjältä onko kalastusmatka kisa? Ohjelma tarkistaa syötetyn arvon, että se on oikein.
                            {
                                Console.Write("Onko kalastusmatka kisa? K/E: ");
                                String vastaus = Console.ReadLine();

                                if (vastaus == "K") // Lisätään listaan ja tallennetaan myös kisannimi
                                {
                                    Console.Write("Anna kalastuskisan nimi:");
                                    String competitionName = Console.ReadLine();
                                    valinta = false;
                                    competition = true;

                                    // Lisätään kalastusmatkan tiedot listaan
                                    kalastusmatka.Add(new Fishingtrip(place, fisherName, competition));
                                    kalastusmatka[0].SetCompetitionName(competitionName);

                                }
                                else if (vastaus == "E") // Lisätään listaan, mutta ei tallenneta kisan nimeä
                                {
                                    Console.WriteLine("Kalastusmatka ei ole kilpailu");
                                    competition = false;
                                    valinta = false;
                                    kalastusmatka.Add(new Fishingtrip(place, fisherName, competition));
                                }
                                else
                                {
                                    Console.WriteLine("Väärä arvo");
                                }
                            } while (valinta);

                            // Lisätään matkanaloitusaika aikaleimalla
                            DateTime startTime = DateTime.Now;
                            string format1 = "d.M.yyyy HH:mm";
                            kalastusmatka[0].SetTripStartTime(startTime);

                            Console.Clear();

                            // Tulostetaan kalastusmatkan tiedot
                            Console.WriteLine($"Paikka: {kalastusmatka[0].GetPlace()}");
                            Console.WriteLine($"Kalastaja: {kalastusmatka[0].GetFisherName()}");
                            if (competition) // Jos kalastusmatka on kisa, tulostetaan kisan nimi
                            {
                                Console.WriteLine($"Kalastuskisan nimi: {kalastusmatka[0].GetCompetitionName()}");
                            }
                            Console.WriteLine($"Päivämäärä ja aika: { startTime.ToString(format1) }");
                            Console.WriteLine("-----------------------------------------------\n");

                            Console.WriteLine("Uusi kalastusmatka aloitettu\n");
                            Console.WriteLine("Seuraavaksi voit aloittaa kalastussuorituksen");

                            // Tulostetaan valikko kalastussuoritukselle
                            Mainoperations.TulostaSuoritusValikko();
                            break;


                        case "s": // aloiteaan kalastussuoritus, kysytään käyttäjältä vieheen tiedot, kalastustapa ja merkitään suorituksen aloitusaika
                            Console.Clear();

                            Console.Write("Anna vieheen nimi: ");
                            String lureName = Console.ReadLine();
                            Console.Write("Anna vieheen tyyppi: ");
                            String lureType = Console.ReadLine();
                            Console.Write("Anna kalastustapa: ");
                            String fishingStyle = Console.ReadLine();
                            Console.Write(" \n");
                            DateTime sessionStartTime = DateTime.Now;
                            string format2 = "d.M.yyyy HH:mm";

                            Console.Clear();

                            // Luodaan ilmentymä ja tallennetaan tiedot listaan
                            kalastussuoritus.Add(new Fishingsession(lureName, lureType, fishingStyle, sessionStartTime));

                            // Tulostetaan suorituksen tiedot
                            Console.WriteLine($"Vieheen nimi: {kalastussuoritus[0].GetLureName()}");
                            Console.WriteLine($"Vieheen tyyppi: {kalastussuoritus[0].GetLureType()}");
                            Console.WriteLine($"Kalastustapa: {kalastussuoritus[0].GetFishingStyle()}");
                            Console.WriteLine($"Päivämäärä ja aika: { sessionStartTime.ToString(format2) }\n");
                            Console.WriteLine("Kalastus suoritus aloitettu\n");

                            // Kalastus suoritukselle voidaan luoda useita saaliita ja suoritus päätetään käyttäjän niin valitessa ja asettamalla lopetusaika.
                            int kalalajinvalinta = 0;
                            string fish = "";
                            bool jatkasessiota = true;
                            while (jatkasessiota)
                            {
                                Console.WriteLine("Lisää saalis valitsemalla [1] \n");
                                Console.WriteLine("Lopeta kalastussuoritus valitsemalla [0] \n");
                                string valitse = Console.ReadLine();
                                switch (valitse)
                                {
                                    case "1": // Käyttäjältä kysytään saaliin tiedot, kalalaji, paino ja pituus 
                                        do // kysytään kalalaji
                                        {
                                            try
                                            {
                                                Console.WriteLine("Valitse kalalaji: Hauki[1], Kuha[2], Ahven[3] ");
                                                Console.Write("Anna numero: ");
                                                kalalajinvalinta = int.Parse(Console.ReadLine());
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Vain numerot hyväksytään, Anna numero 1, 2 tai 3");
                                            }

                                        } while (kalalajinvalinta != (1) && kalalajinvalinta != (2) && kalalajinvalinta != (3));
                                        if (kalalajinvalinta == 1)
                                        {
                                            fish = "Hauki";
                                            kalalajinvalinta = 1;
                                        }
                                        if (kalalajinvalinta == 2)
                                        {
                                            fish = "Kuha";
                                            kalalajinvalinta = 2;
                                        }
                                        if (kalalajinvalinta == 3)
                                        {
                                            fish = "Ahven";
                                            kalalajinvalinta = 3;
                                        }

                                        // Lisätään paino ja pituus ja varmistetaan, että arvo on numero
                                        do
                                        {
                                            Console.Write("Kalan paino numeroina (kg): ");
                                        } while (!int.TryParse(Console.ReadLine(), out weight));
                                        do
                                        {
                                            Console.Write("Kalan pituus numeroina (Cm): ");
                                        } while (!int.TryParse(Console.ReadLine(), out lenght));

                                        // Lisätään pvm ja aika
                                        NpgsqlDateTime fishtime = NpgsqlDateTime.Now;
                                        Console.Clear();
                                        // Luodaan olio
                                        Catch uusisaalis = new Catch(kalalajinvalinta, fish , weight, lenght, fishtime);

                                        // Lisätään kala listaan ja tulostetaan
                                        Catch.Add(uusisaalis);
                                        Console.WriteLine($"{fish} , {weight} Kg , {lenght} Cm , saalistusaika {fishtime}");
                                        Console.WriteLine("Lisätty suoritukselle\n");

                                        // Lisätään kala tietokantaan
                                        SQL.AddFish(uusisaalis);
                                        break;

                                    case "0": // Lopetetaan kalastussuoritus ja lisätään lopetusaika
                                        Console.Clear();
                                        kalastussuoritus[0].SetSessionEndTime(DateTime.Now);
                                        Console.WriteLine($"Kalastus suoritus lopetettiin aikaan {kalastussuoritus[0].GetSessionEndTime()} ");
                                        // Tulostetaan valikko
                                        Mainoperations.TulostaMatkaKeskenValikko();
                                        jatkasessiota = false;
                                        break;
                                    default:
                                        Console.WriteLine("Valitsit väärin");
                                        break;
                                }
                            }

                            break;
                        case "a": // Analysoidaan kalastusta ja tulostetaan historia tietoja
                                  // Lasketaan tietyllä vieheellä saadut kalat.
                            bool jatkaanalyysia = true;
                            while (jatkaanalyysia)
                            {
                                Console.WriteLine("Näytä kalastusmatkan kalat ja yhteispaino [1] \n");
                                Console.WriteLine("Näytä kaikki saadut kalat [2] \n");
                                Console.WriteLine("Näytä kalastusmatkan kesto [3] \n");
                                Console.WriteLine("Näytä valikko [4] \n");
                                string valitse = Console.ReadLine();
                                switch (valitse)
                                {
                                    case "1": //Tulostaa kalastusmatkalla saadut kalat ja näytetään kalojen yhteispaino.
                                        Console.Clear();
                                        foreach (Catch item in Catch)
                                        {
                                            Console.Write($"{item.GetFishSpecies()} ");
                                            Console.Write($"{item.GetFishWeight()} Kg ");
                                            Console.Write($"{item.GetFishLenght()} Cm ");
                                            Console.WriteLine($"Saalistusaika: {item.GetFishTime()} ");
                                            Console.WriteLine("");
                                        }
                                        Console.WriteLine($"Kaloja saatu tällä kalastusmatkalla: {Catch[0].GetFishCount()} ");
                                        Console.WriteLine($"Kalojen yhteispaino: {Catch[0].GetWeightSum()} kiloa");
                                        Console.WriteLine();
                                        
                                        break;
                                    case "2": // Haetaan kaikki saadut kalat tietokannasta
                                        Console.Clear();
                                        Console.WriteLine("Kaikki kalat tulostetaan tietokannasta");
                                        SQL.SelectKaikkiSaaliit();

                                        break;
                                    case "3": // Näytetään Kalastusmatkan kesto
                                        Console.Clear();
                                        TimeSpan fishingTime = (kalastusmatka[0].GetStartTime() - DateTime.Now);
                                        Console.WriteLine($"Kalastusmatkan kesto: {fishingTime.ToString("hh\\:mm\\:ss")}");
                                        break;

                                    case "4": // Poistutaan analyysiosiosta
                                        Console.Clear();
                                        Mainoperations.TulostaMatkaKeskenValikko();
                                        jatkaanalyysia = false;
                                        break;
                                    default:
                                        Console.WriteLine("Valitsit väärin");
                                        break;
                                }
                            }
                            break;
                        case "l": // Lopetetaan kalastusmatka ja tulostetaan lopetusaika.
                            Console.Clear();
                            kalastusmatka[0].SetTripEndTime(DateTime.Now);
                            Console.WriteLine($"Kalastusmatka lopetettiin aikaan: {kalastusmatka[0].GetTripEndTime()} ");
                            Mainoperations.TulostaValikko();

                            break;
                        case "q": // ohjelma lopetetaan
                            jatkaohjelmaa = false;

                            break;
                        default:
                            Console.WriteLine("Valitsit väärin");
                            break;

                    }
                }
            }
        }
    }


}

