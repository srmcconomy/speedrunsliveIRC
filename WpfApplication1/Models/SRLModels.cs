using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLModels
{
    class Entrant : ModelBase
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

    class Game : ModelBase
    {
        string id;
        [JsonProperty("id")]
        public string ID
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        string name;
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        string abbreviation;
        [JsonProperty("abbrev")]
        public string Abbreviation
        {
            get { return abbreviation; }
            set
            {
                if (abbreviation != value)
                {
                    abbreviation = value;
                    NotifyPropertyChanged("Abbreviation");
                }
            }
        }

        double popularity;
        [JsonProperty("popularity")]
        public double Popularity
        {
            get { return popularity; }
            set
            {
                if (popularity != value)
                {
                    popularity = value;
                    NotifyPropertyChanged("Popularity");
                }
            }
        }

        int popularityRank;
        [JsonProperty("popularityrank")]
        public int PopularityRank
        {
            get { return popularityRank; }
            set
            {
                if (popularityRank != value)
                {
                    popularityRank = value;
                    NotifyPropertyChanged("PopularityRank");
                }
            }
        }
    }

    class Race : ModelBase
    {
        string id;
        [JsonProperty("id")]
        public string ID
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        Game game;
        [JsonProperty("game")]
        public Game Game
        {
            get { return game; }
            set
            {
                if (game != value)
                {
                    game = value;
                    NotifyPropertyChanged("Game");
                }
            }
        }

        string goal;
        [JsonProperty("goal")]
        public string Goal
        {
            get { return goal; }
            set
            {
                if (goal != value)
                {
                    goal = value;
                    NotifyPropertyChanged("Goal");
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

        int state;
        [JsonProperty("state")]
        public int State
        {
            get { return state; }
            set
            {
                if (state != value)
                {
                    state = value;
                    NotifyPropertyChanged("State");
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

        string filename;
        [JsonProperty("filename")]
        public string Filename
        {
            get { return filename; }
            set
            {
                if (filename != value)
                {
                    filename = value;
                    NotifyPropertyChanged("Filename");
                }
            }
        }

        int numEntrants;
        [JsonProperty("numentrants")]
        public int NumEntrants
        {
            get { return numEntrants; }
            set
            {
                if (numEntrants != value)
                {
                    numEntrants = value;
                    NotifyPropertyChanged("NumEntrants");
                }
            }
        }

        Dictionary<string, Entrant> entrants;
        [JsonProperty("entrants")]
        public Dictionary<string, Entrant> Entrants
        {
            get { return entrants; }
            set
            {
                if (entrants != value)
                {
                    entrants = value;
                    NotifyPropertyChanged("Entrants");
                }
            }
        }
    }

    class SRL : ModelBase
    {
        int count;
        [JsonProperty("count")]
        public int Count
        {
            get { return count; }
            set
            {
                if (count != value)
                {
                    count = value;
                    NotifyPropertyChanged("Count");
                }
            }
        }

        List<Race> races;
        [JsonProperty("races")]
        public List<Race> Races
        {
            get { return races; }
            set
            {
                if (races != value)
                {
                    races = value;
                    NotifyPropertyChanged("Races");
                }
            }
        }
    }
}
