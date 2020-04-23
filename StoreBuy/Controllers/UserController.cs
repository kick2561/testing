//using StoreBuy.Domain;
//using StoreBuy.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace StoreBuy.Controllers
//{
//    public class UserController : ApiController
//    {
//        IGenericRepository<Users> repository = null;

//        public UserController(IGenericRepository<Users> respository)
//        {
//            this.repository = respository;

//        }

//        // GET: api/Details
//        public IEnumerable<Users> GetAllUserDetails()
//        {
//            try { 

//                return repository.GetAll();
//            }
//            catch (Exception exe)
//            {
//                throw exe;
//            }
//        }


//        // GET: api/User/5
//        public Users Get(string UserName)
//        {
//            try
//            {
//                return repository.GetById(UserName);
//            }
//            catch (Exception exe)
//            {
//                throw exe;
//            }
//        }

//        public IHttpActionResult GetLogin(string UserName,string UserPassword)
//        {

//            try
//            {
//                Users userDetails = repository.GetById(UserName);

//                if (userDetails != null)
//                {
//                    if (UserPassword.Equals(userDetails.UserPassword))
//                    {
//                        return  Ok(UserName);
//                    }
//                }
//                return BadRequest();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public IHttpActionResult changePassword(string UserName,string OldPassword,string NewPassword)
//        {
//            try
//            {
//                Users user = repository.GetById(UserName);
//                if (user != null)
//                {
//                    if (OldPassword.Equals(user.UserPassword))
//                        user.UserPassword = NewPassword;
//                    else
//                        return BadRequest();

//                    repository.InsertOrUpdate(user);
//                    return Ok(UserName);
//                }
//                return BadRequest();
//            }
//            catch(Exception exc)
//            {
//                throw exc;
//            }
//        }

//        //[HttpPost]
//        public IHttpActionResult Post([FromBody]Users user)
//        {
//            try
//            {
//                repository.InsertOrUpdate(user);
//                return Ok(user);
//            }
//            catch
//            {
//                return BadRequest();
//            }
//        }




//        // PUT: api/User/5
//        public IHttpActionResult Put([FromBody]Users user)
//        {
//            try
//            {
//                repository.InsertOrUpdate(user);
//                return BadRequest();
//            }
//            catch
//            {
//                return Ok(user);
//            }
//        }

//        // DELETE: api/User/5
//        public IHttpActionResult Delete(string userid)
//        {
//            try
//            {
//                repository.Delete(userid);
//                return Ok(userid);
//            }
//            catch
//            {
//                return BadRequest();
//            }
//        }
//    }
//}

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
    [Route("User")]
    public class UserController : ApiController
    {
        IGenericRepository<Users> repository = null;

        public UserController(IGenericRepository<Users> respository)
        {
            this.repository = respository;
        }

        [HttpGet]
        [Route("GetAllUserDetails")]
        // GET: api/Details
        public IEnumerable<Users> GetAllUserDetails()
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

        [HttpGet]
        [Route("GetById")]
        // GET: api/User/5
        public Users GetById(string UserName)
        {
            try
            {
                return repository.GetById(UserName);
            }
            catch (Exception exe)
            {
                throw exe;
            }
        }



        [HttpGet]
        [Route("Login")]
        public IHttpActionResult GetLogin(string UserName, string UserPassword)
        {
            try
            {
                Users userDetails = repository.GetById(UserName);
                if (userDetails != null)
                {
                    if (UserPassword.Equals(userDetails.UserPassword))
                    {
                        return Ok(UserName);
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost]
        [Route("ChangePassword")]
        public IHttpActionResult changePassword(string UserName, string OldPassword, string NewPassword)
        {
            try
            {
                Users user = repository.GetById(UserName);
                if (user != null)
                {
                    if (OldPassword.Equals(user.UserPassword))
                        user.UserPassword = NewPassword;
                    else
                        return BadRequest();




                    repository.InsertOrUpdate(user);
                    return Ok(UserName);
                }
                return BadRequest();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }




        [HttpPost]
        [Route("api/User/Register")]
        public IHttpActionResult PostRegister([FromBody]Users user)
        {
            try
            {
                var password = user.UserPassword;
                var email = user.Email;
                Constraint check = new Constraint();

                if (check.ValidatePassword(password) == true && check.ValidateEmail(email) == true )
                {
                    repository.InsertOrUpdate(user);
                    return Ok(user);
                }
                else return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }







        // PUT: api/User/5
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put([FromBody]Users user)
        {
            try
            {
                repository.InsertOrUpdate(user);
                return BadRequest();
            }
            catch
            {
                return Ok(user);
            }
        }



        [HttpDelete]
        [Route("Delete")]
        // DELETE: api/User/5
        public IHttpActionResult Delete(string userid)
        {
            try
            {
                repository.Delete(userid);
                return Ok(userid);
            }
            catch
            {
                return BadRequest();
            }
        }





        [HttpGet]
        [Route("GetForgotPassword")]
        public HttpResponseMessage GetForgotPassword(string Username)
        {
            Users userDetails = repository.GetById(Username);
            if (userDetails != null)
            {
                return Request.CreateResponse(HttpStatusCode.Found, "Username exists");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "User with username:" + Username + " not found");
            }
        }
    }
}
