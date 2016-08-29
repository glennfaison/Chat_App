using ChatApp.Models;
using ChatApp.Storage;
using System;

namespace ChatApp.ViewModels
{
    public class RecentlyContactedViewModel
    {
        public string CorrespondentUserName { get; private set; }
        public DateTime? DateTime { get; private set; }
        public string ImagePath { get; private set; }
        public string Content { get; private set; }
        public int CorrespondentId { get; private set; }

        public RecentlyContactedViewModel(Message message)
        {
            string error;
            User correspondent = ChatAppDataModel.GetCorrespondent(message, out error);
            CorrespondentUserName = correspondent.Username;
            CorrespondentId = correspondent.Id;
            ImagePath = correspondent.ImagePath;
            DateTime = message.DateTime;
            Content = message.Content;
        }
    }
}
