using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    public interface ILoggedInUser
    {
        public string UserId { get; }
    }
}
