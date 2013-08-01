using CloudQueueing.Messages;
using Karma.CloudAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudQueueing
{
    public class ClaimMessageBody
    {
        public int ttl { get { return 500; } }
        public int grace { get { return 500; } }
    }
    
    public class CQClient
    {
        public string CQBaseUrl = "https://preview.queue.api.rackspacecloud.com:443/v1";
        public string AuthToken = KarmaUtil.KarmaGlobal.IdentityAuthToken;

        public bool CreateQueue(string queueName)
        {
            Uri uri = new Uri(String.Format("{0}/queues/{1}", CQBaseUrl,queueName));

            ServiceRequest req = new ServiceRequest(
                uri,
                HttpVerbs.PUT
            );

            //Create the request
            req.HttpCustomHeaders.Add("X-Auth-Token", AuthToken);
            req.CreateRequest();
            req.IgnoreSSLCertificateErrors = true;

            try
            {
                string response = req.MakeRequest<string>();
                if (req.HttpStatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                req.WebRequest.Abort();
            }
            

            return false;
        }

        public bool PostMessage(string queueName, Object message)
        {
            Uri uri = new Uri(String.Format("{0}/queues/{1}/messages", CQBaseUrl, queueName));

            ServiceRequest req = new ServiceRequest(
                uri,
                HttpVerbs.POST
            );


            //Create the request
            req.HttpCustomHeaders.Add("X-Auth-Token", AuthToken);               
            req.IgnoreSSLCertificateErrors = true;

            req.CreateRequest(message);

            try
            {
                string response = req.MakeRequest<string>();
                if (req.HttpStatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                req.WebRequest.Abort();
            }


            return false;

        }

        public List<QueueMessage> ClaimMessages(string queueName)
        {
            Uri uri = new Uri(String.Format("{0}/queues/{1}/claims", CQBaseUrl, queueName));

            ServiceRequest req = new ServiceRequest(
                uri,
                HttpVerbs.POST
            );


            //Create the request
            req.HttpCustomHeaders.Add("X-Auth-Token", AuthToken);
            req.IgnoreSSLCertificateErrors = true;

            ClaimMessageBody cmBody = new ClaimMessageBody();
            req.CreateRequest(cmBody);

            try
            {
                //List<QueueMessage> lstMessages = new List<QueueMessage>();

                List<QueueMessage> lstMessages = req.MakeRequest<List<QueueMessage>>();

                if (req.HttpStatusCode == HttpStatusCode.OK)
                {
                    return lstMessages;
                }
            }
            catch (System.Exception ex)
            {
                req.WebRequest.Abort();
            }


            return null;
        }

        public void DeleteMessage()
        { 
        }

    }
}
