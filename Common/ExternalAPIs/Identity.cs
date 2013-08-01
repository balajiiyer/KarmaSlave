using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karma.CloudAPI.Identity.Request;
using Karma.CloudAPI.Identity.Response;
using Newtonsoft.Json;

namespace Karma.CloudAPI.Identity.Request
{
    public class APICredentials
    {
        public string username { get; set; }
        public string apiKey { get; set; }
    }

    public class AuthCredentials
    {
        public AuthCredentials()
        {
            auth = new Auth();
        }

        public Auth auth { get; set; }
    }

    public class Auth
    {
        public Auth()
        {
            APICredentials = new APICredentials();
        }
        [Newtonsoft.Json.JsonProperty("RAX-KSKEY:apiKeyCredentials")]
        public APICredentials APICredentials { get; set; }
    }

}
namespace Karma.CloudAPI.Identity
{  
    public static class Identity
    {
        public static string Authenticate(string username, string  apikey)
        {
            Uri uri = new Uri(CloudAPIUrls.Identity);

            ServiceRequest req = new ServiceRequest(
                uri,
                HttpVerbs.POST
            );

            AuthCredentials creds = new AuthCredentials();
            creds.auth.APICredentials.username = username;
            creds.auth.APICredentials.apiKey = apikey;

            req.CreateRequest(creds);

            try
            {
                string cloudAuthResponse = req.GetResponseBody();
                CloudAuthResponse authResponse = JsonConvert.DeserializeObject<CloudAuthResponse>(cloudAuthResponse);
                return authResponse.access.token.id;
            }
            catch (System.Exception ex)
            {
               
            }
            finally
            {
                req.WebRequest.Abort();
                req = null;
            }
            return string.Empty;
        }
    }
}
namespace Karma.CloudAPI.Identity.Response
{
    
        public class Endpoint
        {
            public string internalURL { get; set; }
            public string publicURL { get; set; }
            public string region { get; set; }
            public string tenantId { get; set; }
            public string versionId { get; set; }
            public string versionInfo { get; set; }
            public string versionList { get; set; }
        }

        public class ServiceCatalog
        {
            public List<Endpoint> endpoints { get; set; }
            public string name { get; set; }
            public string type { get; set; }
        }

        public class Tenant
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Token
        {
            public string expires { get; set; }
            public string id { get; set; }
            public Tenant tenant { get; set; }
        }

        public class Role
        {
            public string description { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public string name { get; set; }
            public List<Role> roles { get; set; }

            [Newtonsoft.Json.JsonProperty("RAX-AUTH:defaultregion")]
            public string DefaultRegion { get; set; }
        }

        public class Access
        {
            public List<ServiceCatalog> serviceCatalog { get; set; }
            public Token token { get; set; }
            public User user { get; set; }
        }

        public class CloudAuthResponse
        {
            public Access access { get; set; }
        }
    
}