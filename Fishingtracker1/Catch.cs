using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Fishingtracker1
{
   
    class Catch
    {
        List<Catch> saaliit = new List<Catch>();

        private string _fish;
        private int _weight;
        private int _lenght;
        static int _fishCount;

        public Catch(string fish, int weight, int lenght, DateTime fishtime) // ei toimi
        {

            _fish = fish;

            if (_weight < 0 && _weight > 50)
            {
                _weight = weight;
            }
            else
            {
                Console.WriteLine("Invalid weight");
            }
            
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
        public void SetFishWeight(int setFishWeight)
        {
            if (_weight < 0 || _weight > 50)
            {
                _weight = setFishWeight;
            }
            else
            {
                Console.WriteLine("Invalid weight");
            }
        }
        public void SetCatch(Catch sessionCatch)
          {
              saaliit.Add(sessionCatch);
         }
        
       public Catch GetCatch()
       {
             return saaliit[0];
          }

    }
}
