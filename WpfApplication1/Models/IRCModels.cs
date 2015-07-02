using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IRCModels
{
    public class Message : ModelBase
    {
        string s;

        string command;
        public string Command
        {
            get { return command; }
        }

        List<string> parameters;
        public List<string> Parameters
        {
            get { return parameters; }
        }

        string trail;
        public string Trail
        {
            get { return trail; }
        }

        string user;
        public string User
        {
            get { return user; }
        }

        public Message()
        {
            parameters = new List<string>();
        }

        public static Message ParseString(String str)
        {
            Regex r = new Regex(@"^(?::([^\s]+)(?:![^\s]+)?\s+)?(\d\d\d|[A-Za-z]+)((?:\s[^\s:]+)*)(?:\s:(.*))?");
            var groups = r.Match(str).Groups;

            Message msg = new Message();
            msg.s = str;
            var i = 1;
            if (str[0] == ':') msg.user = groups[i++].Value;
            msg.command = groups[i++].Value;
            msg.parameters = groups[i++].Value.Substring(1).Split(' ').ToList();
            msg.trail = groups[i++].Value;
            return msg;
        }

        public static implicit operator string(Message m)
        {
            return m.s;
        }
    }
}
