using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using NpgsqlTypes;

namespace Fishingtracker1
{
   
    class Catch
    {
        private int _kalalajinvalinta;
        private int _weight;
        private int _lenght;
        private string _fish;
        private NpgsqlDateTime _fishtime;
       private static int _fishCount;

        // lista kilogrammojen tallentamista varten.
        private List<int> kgsumma = new List<int>();
        public Catch(int kalalajinvalinta, string fish, int weight, int lenght, NpgsqlDateTime fishtime)
        {

            _kalalajinvalinta = kalalajinvalinta;
            _fish = fish;
            _lenght = lenght;
            _weight = weight;
            _fishtime = fishtime;
            kgsumma.Add(weight);
            _fishCount++;
        }
        public int GetFishNumber()
        {
            return _kalalajinvalinta;           
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
        public NpgsqlDateTime GetFishTime()
        {
            return _fishtime;
        }
        public int GetWeightSum()
        {
            return kgsumma.Sum();
        }

    }
}
