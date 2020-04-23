using StoreBuy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBuy.Repositories
{
    public interface IStoreAFilledSlotRepository : IGenericRepository<StoreAFilledSlot>
    {
        bool CheckStoreASlotFilled(string SlotTime, string SlotDate);
    }
}