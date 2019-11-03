using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Fishingtracker1
{
    class Catch
    {
        private string _fish;
        private int _weight;
        private int _lenght;
        static int _count;

        public Catch(string fish, int weight, int lenght)
        {

            _fish = fish;
            _weight = weight;
            _lenght = lenght;
            _count++;
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
            return _count;
        }
    }
}
