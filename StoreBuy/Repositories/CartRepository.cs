using NHibernate;
using StoreBuy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBuy.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public UnitOfWork UnitOfWork { get; set; }

        public CartRepository(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
            this.UnitOfWork = (UnitOfWork)UnitOfWork;
        }
        protected ISession Session { get { return UnitOfWork.Session; } }

        public Cart GetByUserandItem(string UserName, long ItemId)
        {
            try
            {
                Users user = Session.Get<Users>(UserName);
                ItemCatalogue cartItem = Session.Get<ItemCatalogue>(ItemId);
                var cart = Session.Query<Cart>().Where(x => x.User == user && x.ItemCatalogue == cartItem).SingleOrDefault();
                return cart;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Delete(string UserName, long ItemId)
        {
            try
            {
                // TODO: Add delete logic here
                Users User = Session.Get<Users>(UserName);
                ItemCatalogue CartItem = Session.Get<ItemCatalogue>(ItemId);

                var cart = Session.Query<Cart>().Where(x => x.User == User && x.ItemCatalogue == CartItem).SingleOrDefault();
                Session.Delete(cart);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}