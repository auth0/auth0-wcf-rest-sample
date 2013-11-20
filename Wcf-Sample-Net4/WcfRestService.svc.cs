using Microsoft.IdentityModel.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace Wcf_Sample_Net4
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfRestService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebGet]
        public string DoWork()
        {
            // Add your operation implementation here
            var userProfile = ((IClaimsIdentity)Thread.CurrentPrincipal.Identity).Claims;
            var email = userProfile.SingleOrDefault(c => c.ClaimType == "email");

            if (email != null)
            {
                return "Hello " + email;
            }
            else
            {
                return "Hello " + Thread.CurrentPrincipal.Identity.Name;
            }
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
