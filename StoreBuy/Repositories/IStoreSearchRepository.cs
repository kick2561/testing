﻿using StoreBuy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBuy.Repositories
{
    public interface IStoreSearchRepository : IGenericRepository<StoreA>
    {
        List<ItemCatalogue> ItemsAvailableInStore(Users User, StoreInfo Store);
    }
}