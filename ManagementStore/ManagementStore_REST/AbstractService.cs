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

        public bool ValidateSession()
        {
            string sessionId = GetSessionId();
            bool validSession = _securityService.ValidateSession(sessionId);
            if (validSession)
            {
                return true;
            }

            if (String.IsNullOrEmpty(sessionId))
            {
                throw new WebFaultException<string>("Session expired!", HttpStatusCode.Forbidden);
            }

            if (WebOperationContext.Current != null)
            {
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Pragma", "no-cache");
            }
            throw new WebFaultException<string>("Session expired!", HttpStatusCode.Gone);
        }

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