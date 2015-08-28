using IRCModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1;
using ViewModels;
using Utilities;
using Views;

namespace ViewModels
{
    class MainView : ModelBase
    {
        ObservableCollection<Message> messages;
        public ObservableCollection<Message> Messages
        {
            get { return messages; }
        }

        ObservableDictionary<string, ChannelViewModel> channels;
        public ObservableDictionary<string, ChannelViewModel> Channels
        {
            get { return channels; }
        }

        ObservableDictionary<string, ChannelViewModel> pinnedChannels;
        public ObservableDictionary<string, ChannelViewModel> PinnedChannels
        {
            get { return pinnedChannels; }
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
            channels = new ObservableDictionary<string, ChannelViewModel>();
            channels.Add("#speedrunslive", new ChannelViewModel { Title = "#speedrunslive" });
            channels.Add("#bingo", new ChannelViewModel { Title = "#bingo" });
            pinnedChannels = new ObservableDictionary<string, ChannelViewModel>();
            pinnedChannels.Add("#speedrunslive", new ChannelViewModel { Title = "#speedrunslive" });
            pinnedChannels.Add("#bingo", new ChannelViewModel { Title = "#bingo" });
            messages = new ObservableCollection<Message>();
            var msg = Message.ParseString(":BOB!asdf PART #speedrunslive :how's it going");
            var msg1 = Message.ParseString(":BOB!asdf JOIN #speedrunslive :how's it going");
            var msg2 = Message.ParseString(":BOB!asdf NOTICE #speedrunslive :how's it going");
            var msg3 = Message.ParseString(":BOB!asdf PRIVMSG #bingo :how's it goingkjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj");
            MessageAdded(msg);
            MessageAdded(msg1);
            MessageAdded(msg2);
            MessageAdded(msg3);
        }

        void MessageAdded(Message msg)
        {
            switch (msg.Command)
            {
                case ("PRIVMSG"): case("NOTICE"): case("JOIN"): case("PART"):
                    var mvm = new MessageViewModel() { Content = msg.Trail, User = new User { Type = User.UserType.Normal, Name = msg.User }, Timestamp = DateTime.Now, Message = msg };
                    if (!channels.ContainsKey(msg.Parameters[0])) channels.Add(msg.Parameters[0], new ChannelViewModel { Title = msg.Parameters[0] });
                    App.Current.Dispatcher.BeginInvoke(new Action(() => channels[msg.Parameters[0]].Messages.Add(mvm)));
                    break;
            }
        }


    }
}
