using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models.Csharp
{
    /// <summary>
    /// Profiel of a user.
    /// </summary>
    public class Profile
    {
        public User User { get; set; }

        //If the user is active, lastactive is null.
        public DateTime? LastActive { get; set; }
    }
}
