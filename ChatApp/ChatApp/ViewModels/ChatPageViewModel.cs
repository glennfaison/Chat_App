﻿
using ChatApp.Common;
using ChatApp.Models.Csharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.ViewModels
{
    /// <summary>
    /// view model for the chat page.
    /// </summary>
    public class ChatPageViewModel : BindableBase
    {
        private ObservableCollection<Message> _messages;
        private string _text;
        private Profile _chatCorrespondent;

        /// <summary>
        /// The message text.
        /// </summary>
        public string Text { get { return _text; } set { SetProperty(ref _text, value); } }

        public ObservableCollection<Message> Messages { get { return _messages; } }

        /// <summary>
        /// The chatcorrespondent.
        /// </summary>
        public Profile ChatCorrespondent { get { return _chatCorrespondent; } set { SetProperty(ref _chatCorrespondent, value); } }

        public ChatPageViewModel()
        {
            _messages = Facades.MessageFacade.GetMessages(App.ThisUser, App.AnotherUser);
        }

        /// <summary>
        /// Sets the message to text from the textbox.
        /// </summary>
        /// <param name="text"></param>
        internal void SetText(string text)
        {
            Text = text;
        }
    }
}