using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;


namespace givery
{

    public class api : Iapi
    {
        internal static List<dynamic> loggedUsers = new List<dynamic>();



        public string test()
        {
            return "success!";
        }



        public List<WrapperEvent> getStudentPublicEvents(string aFrom, int offset, int limit)
        {
            TestContext.TestDataContext giveryContext = new TestContext.TestDataContext();
            //get user from database
            var query = from evnt in giveryContext.Events
                        where evnt.StartDate >= Convert.ToDateTime(aFrom)
                        select evnt;

            if (query != null )
            {
                if (offset > 0)
                    query = query.Skip(offset);
                if (limit > 0)
                    query = query.Take(limit);
            }

            List<WrapperEvent> events = new List<WrapperEvent>();
            foreach (TestContext.Event evnt in query)
            {
                events.Add(new WrapperEvent() { id = evnt.Id, name = evnt.Name, startDate = evnt.StartDate, userId = evnt.UserId });
            }

            return events;
        }

        public List<WrapperEvent> getCompanyEvents(string token)
        {
            if (!Helper.theRoleIs(UserTypes.Company, token))
                throw new InvalidCredentialException();

            TestContext.TestDataContext giveryContext = new TestContext.TestDataContext();
            //get user from database
            var query = from evnt in giveryContext.Events
                        select evnt;

            List<WrapperEvent> events = new List<WrapperEvent>();
            foreach (TestContext.Event evnt in query)
            {
                events.Add(new WrapperEvent()
                {
                    id = evnt.Id,
                    name = evnt.Name,
                    startDate = evnt.StartDate,
                    userId = evnt.UserId,
                    atendees = giveryContext.Attends.Where(c => c.UserId == evnt.UserId).Count()
                });
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

            TestContext.User dbUser;

            if (query != null)
                dbUser = query.First();
            else
                throw new InvalidCredentialException();

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
                loggedUsers.Add(new { id = userToReturn.id, token = userToReturn.token, type = userToReturn.group });
            }

            return userToReturn;
        }



        public string reserveEvent(string token, int eventId)
        {
            if (!Helper.theRoleIs(UserTypes.Student, token))
                throw new UnauthorizedAccessException();

            TestContext.TestDataContext giveryContext = new TestContext.TestDataContext();

            // Create a new category
            TestContext.Attend newCategory = new TestContext.Attend();
            newCategory.EventId = eventId;
            newCategory.UserId = loggedUsers.Where(c => c.token == token).First().id;

            giveryContext.Attends.InsertOnSubmit(newCategory);

            giveryContext.SubmitChanges();

            return "Reserved";
        }

        public string unreserveEvent(string token, int eventId)
        {
            if (!Helper.theRoleIs(UserTypes.Student, token))
                throw new UnauthorizedAccessException();

            TestContext.TestDataContext giveryContext = new TestContext.TestDataContext();

            var query = from evnt in giveryContext.Attends
                        where evnt.EventId == eventId
                        select evnt;
            var dbEvent = query.First();

            giveryContext.Attends.DeleteOnSubmit(dbEvent);

            giveryContext.SubmitChanges();


            return "Unreserved";
        }


    }
}
