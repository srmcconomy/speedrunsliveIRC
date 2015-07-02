using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(TextBox_GotFocus));
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.PreviewMouseLeftButtonDownEvent, new RoutedEventHandler(TextBox_Clicked));

            EventManager.RegisterClassHandler(typeof(PasswordBox), PasswordBox.GotFocusEvent, new RoutedEventHandler(PasswordBox_GotFocus));
            EventManager.RegisterClassHandler(typeof(PasswordBox), PasswordBox.PreviewMouseLeftButtonDownEvent, new RoutedEventHandler(PasswordBox_Clicked));
            base.OnStartup(e);
        }

        private void PasswordBox_Clicked(object sender, RoutedEventArgs e)
        {
            var textbox = sender as PasswordBox;
            if (!textbox.IsKeyboardFocusWithin)
            {
                textbox.Focus();
                e.Handled = true;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as PasswordBox).SelectAll();
        }

        private void TextBox_Clicked(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            if (!textbox.IsKeyboardFocusWithin)
            {
                textbox.Focus();
                e.Handled = true;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
    }

    
}
