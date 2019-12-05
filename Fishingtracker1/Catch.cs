using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Fishingtracker1
{
   
    class Catch
    {
        private string _fish;
        private int _weight;
        private int _lenght;
       private static int _fishCount;
        

        private List<int> kgsumma = new List<int>();
        public Catch(string fish, int weight, int lenght, DateTime fishtime)
        {

            _fish = fish;
            _lenght = lenght;
            _weight = weight;
            kgsumma.Add(weight);
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
            return kgsumma.Sum();
        }

    }
}
