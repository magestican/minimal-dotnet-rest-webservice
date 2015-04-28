using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace givery
{
    internal class Helper
    {
        public static bool theRoleIs(UserTypes typeOfUser, string token)
        {

            if (api.loggedUsers.Exists(c => c.token == token))
            {
                var user = api.loggedUsers.Select(c => c.token == token).First();
                if (user != false && user.type == (int)typeOfUser)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

    }
}