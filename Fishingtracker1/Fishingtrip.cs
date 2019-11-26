using System;
using System.Collections.Generic;
using System.Text;

namespace Fishingtracker1
{

    // Geneerinen lista session
    class Fishingtrip
    {
       // private List<Fishingtrip> kalastusmatka = new List<Fishingtrip>();
        


        private string _place;
        private bool _competition;
        private string _competitionName;
        private DateTime _startTime;
        private DateTime _endTime;
        private string _fisherName;


        public Fishingtrip(string place, string fisherName, bool competition, DateTime startTime)
        {
            _place = place;
            _competition = competition;
            _startTime = startTime;
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
    
     
        }
    }

