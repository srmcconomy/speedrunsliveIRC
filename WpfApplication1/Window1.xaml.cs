using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;
using SRLModels;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Loaded += Window1_Loaded;
        }

        async void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            var _ = await client.GetAsync("http://api.speedrunslive.com/races");
            var __ = await _.Content.ReadAsStringAsync();
            var ___ = JObject.Parse(__).ToObject<SRL>();
        }
    }
}
