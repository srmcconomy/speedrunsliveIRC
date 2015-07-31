using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class RaceBotParser
    {
        Regex RaceStarted = new Regex(@"^Race initiated for (.*)\. Join (#srl-[^\s]+) to participate\.\s*$");
        Regex RaceFinished = new Regex(@"^Race finished: (.*) - (.*) \| (#srl-[^\s]+) \| (\d+) entrants\s*$");
        Regex RaceList = new Regex(@"^\d\. (.*) - (.*) \| (#srl-[^\s]+) \| (\d+) entrants \| (.+)\s*$");
        Regex GoalSet = new Regex(@"^Goal Set: (.*) - (.*) \| (#srl-[^\s]+)\s*$");
        Regex Forfeit = new Regex(@"^([^\s]+) has forfeited from the race\.\s*$");
        Regex PlayerComment = new Regex(@"^\.comment (.*)\s*$");
        Regex CommentAdded = new Regex(@"^Comment added\.\s*$");
        Regex PlayerComment = new Regex(@"^\.setstream ([^\s]+)\s*$");
        Regex StreamSet = new Regex(@"^Stream set\.\s*$");
        Regex PlayerFinished = new Regex(@"^([^\s]+) has finished in (\d+).. place with a time of ([^\s]+)\.\s*$");
        Regex RaceRecorded = new Regex(@"^Race recorded: (.*)\s*$");
    }
}
