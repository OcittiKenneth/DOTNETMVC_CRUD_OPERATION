using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UsersDataAccess;
using WebApplicationAPIs;
using WebApplicationAPIs.Models;

namespace WebApplicationAPIs.Controllers
{
    public class UsersController : ApiController
    {
        public IHttpActionResult Get()
        {
            myfirsttestdbEntities entities = new myfirsttestdbEntities();
            {
                List<User> users = entities.Users.ToList();
                List<UserProfile> userProfile = entities.UserProfiles.ToList();
                var query = from user in users
                            join userProfileTable in userProfile on user.Id equals userProfileTable.Id into jointTable
                            from userProfileTable in jointTable.DefaultIfEmpty()
                            select new JointClass { getuser = user, getuserprofile = userProfileTable };
                return Ok(query);
            } 
        }

        public IHttpActionResult Get(int id)
        {
            myfirsttestdbEntities entities = new myfirsttestdbEntities();
            {
                List<User> users = entities.Users.ToList();
                List<UserProfile> userProfile = entities.UserProfiles.ToList();

                var query = from user in users
                            join userProfileTable in userProfile on user.Id equals userProfileTable.Id into jointTable
                            from userProfileTable in jointTable.DefaultIfEmpty()
                            select new JointClass { getuser = user, getuserprofile = userProfileTable };
                return Ok(entities.Users.FirstOrDefault(u => u.Id == id));
            }
        }

        public IHttpActionResult Post(User usere)
        {
            myfirsttestdbEntities entities = new myfirsttestdbEntities();
            {
                List<User> users = entities.Users.ToList();
                List<UserProfile> userProfile = entities.UserProfiles.ToList();

                var query = from user in users
                            join userProfileTable in userProfile on user.Id equals userProfileTable.Id into jointTable
                            from userProfileTable in jointTable.DefaultIfEmpty()
                            select new JointClass { getuser = user, getuserprofile = userProfileTable };
                entities.Users.Add(usere);
                return Ok(query);
            }
        }



        /*
        //POSTING
        public IHttpActionResult Insertusers(JointTablesClass jointtables)
        {
            myfirsttestdbEntities entities = new myfirsttestdbEntities();
            entities.Users(jointtables.AddedDate, jointtables.Address, jointtables.Email, jointtables.FirstName, jointtables.Id,
            jointtables.IPAddress, jointtables.LastName, jointtables.ModifiedDate, jointtables.Password, jointtables.UserName);
            entities.SaveChanges();
            return Ok();
        }*/
        /*
        //UPDATING
        public IHttpActionResult updateusers(JointTablesClass jointtables)
        {
            myfirsttestdbEntities entities = new myfirsttestdbEntities();
            entities.Users(jointtables.AddedDate, jointtables.Address, jointtables.Email, jointtables.FirstName, jointtables.Id,
            jointtables.IPAddress, jointtables.LastName, jointtables.ModifiedDate, jointtables.Password, jointtables.UserName);
            entities.SaveChanges();
            return Ok();
        }

        //DELTETE
        public IHttpActionResult deleteusers(JointTablesClass jointtables)
        {
            myfirsttestdbEntities entities = new myfirsttestdbEntities();
            entities.Users(jointtables.AddedDate, jointtables.Address, jointtables.Email, jointtables.FirstName, jointtables.Id,
            jointtables.IPAddress, jointtables.LastName, jointtables.ModifiedDate, jointtables.Password, jointtables.UserName);
            entities.SaveChanges();
            return Ok();
        }
        */
    }
}
