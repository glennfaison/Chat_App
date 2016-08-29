using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    /// <summary>
    /// A message between 2 users.
    /// </summary>
    public class Message
    {
        public int Id { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public DateTime? DateTime { get; set; }
        public string Content { get; set; }
    }
}
