using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBuy.Domain
{
    public class StoreInfo
    {
        public virtual long StoreId { get; set; }
        public virtual string StoreName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }

        //public virtual long StoreLocationId { set; get; }
    }
}