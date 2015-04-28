using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace givery
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/events")]
        List<WrapperEvent> getEvents();


        [OperationContract]
        [WebInvoke(UriTemplate = "/{user}/{password}", Method = "POST")]
        WrapperUser login(string email, string password);

    }

}
