using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsersDataAccess;
using WebApplicationAPIs;

namespace WebApplicationAPIs.Models
{
    public class JointClass
    {
        public User getuser { get; set; }
        public UserProfile getuserprofile { get; set; }
    }
}
