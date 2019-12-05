using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Fishingtracker1
{
    class Fishingtrip
    {
        private string _place;
        private bool _competition;
        private string _competitionName;
        private DateTime _startTime;
        private DateTime _endTime;
        private string _fisherName;


        public Fishingtrip(string place, string fisherName, bool competition)
        {
            _place = place;
            _competition = competition;
            _fisherName = fisherName;


        }
        public string GetPlace()
        {
            return _place;
        }
        public bool GetCompetition()
        {
            return _competition;
        }

        public DateTime GetStartTime()
        {
            return _startTime;
        }
        public DateTime GetTripEndTime()
        {
            return _endTime;
        }
        public string GetFisherName()
        {
            return _fisherName;
        }
        public string GetCompetitionName()
        {
            return _competitionName;
        }
        public void SetCompetitionName(string competitionName)
        {
            _competitionName = competitionName;
        }
        public void SetTripEndTime(DateTime endTime)
        {
            _endTime = endTime;
        }
        public void SetTripStartTime(DateTime startTime)
        {
            _startTime = startTime;
        }


    }
    }

