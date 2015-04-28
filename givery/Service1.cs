using System;
using System.Collections.Generic;
using System.Linq;


namespace givery
{

    public class Service1 : IService1
    {
        static List<dynamic> loggedUsers = new List<dynamic>();


        public List<WrapperEvent> getEvents()
        {
            TestContext.TestDataContext giveryContext = new TestContext.TestDataContext();
            //get user from database
            var query = from evnt in giveryContext.Events
                        select evnt;

            List<WrapperEvent> events = new List<WrapperEvent>();
            foreach (TestContext.Event evnt in query)
            {
                events.Add(new WrapperEvent() { id = evnt.Id, name = evnt.Name, startDate = evnt.StartDate, userId = evnt.UserId });
            }

            return events;
        }

        public WrapperUser login(string email, string password)
        {
            TestContext.TestDataContext giveryContext = new TestContext.TestDataContext();
            //get user from database
            var query = from user in giveryContext.Users
                        where user.Email == email && user.Password == password
                        orderby user.GroupId
                        select user;

            var dbUser = query.First();

            WrapperUser userToReturn = null;

            //map accordingly
            if (dbUser.GroupId == (int)UserTypes.Company)
                userToReturn = new WrapperCompany() { email = dbUser.Email, id = dbUser.Id, name = dbUser.Name, group = dbUser.GroupId };
            else if ((dbUser.GroupId == (int)UserTypes.Student))
                userToReturn = new WrapperStudent() { email = dbUser.Email, id = dbUser.Id, name = dbUser.Name, group = dbUser.GroupId };

            //check if the user is logged
            if (loggedUsers.Exists(obj => obj.id == dbUser.Id))
                userToReturn.token = Convert.ToString(loggedUsers.Select(obj => obj.token));
            else
            {
                userToReturn.token = Guid.NewGuid().ToString();
                loggedUsers.Add(new { id = userToReturn.id, token = userToReturn.token });
            }

            return userToReturn;

        }
    }
}
