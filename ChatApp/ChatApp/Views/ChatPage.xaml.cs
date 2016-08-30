using ChatApp.Models.Csharp;
using ChatApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ChatApp.Views
{
    /// <summary>
    /// Chat Page.
    /// </summary>
    public sealed partial class ChatPage : Page
    {
        private ChatPageViewModel _vm;

        public ChatPage()
        {
            this.InitializeComponent();
            _vm = new ChatPageViewModel();
            DataContext = _vm;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            _vm.ChatCorrespondent = e.Parameter as Profile;
        }


        //What are these for?
        static public int MinViewWidth { get; set; } = 620;
        static public int PaneWidth { get; set; } = 330;


        /// <summary>
        /// Occures when the full screen button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        /// It would make more sense for this to be a toggle button.
        void fullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            AppShell.GoFullScreen();
        }

        /// <summary>
        /// Sets the current message text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _vm.SetText(textBox.Text);
            if (!string.IsNullOrEmpty(textBox.Text) && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                likeButton.Visibility = Visibility.Collapsed;
                sendButton.Visibility = Visibility.Visible;
            }
            else
            {
                likeButton.Visibility = Visibility.Visible;
                sendButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}
