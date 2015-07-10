using System;
using System.Collections.Generic;
using System.Linq;
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
            IRC = new IRC();
            IRCPoller = new IRCPoller(IRC);
            MainView mainView = new MainView() { MainWindow = this };
            this.DataContext = mainView; 
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await IRC.Connect("irc2.speedrunslive.com");
            await IRC.Send("NICK mrfakeman\r\n");
            await IRC.Send("User mrfakeman mrfakeman mrfakeman :mrfakeman\r\n");

            IRCPoller.Start();
        }
    }
}
