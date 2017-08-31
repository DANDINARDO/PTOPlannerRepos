using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PTOPlanner.Repository.Domain;
using PTOPlanner.Repository.Repositories;

namespace PTOPlanner.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepos _userRepos;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserController()
        {
            _userRepos = new UserRepos();
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>List of Users</returns>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = _userRepos.GetUsers();
            if (users == null || users.Count == 0) throw new HttpResponseException(HttpStatusCode.NoContent);
            return users;
        }

        /// <summary>
        /// Get a User by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>List of Users</returns>
        [HttpGet]
        // GET: api/User/5
        public User Get(int id)
        {
            var user = new User();
            if (user == null) throw new HttpResponseException(HttpStatusCode.NoContent);
            return user;
        }

        /// <summary>
        /// Post a User
        /// </summary>
        /// <param name="user">User Object</param>
        /// <returns>Response Status</returns>
        /// <remarks>Not Yet Implemented</remarks>
        [HttpPost]
        // POST: api/User
        public HttpResponseMessage Post(User user)
        {
            try
            {
                //TODO: Add Post Logic
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="id">UserId</param>
        /// <param name="user">User Object</param>
        /// <returns></returns>
        /// <remarks>Not Yet Implemented</remarks>
        [HttpPut]
        // PUT: api/User/5
        public HttpResponseMessage Put(int id, User user)
        {
            try
            {
                //TODO: Add Put Logic
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }     
        }

        ///// <summary>
        ///// Delete a User
        ///// </summary>
        ///// <param name="id"></param>
        //[HttpDelete]
        //// DELETE: api/User/5
        //public void Delete(int id)
        //{
        //}
    }
}
