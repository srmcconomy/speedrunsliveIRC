using IRCModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    class MessageViewModel : ModelBase
    {
        DateTime timestamp;
        public DateTime Timestamp
        {
            get { return timestamp; }
            set
            {
                if (timestamp != value)
                {
                    timestamp = value;
                    NotifyPropertyChanged("Timestamp");
                }
            }
        }

        string content;
        public string Content
        {
            get { return content; }
            set
            {
                if (content != value)
                {
                    content = value;
                    NotifyPropertyChanged("Content");
                }
            }
        }

        User user;
        public User User 
        {
            get { return user; }
            set 
            {
                if (user != value)
                {
                    user = value;
                    NotifyPropertyChanged("User");
                }
            }
        }

        Message message;
        public Message Message
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
    }
}
