using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Models
{
    public class NewUser
    {
        public bool isAdmin { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// imagen en base64.
        /// </summary>
        public string Image { get; set; }

        public DateTime Birthday { get; set; }
    }
}
