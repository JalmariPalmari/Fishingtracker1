using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Fishingtracker1
{
   
    class Catch
    {
       // List<Catch> saaliit = new List<Catch>();

        private string _fish;
        private int _weight;
        private int _lenght;
        static int _fishCount;
        

     static private List<int> kgsumma = new List<int>();
    private int _kgSumma = kgsumma.Sum();
        public Catch(string fish, int weight, int lenght, DateTime fishtime) // ei toimi
        {

            _fish = fish;

            if (weight > 0 && weight < 50)
            {
                _weight = weight;
            }
            else
            {
                Console.WriteLine("Invalid weight");
            }
            kgsumma.Add(_weight);
            _lenght = lenght;
            _fishCount++;
        }
        public string GetFishSpecies()
        {
            return _fish;
        }
        public int GetFishWeight()
        {
            return _weight;
        }
        public int GetFishLenght()
        {
            return _lenght;
        }
        public int GetFishCount()
        {
            return _fishCount;
        }
        public int GetWeightSum()
        {
            return _kgSumma;
        }
       
      
     //   public void SetCatch(Catch sessionCatch)
      //    {
     //         saaliit.Add(sessionCatch);
     //    }
        
    //   public Catch GetCatch()
    //   {
     //        return saaliit[0];
     //     }

    }
}
