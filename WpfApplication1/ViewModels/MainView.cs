using IRCModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1;
using WpfApplication1.ViewModels;

namespace ViewModels
{
    class MainView
    {
        ObservableCollection<Message> messages;
        public ObservableCollection<Message> Messages
        {
            get { return messages; }
        }

        Dictionary<string, ObservableCollection<MessageViewModel>> channels;
        public Dictionary<string, ObservableCollection<MessageViewModel>> Channels
        {
            get { return channels; }
        }

        private MainWindow mainWindow;
        public MainWindow MainWindow
        {
            get { return mainWindow; }
            set
            {
                mainWindow = value;
                mainWindow.IRCPoller.OnMessageAdded += MessageAdded;
            }
        }

        public MainView()
        {
            messages = new ObservableCollection<Message>();
            channels = new Dictionary<string, ObservableCollection<MessageViewModel>>();
            var msg = Message.ParseString(":BOB!asdf PART #speedrunslive :how's it going");
            var msg1 = Message.ParseString(":BOB!asdf JOIN #speedrunslive :how's it going");
            var msg2 = Message.ParseString(":BOB!asdf NOTICE #speedrunslive :how's it going");
            var msg3 = Message.ParseString(":BOB!asdf PRIVMSG #bingo :how's it going");
            messages.Add(msg1);
            messages.Add(msg);
            messages.Add(msg2);
            messages.Add(msg3);

        }

        void MessageAdded(Message msg)
        {
            switch (msg.Command)
            {
                case ("PRIVMSG"): case("NOTICE"): case("JOIN"): case("PART"):
                    var mvm = new MessageViewModel() { Content = msg.Trail, User = new User { Type = User.UserType.Normal, Name = msg.User }, Timestamp = DateTime.Now, Message = msg };
                    if (!channels.ContainsKey(msg.Parameters[0])) channels.Add(msg.Parameters[0], new ObservableCollection<MessageViewModel>());
                    App.Current.Dispatcher.BeginInvoke(new Action(() => channels[msg.Parameters[0]].Add(mvm)));
                    break;
            }
        }


    }
}
