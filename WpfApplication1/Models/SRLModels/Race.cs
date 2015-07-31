using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLModels
{
    public enum RaceState { EntryOpen = 1, Completed, InProgress}

    public class Race : ModelBase
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

        RaceState state;
        [JsonProperty("state")]
        public RaceState State
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
}
