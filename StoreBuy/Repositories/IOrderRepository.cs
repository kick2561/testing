using StoreBuy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBuy.Repositories
{
    public interface IOrdersRepository : IGenericRepository<Orders>
    {
        bool Notify(Orders order);
        int IsSlotFilled(Orders order);
    }
}