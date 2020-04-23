using StoreBuy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBuy.Repositories
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Cart GetByUserandItem(string UserName, long ItemId);
        void Delete(string UserName, long ItemId);

    }
}