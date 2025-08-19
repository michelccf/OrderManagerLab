using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.DTOs
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
    }
}
