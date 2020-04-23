using NHibernate;
using StoreBuy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBuy.Repositories
{
    public class OrdersRepository  : GenericRepository<Orders>, IOrdersRepository
    {
        public UnitOfWork UnitOfWork { get; set; }

        OrdersRepository(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
            this.UnitOfWork = (UnitOfWork)UnitOfWork;
        }
        protected ISession Session { get { return UnitOfWork.Session; } }

        //notifies the customer and retailer with orders details
        public bool Notify(Orders order)
        {
            return true;
        }

        public int IsSlotFilled(Orders order)
        {
            try
            {
                var SlotsFillCount = Session.Query<Orders>().Where(x => x.Store == order.Store && x.SlotTime == order.SlotTime && x.SlotDate == order.SlotDate).Count();
                return SlotsFillCount;
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

    }
}