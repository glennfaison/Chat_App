﻿
using ChatApp.Commands;
using ChatApp.Common;
using ChatApp.Facades;
using ChatApp.Models.Csharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatApp.ViewModels
{
    /// <summary>
    /// view model for the chat page.
    /// </summary>
    public class ChatPageViewModel : BindableBase
    {
        private ObservableCollection<Message> _messageThread;
        private string _text;
        private Profile _chatCorrespondent;

        /// <summary>
        /// The message text.
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
        public ObservableCollection<Message> MessageThread { get { return _messageThread; } }
        public ICommand SendMessage { get; set; }
        /// <summary>
        /// The chat correspondent.
        /// </summary>
        public Profile ChatCorrespondent
        {
            get { return _chatCorrespondent; }
            set { SetProperty(ref _chatCorrespondent, value); }
        }

        public ChatPageViewModel()
        {
            SendMessage = new SendMessageCommand(this);
            ChatCorrespondent = MessageFacade.Correspondent;
            _messageThread = MessageFacade.GetMessages();
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
