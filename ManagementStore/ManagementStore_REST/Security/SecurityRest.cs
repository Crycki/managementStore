using ManagementStore_DataModel.Security;
using ManagementStore_DomainLogic;
using System;
using System.Net;
using System.ServiceModel.Web;

namespace ManagementStore_REST.Security
{
    public class SecurityRest : AbstractService, ISecurityRest
    {
        private readonly SecurityService _securityService = new SecurityService();

        public User Login(Credentials sessionCredential)
        {
            try
            {
                return _securityService.Login(sessionCredential);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.InternalServerError);
            }
        }      
    }
}