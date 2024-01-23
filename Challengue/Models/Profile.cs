using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challengue.Models
{
    public class Profile
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Age { get; set; }
        public virtual string City { get; set; }

    }
}