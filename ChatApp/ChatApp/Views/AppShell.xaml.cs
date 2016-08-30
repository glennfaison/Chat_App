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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppShell : Page
    {
        private static bool isFullScreen { get; set; } = false;

        public AppShell()
        {
            this.InitializeComponent();

            this.Loaded += (s, e) =>
            {
                Facades.AppShellNavigation.ChatFrame = this.chatFrame;
                Facades.AppShellNavigation.ContactsFrame = this.contactsFrame;

                Facades.AppShellNavigation.ContactsFrame.Navigate(typeof(ContactsPage));
            };
        }
        public static void GoFullScreen()
        {
            //go full screen here by tweaking visibilty
        }
        public static void LeaveFullScreen()
        {
            //leave full screen here by tweaking visibility
        }
    }
}
