using System;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace Karma.CloudAPI
{
    public enum HttpVerbs
    {
        GET,
        DELETE,
        POST,
        PUT,
        HEAD
    }

    public class ServiceRequest
    {
        private string _UserAgent;
        /// <summary>
        /// UserAgent used in HTTP Request
        /// </summary>
        public String UserAgent
        {
            get { return _UserAgent; }
        }
        public HttpVerbs RequestVerb { get; private set; }
        public string RequestBody { get; set; }


        /// <summary>
        /// Http Request Timeout (15 second default)
        /// </summary>
        public int Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }

        private int _Timeout = (120 * 1000); 

        /// <summary>
        /// Http Request Headers
        /// </summary>
        public NameValueCollection HttpCustomHeaders { get; private set; }


        /// <summary>
        /// Http Request Content Type
        /// </summary>
        public String HttpRequestContentType
        {
            get { return _HttpRequestContentType; }
            set { _HttpRequestContentType = value; }
        }
        private String _HttpRequestContentType = "application/json; charset=utf-8";

        public Uri ServiceUri { get; private set; }

        public bool IgnoreSSLCertificateErrors {get;set;}
        

        /// <summary>
        /// Response Http Status Code
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; private set; }

        public string HttpStatusDescription { get; private set; }

        public string ErrorResponseBody { get; set; }

        public HttpWebRequest WebRequest { get; private set; }


        public ServiceRequest(Uri serviceUri, HttpVerbs requestVerb) : this(serviceUri, requestVerb, null) 
        {
            this._UserAgent = "Karma";
            this.IgnoreSSLCertificateErrors = true;
        }
        public ServiceRequest(Uri serviceUri, HttpVerbs requestVerb, NameValueCollection httpCustomHeaders)
        {
            this._UserAgent = "Karma";
            this.ServiceUri = serviceUri;
            this.RequestVerb = requestVerb;
            this.HttpCustomHeaders = (httpCustomHeaders == null) ? new NameValueCollection() : httpCustomHeaders;
            this.IgnoreSSLCertificateErrors = true;
        }

        /// <summary>
        /// Instantiate Service Request object. WARNING:  This override of the constructor should only be used in Unit Testing as it overrides the default value for UserAgent
        /// </summary>
        public ServiceRequest(Uri serviceUri, HttpVerbs requestVerb, NameValueCollection httpCustomHeaders, string userAgent)
        {
            this._UserAgent = userAgent;
            this.ServiceUri = serviceUri;
            this.RequestVerb = requestVerb;
            this.HttpCustomHeaders = (httpCustomHeaders == null) ? new NameValueCollection() : httpCustomHeaders;
            this.IgnoreSSLCertificateErrors = true;
        }


        public void CreateRequest()
        {
            CreateRequest(null);
        }
        
		public void CreateRequest(Object viewModel)
        {
            // Serialize ViewModel to JSON
            string serviceRequestUrl = this.ServiceUri.AbsoluteUri;
            RequestBody = string.Empty;

            if (viewModel != null)
            {
                RequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(viewModel);

                // For GET and DELETE Add JSON to Querystring
                if (this.RequestVerb == HttpVerbs.GET || this.RequestVerb == HttpVerbs.DELETE)
                {
                    string QueryStringPrefix = String.IsNullOrEmpty(this.ServiceUri.Query) ? "?" : this.ServiceUri.Query;
                    serviceRequestUrl += QueryStringPrefix + RequestBody;
                }
            }

            //To ignore certificate issues
           // ServicePointManager.ServerCertificateValidationCallback = delegate{return this.IgnoreSSLCertificateErrors;};

            HttpWebRequest webRequest = HttpWebRequest.Create(serviceRequestUrl) as HttpWebRequest;

            webRequest.UserAgent = this.UserAgent;
            webRequest.KeepAlive = false;					// default is true
            webRequest.AllowWriteStreamBuffering = false;	// was true -- default is true
            webRequest.SendChunked = false;					// was true -- default is false
            webRequest.ContentLength = 0;					// Default to 0.

            // Set timeout to 15 seconds
            webRequest.Timeout = this.Timeout;

            // Set the content type
            webRequest.ContentType = this.HttpRequestContentType;

            // Set Request Method (GET, POST, DELETE, PUT)
            webRequest.Method = this.RequestVerb.ToString();

            // Add Custom Headers to Request Headers
            webRequest.Headers.Add(this.HttpCustomHeaders);
            webRequest.Headers.Add("Client-ID", "Karma");
            

            this.WebRequest = webRequest;
        }

        /// <summary>
        /// Make a Request (Please call CreateRequest() before making this call)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MakeRequest<T>()
        {
            StringBuilder sbResponse;
            T responseViewModel = default(T);

            try
            {
                this.IgnoreSSLCertificateErrors = true;

                //To ignore certificate issues
              //  ServicePointManager.ServerCertificateValidationCallback = delegate { return this.IgnoreSSLCertificateErrors; };

                // For POST and PUT Add Json to Request Body
                if (this.RequestVerb == HttpVerbs.POST || this.RequestVerb == HttpVerbs.PUT)
                {
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                    // Convert string (which is UTF-16) to UTF-8 Byte Array
                    byte[] JsonBytes = UTF8.GetBytes(RequestBody);

                    this.WebRequest.ContentLength = JsonBytes.Length;

                    // Write UTF8 Body to HTTP stream
                    using (var binaryWriter = new BinaryWriter(this.WebRequest.GetRequestStream(), Encoding.UTF8))
                    {
                        // BinaryWriter is required for a UTF8 Byte Array
                        binaryWriter.Write(JsonBytes);
                        binaryWriter.Flush();
                        binaryWriter.Close();
                        binaryWriter.Dispose();
                    }
                }
                else
                {
                    // Set content length for GET & DELETE Requests to -1
                    this.WebRequest.ContentLength = 0;
                }



                // GET HTTP Response
                using (HttpWebResponse response = this.WebRequest.GetResponse() as HttpWebResponse)
                {
                    this.HttpStatusCode = response.StatusCode;

                    //NonAuthoritativeInformation is 203, which Clouservers API send is sometimes. 203 is almost similar to 200.
                    if (response != null && (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NonAuthoritativeInformation))
                    {
                        // this.HttpStatusCode = response.StatusCode;

                        // GET HTTP Response Stream
                        using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                        {
                            // Read Response to StringBuilder
                            sbResponse = new StringBuilder(streamReader.ReadToEnd());

                            if (sbResponse.Length > 0)
                            {
                                try
                                {
                                    responseViewModel = JsonConvert.DeserializeObject<T>(sbResponse.ToString());
                                }
                                catch (System.Exception ex)
                                {
                                    
                                }
                            }
                        }
                    }

                    response.Close();
                }

                this.WebRequest.Abort();

            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    this.HttpStatusCode = ((HttpWebResponse)ex.Response).StatusCode;
                    this.HttpStatusDescription = ((HttpWebResponse)ex.Response).StatusDescription;
                }

                this.WebRequest.Abort();
            }
            finally
            {
                this.WebRequest.Abort();
            }
                        

            return (responseViewModel); 

        }


        /// <summary>        
        /// Gets the response body from a Web Request
        /// Will be useful in situations where automatic deserialization is not possible
        /// </summary>
        /// <returns></returns>
        public string GetResponseBody()
        {
            StringBuilder sbResponse = new StringBuilder(string.Empty);
            try
            {                
                if (this.RequestVerb == HttpVerbs.POST || this.RequestVerb == HttpVerbs.PUT)
                {
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                    // Convert string (which is UTF-16) to UTF-8 Byte Array
                    byte[] RequestBytes = UTF8.GetBytes(RequestBody);

                    this.WebRequest.ContentLength = RequestBytes.Length;

                    // Write UTF8 Body to HTTP stream
                    using (var binaryWriter = new BinaryWriter(this.WebRequest.GetRequestStream(), Encoding.UTF8))
                    {
                        // BinaryWriter is required for a UTF8 Byte Array
                        binaryWriter.Write(RequestBytes);
                        binaryWriter.Flush();
                        binaryWriter.Close();
                    }
                }
                else
                {
                    // Set content length for GET & DELETE Requests to -1
                    this.WebRequest.ContentLength = 0;
                }

                // GET HTTP Response
                using (HttpWebResponse response = this.WebRequest.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                            this.HttpStatusCode = response.StatusCode;
                            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                            {
                                // Read Response to StringBuilder
                                sbResponse = new StringBuilder(streamReader.ReadToEnd());
                                return sbResponse.ToString();
                            }
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    this.HttpStatusCode = ((HttpWebResponse)ex.Response).StatusCode;
                    this.HttpStatusDescription = ((HttpWebResponse)ex.Response).StatusDescription;

                    // Try to make available any useful response we might receive
                    try
                    {
                        using (StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8))
                        {
                            sbResponse = new StringBuilder(streamReader.ReadToEnd());
                            this.ErrorResponseBody = sbResponse.ToString();
                        }
                    }
                    catch (System.Exception) { }
                }

            }

            return (sbResponse.ToString());

        }

        /// <summary>
        /// GET the Response Headers from a Request  (Please call CreateRequest() before making this call)
        /// </summary>
        /// <returns></returns>
        public WebHeaderCollection GetResponseHeaders()
        {
            try
            {
                // GET HTTP Response
                using (HttpWebResponse response = this.WebRequest.GetResponse() as HttpWebResponse)
                {
                    // return the HTTP Response Stream
                    return response.Headers;
                }
            }
            catch (System.Net.WebException webEx)
            {
                if (((HttpWebResponse)webEx.Response).StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                }
            }
            catch (System.Exception ex)
            {
            }

            return null;
        }


      
    }
}