using NHibernate;
using StoreBuy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBuy.Repositories
{
    public class StoreSeachRepository : GenericRepository<StoreA>, IStoreSearchRepository
    {
        public UnitOfWork UnitOfWork;

        StoreSeachRepository(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
            this.UnitOfWork = (UnitOfWork)UnitOfWork;
        }

        protected ISession Session { get { return UnitOfWork.Session; } }

        public List<ItemCatalogue> ItemsAvailableInStore(Users User, StoreInfo Store)
        {

            //Get the StoreA Items using APIs
            List<ItemCatalogue> ItemsAvailableInStoreA = null;
            try
            {
                List<Cart> CartItems = Session.Query<Cart>().Where(x => x.User == User).ToList();
                foreach (Cart CartItem in CartItems)
                {
                    var Item = Session.Get<ItemCatalogue>(CartItem.ItemCatalogue.ItemId);
                    var StoreAItem = Session.Query<StoreA>().Where(x => x.StoreItemId == Item.ItemId).SingleOrDefault();
                    if (StoreAItem != null)
                    {
                        ItemsAvailableInStoreA.Add(Item);
                    }
                }
                return ItemsAvailableInStoreA;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}