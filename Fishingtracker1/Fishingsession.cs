﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fishingtracker1
{
    class Fishingsession
    {
        private String _lureName;
        private String _lureType;
        private String _fishingStyle;


        private DateTime _sessionStartTime;
        private DateTime _sessionEndTime;

        public Fishingsession(string lureName, string lureType, string fishingStyle, DateTime sessionStartTime)
        {
            _lureName = lureName;
            _lureType = lureType;
            _fishingStyle = fishingStyle;
            _sessionStartTime = sessionStartTime;
        }
        public string GetLureName()
        {
            return _lureName;
        }
        public string GetLureType()
        {
            return _lureType;
        }
        public string GetFishingStyle()
        {
            return _fishingStyle;
        }
        public void SetSessionStartTime(DateTime sessionStartTime)
        {
            _sessionStartTime = sessionStartTime;
        }
        public DateTime GetSessionStartTime()
        {
            return _sessionStartTime;
        }
        public void SetSessionEndTime(DateTime sessionEndTime)
        {
            _sessionEndTime = sessionEndTime;
        }
        public DateTime GetSessionEndTime()
        {
            return _sessionEndTime;
        }
    }
}
