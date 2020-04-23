using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBuy.Domain
{
    public class StoreAFilledSlot
    {
        public virtual long SlotId { get; set; }

        public virtual string SlotDate { get; set; }


        public virtual string SlotTime { get; set; }
    }
}