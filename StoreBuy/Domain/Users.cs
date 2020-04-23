using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreBuy.Domain
{
    public class Users
    {
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserPassword { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }

    }
}
