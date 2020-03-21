using System;
using System.Collections.Generic;
using System.Text;
using TEST.PROJECT;

namespace TEST.Service
{
    public interface IUserProfileService
    {
        UserProfile GetUserProfile(long id);

    }
}
