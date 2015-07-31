using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLModels
{
    public class Entrant : ModelBase
    {
        string displayname;
        [JsonProperty("displayname")]
        public string Displayname
        {
            get { return displayname; }
            set
            {
                if (displayname != value)
                {
                    displayname = value;
                    NotifyPropertyChanged("Displayname");
                }
            }
        }

        int place;
        [JsonProperty("place")]
        public int Place
        {
            get { return place; }
            set
            {
                if (place != value)
                {
                    place = value;
                    NotifyPropertyChanged("Place");
                }
            }
        }

        int time;
        [JsonProperty("time")]
        public int Time
        {
            get { return time; }
            set
            {
                if (time != value)
                {
                    time = value;
                    NotifyPropertyChanged("Time");
                }
            }
        }

        string message;
        [JsonProperty("message")]
        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    NotifyPropertyChanged("Message");
                }
            }
        }

        string stateText;
        [JsonProperty("statetext")]
        public string StateText
        {
            get { return stateText; }
            set
            {
                if (stateText != value)
                {
                    stateText = value;
                    NotifyPropertyChanged("StateText");
                }
            }
        }

        string twitch;
        [JsonProperty("twitch")]
        public string Twitch
        {
            get { return twitch; }
            set
            {
                if (twitch != value)
                {
                    twitch = value;
                    NotifyPropertyChanged("Twitch");
                }
            }
        }

        int trueskill;
        [JsonProperty("trueskill")]
        public int Trueskill
        {
            get { return trueskill; }
            set
            {
                if (trueskill != value)
                {
                    trueskill = value;
                    NotifyPropertyChanged("Trueskill");
                }
            }
        }
    }
}
