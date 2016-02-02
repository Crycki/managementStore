using ManagementStore_DataModel.Security;
using ManagementStore_DomainLogic;
using System;
using System.Net;
using System.ServiceModel.Web;

namespace ManagementStore_REST
{
    public abstract class AbstractService
    {
        private readonly SecurityService _securityService = new SecurityService();
               
        public User GetUser()
        {
            return _securityService.GetUser(GetSessionId());
        }

        public static string GetSessionId()
        {
            if (WebOperationContext.Current != null)
            {
                var sessionId = WebOperationContext.Current.IncomingRequest.Headers["user_session_id"];
                return sessionId;
            }
            return null;
        }
    }
}