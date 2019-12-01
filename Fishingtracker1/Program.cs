using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Linq;

namespace Fishingtracker1
{
    class Program
    {

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //// Luodaan tietokantayhteys
            //string connection = "Host=localhost;Username=postgres;Password=;Database=fishing_tracker";

            //var conn = new NpgsqlConnection(connection);
            //conn.Open();

            //// Insert some data
            //using (var cmd = new NpgsqlCommand("INSERT INTO fish(species) VALUES ('Särki')", conn))

            //{

            //    await cmd.ExecuteNonQueryAsync();
            //}

            //// Retrieve all rows
            //using (var cmd = new NpgsqlCommand("SELECT id_fish, species FROM fish", conn))
            //using (var reader = await cmd.ExecuteReaderAsync())
            //    while (await reader.ReadAsync())
            //        Console.WriteLine(reader.GetString(1));

            //jdhfkj



            // Valikon toiminnallisuuksien luominen applikaatiolle
            {
                // Listat tietojen tallentamista varten

                List<Fishingsession> kalastussuoritus = new List<Fishingsession>();
                List<Fishingtrip> kalastusmatka = new List<Fishingtrip>();
                List<Catch> saaliit = new List<Catch>();

                // Tulostetaan valikko
                Mainoperations.TulostaValikko();
                bool jatkaohjelmaa = true;

                while (jatkaohjelmaa)
                {
                    Console.WriteLine("Valitse toiminto");
                    string komento = Console.ReadLine();   

                    switch (komento)
                    {
                        case "m": // aloitetaan kalastus ja lisätään kalastusmatkan tiedot
                            Console.WriteLine("Anna kalastusmatkan tiedot");
                            Console.WriteLine("-----------------------------------------------");
                            Console.Write("Paikka: ");
                            String place = Console.ReadLine();
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
                                Console.WriteLine($"Kalastuskisan nimi{kalastusmatka[0].GetCompetitionName()}");
                            }
                            Console.WriteLine($"Päivämäärä ja aika: { startTime.ToString(format1) }");
                            Console.WriteLine("-----------------------------------------------\n");
                            Console.WriteLine("Uusi kalastusmatka aloitettu!\n");
                            Console.WriteLine("Seuraavaksi voit aloittaa kalastussuorituksen");

                            // Tulostetaan valikko kalastussuoritukselle
                            Mainoperations.TulostaSuoritusValikko();
                            break;


                        case "s": // aloiteaan kalastussuoritus, kysytään käyttäjältä vieheen tiedot, kalastustapa ja merkitään suorituksen aloitusaika


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
                            // Tallannetaan tiedot tietokantaan, kun tarvittavat tekniikat on opittu

                            Console.WriteLine("Kalastus suoritus aloitettu\n");

                            // Kalastus suoritukselle voidaan luoda useita saaliita ja suoritus päätetään käyttäjän niin valitessa ja asettamalla lopetusaika.

                            bool jatkasessiota = true;
                            while (jatkasessiota)
                            {
                                Console.WriteLine("Lisää saalis valitsemalla [1] \n");
                                Console.WriteLine("Lopeta kalastussuoritus valitsemalla [0] \n");
                                string valitse = Console.ReadLine();
                                switch (valitse)
                                {
                                    case "1": // Käyttäjältä kysytään saaliin tiedot, kalalaji, paino ja pituus
                                        Console.WriteLine("Anna saalin tiedot\n");
                                        Console.Write("Kalalaji: ");
                                        string fish = Console.ReadLine();
                                        Console.Write("Kalan paino (kg): ");
                                        int weight = int.Parse(Console.ReadLine());
                                        Console.Write("Kalan pituus (cm): ");
                                        int lenght = int.Parse(Console.ReadLine());
                                        DateTime fishtime = DateTime.Now;
                                        //  fishtime.ToString("dd.MM.yyyy hh:mm");

                                        //using (var kalalaji = new NpgsqlCommand("INSERT INTO fish(species) VALUES ('" + fish + "') ", conn))
                                        //using (var painojapituus = new NpgsqlCommand(" INSERT INTO catch (fish_weight , fish_lenght ) VALUES('" + weight + "', '" + lenght + "')", conn))
                                        //{
                                        //    await kalalaji.ExecuteNonQueryAsync();
                                        //    await painojapituus.ExecuteNonQueryAsync();
                                        //}
                                        saaliit.Add(new Catch(fish, weight, lenght, fishtime));

                                        Console.WriteLine($"Saalis {fish} , {weight} Kg , {lenght} Cm lisätty suoritukselle\n");
                                        break;

                                    case "0": // Lopetetaan kalastussuoritus ja lisätään lopetusaika

                                        kalastussuoritus[0].SetSessionEndTime(DateTime.Now);
                                        Console.WriteLine($"Kalastus suoritus lopetettiin kello {kalastussuoritus[0].GetSessionEndTime()} ");

                                        Mainoperations.TulostaMatkaKeskenValikko();
                                        jatkasessiota = false;
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
                                Console.WriteLine("Näytä kalastusmatkan kesto [2] \n");
                                string valitse = Console.ReadLine();
                                switch (valitse)
                                {
                                    case "1": //Tulostaa kalastusmatkalla saadut kalat ja näytetään kalojen yhteispaino.
                                        foreach (Catch item in saaliit)
                                        {
                                            Console.Write($"{item.GetFishSpecies()} ");
                                            Console.Write($"{item.GetFishWeight()} Kg ");
                                            Console.Write($"{item.GetFishLenght()} Cm ");
                                            Console.WriteLine("");


                                        }
                                        Console.WriteLine($"Kaloja saatu tällä kalastusmatkalla: {saaliit[0].GetFishCount()} ");
                                        Console.WriteLine($"Kalojen yhteispaino: {saaliit[0].GetWeightSum()} ");
                                        Console.WriteLine();


                                        break;

                                    case "2": // Kalastusmatkan kesto
                                        TimeSpan fishingTime = (kalastusmatka[0].GetStartTime() - DateTime.Now);
                                        Console.WriteLine(fishingTime.ToString()); 
                                        jatkaanalyysia = false;
                                        break;
                                }
                            }
                            break;

                        case "1":
                            kalastusmatka[0].SetTripEndTime(DateTime.Now);
                            Console.WriteLine($"Kalastusmatka lopetettiin aikaan: {kalastusmatka[0].GetTripEndTime()} ");

                            break;

                        case "q":
                            jatkaohjelmaa = false;

                            break;

                        default: Console.WriteLine("Valitsit väärin");
                                break;

                    }
                }
            }
        }
    }
}
