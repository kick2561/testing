using NHibernate;
using StoreBuy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBuy.Repositories
{
    public class StoreAFilledSlotRepository : GenericRepository<StoreAFilledSlot>, IStoreAFilledSlotRepository
    {
        public UnitOfWork UnitOfWork;

        StoreAFilledSlotRepository(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
            this.UnitOfWork = (UnitOfWork)UnitOfWork;
        }
        protected ISession Session { get { return UnitOfWork.Session; } }

        public bool CheckStoreASlotFilled(string SlotTime, string SlotDate)
        {
            try
            {
                var IsAvailable = Session.Query<StoreAFilledSlot>().Where(x => x.SlotDate == SlotDate && x.SlotTime == SlotTime).SingleOrDefault();
                if (IsAvailable == null)
                    return false;
                else
                    return true;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
    }