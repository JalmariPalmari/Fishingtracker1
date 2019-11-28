using System;
using System.Collections.Generic;
using System.Text;

namespace Fishingtracker1
{
    class Analyse
    {
        public static void TripFishingTime()
        {
            TimeSpan fishingTime = (Fishingtrip.GetStartTime() - DateTime.Now);
            fishingTime.ToString("dd.MM.yyyy hh:mm");

        }
    }
}
