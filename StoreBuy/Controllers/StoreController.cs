using StoreBuy.Domain;
using StoreBuy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreBuy.Controllers
{
    public class StoreController : ApiController
    {
        IGenericRepository<StoreInfo> repository = null;

        
        public StoreController(IGenericRepository<StoreInfo> respository)
        {
            this.repository = respository;
            
        }

        // GET: api/Details
        public IEnumerable<StoreInfo> GetAllStoreDetails()
        {
            try
            {

                return repository.GetAll();
            }
            catch (Exception exe)
            {
                throw exe;
            }
        }        

        // GET: api/User/5
        public StoreInfo Details(long storeid)
        {
            try
            {
                return repository.GetById(storeid);
            }
            catch (Exception exe)
            {
                throw exe;
            }
        }

        //[HttpPost]
        public IHttpActionResult Post([FromBody]StoreInfo store)
        {
            try
            {
                repository.InsertOrUpdate(store);
                return Ok(store);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/User/5
        public IHttpActionResult Put([FromBody]StoreInfo store)
        {
            try
            {
                repository.InsertOrUpdate(store);
                return Ok(store);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/User/5
        public IHttpActionResult Delete(long storeid)
        {
            try
            {
                repository.Delete(storeid);
                return Ok(storeid);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
