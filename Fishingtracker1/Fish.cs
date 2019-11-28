using System;
using System.Collections.Generic;
using System.Text;

namespace Fishingtracker1
{
    class Fish
    {
        String _species;

        public Fish(string Species)
        {
            _species = Species;
        }
        public String GetSpecies()
        {
            return _species;
        }
    }
}
