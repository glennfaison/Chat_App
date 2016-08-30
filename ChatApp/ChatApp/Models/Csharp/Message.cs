using ChatApp.Models.Csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models.Csharp
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

        //Comparism and mapping.
        public override bool Equals(object obj) => (obj as Message).Id == Id;
        public override int GetHashCode() => Id;
    }
}
