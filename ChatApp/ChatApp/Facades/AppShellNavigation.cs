using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Views;
using Windows.UI.Xaml.Controls;

namespace ChatApp.Facades
{
    /// <summary>
    /// Navigation of the appshell frames from within.
    /// </summary>
    public static class AppShellNavigation
    {
        public static Frame ContactsFrame { get; set; }
        public static Frame ChatFrame { get; set; }
        public static AppShell AppShell { get; set; }
    }
}
