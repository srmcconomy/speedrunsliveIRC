using Newtonsoft.Json.Linq;
using SRLModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utilities;
using ViewModels;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IRC IRC { get; set; }
        public IRCPoller IRCPoller { get; set; }
        public MainWindow()
        {

            /*
            IRC = new IRC();
            IRCPoller = new IRCPoller(IRC);
            MainView mainView = new MainView() { MainWindow = this };
            this.DataContext = mainView; 
            InitializeComponent();
             */
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
            var client = new HttpClient();
            var _ = await client.GetAsync("http://api.speedrunslive.com/races");
            var __ = await _.Content.ReadAsStringAsync();
            var ___ = JObject.Parse(__).SelectToken("races").ToObject<List<Race>>();
            ObservableDictionary<string, Race> races = new ObservableDictionary<string, Race>();
            foreach (var race in ___)
            {
                    races.Add(race.ID, race);
            }
            var pp = new PlayPage();
            pp.DataContext = new { Races = races };
            Frame.Navigate(pp);

            /*
            await IRC.Connect("irc2.speedrunslive.com");
            await IRC.Send("NICK mrfakeman\r\n");
            await IRC.Send("User mrfakeman mrfakeman mrfakeman :mrfakeman\r\n");

            IRCPoller.Start();
             * */
        }
    }
}
