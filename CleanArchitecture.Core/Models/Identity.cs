using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Models
{
    public class Identity
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public Role Role { get; set; }
    }
}
