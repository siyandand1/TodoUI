using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutherService
{
    public class User : RealmObject
    {
        [PrimaryKey]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
