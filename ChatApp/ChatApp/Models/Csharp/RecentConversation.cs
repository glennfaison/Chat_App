using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models.Csharp
{
    /// <summary>
    /// The recent conversations
    /// </summary>
    public class RecentConversation
    {
        /// <summary>
        /// The last message of the conversation.
        /// </summary>
        public Message LastMessage { get; set; }

        /// <summary>
        /// The user "this" user is conversing with.
        /// </summary>
        public User User { get; set; }
    }
}
