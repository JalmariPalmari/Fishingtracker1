using System;
using System.Collections.Generic;
using System.Text;

namespace Fishingtracker1
{
    class Fishingtrip
    {
        private string _place;
        private bool _competition;
        private string _competitionName;
        private DateTime _date;
        private DateTime _startTime;
        private DateTime _endTime;
        private string _crewName;

        public Fishingtrip(string place, bool competition, string competitionName, DateTime date, DateTime startTime, string crewName)
        {
            _place = place;
            _competition = competition;
            _competitionName = competitionName;
            _date = date;
            _startTime = startTime;
            _crewName = crewName;

        }
    }
}