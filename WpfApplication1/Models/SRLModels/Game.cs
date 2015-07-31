using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLModels
{
    public class Game : ModelBase
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
}
