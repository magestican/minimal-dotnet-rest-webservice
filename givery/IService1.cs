using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace givery
{
    [ServiceContract]
    public interface Iapi
    {

        [OperationContract]
        [WebGet(UriTemplate = "/", ResponseFormat = WebMessageFormat.Json)]
        string test();

        //users
        [OperationContract]
        [WebInvoke(UriTemplate = "/users/students/events?from={from}&offset={offset}&limit={limit}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        List<WrapperEvent> getStudentPublicEvents(string from, int offset, int limit);

        [OperationContract]
        [WebInvoke(UriTemplate = "/users/students/events/reserve?token={token}&eventId={eventId}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string reserveEvent(string token, int eventId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/users/students/events/unreserve?token={token}&eventId={eventId}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string unreserveEvent(string token, int eventId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/users/companies/events?token={token}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        List<WrapperEvent> getCompanyEvents(string token);

        [OperationContract]
        [WebInvoke(UriTemplate = "/auth/login?email={email}&password={password}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        WrapperUser login(string email, string password);



    }

}
