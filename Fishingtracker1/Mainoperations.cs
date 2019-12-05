using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Fishingtracker1
{
    class Mainoperations
    {
        public static void TulostaValikko() // Metodilla tulostetaan ohjelman aloitusvalikko
        {
            {
                Console.WriteLine("\n\n-- Valitse toiminto --\n\n");
                Console.WriteLine("[m] Aloita kalastusmatka \n");
               // Console.WriteLine("[s] Aloita kalastussuoritus\n");
              //  Console.WriteLine("[a] Analysoi kalastusta\n");
             //   Console.WriteLine("[l] Lopeta kalastusmatka\n");
                Console.WriteLine("[q] Sulje\n\n");
            }

        }

            public static void TulostaSuoritusValikko() // tulostetaan suorituksen valikko
        {
            {
                Console.WriteLine("\n\n-- Valitse toiminto --\n\n");
                Console.WriteLine("[s] Aloita kalastussuoritus\n");
             //   Console.WriteLine("[a] Analysoi kalastusta\n");
                Console.WriteLine("[q] Sulje\n\n");

            }
        }
        public static void TulostaMatkaKeskenValikko() // tulostetaan keskeneräisen matkan valikko
        {
            {
                Console.WriteLine("\n\n-- Valitse toiminto --\n\n");
                Console.WriteLine("[s] Aloita kalastussuoritus\n");
                Console.WriteLine("[a] Analysoi kalastusta\n");
                Console.WriteLine("[l] Lopeta kalastusmatka\n");
                Console.WriteLine("[q] Sulje\n\n");
            }
        }
    }
}
