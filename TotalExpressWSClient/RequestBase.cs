using System.IO;
using System.Net;
using System.Xml;

namespace TotalExpressWSClient
{
    public abstract class RequestBase
    {
        protected XmlDocument MakeRequest(string username,
                                          string password,
                                          string url,
                                          string soapAction,
                                          XmlDocument xmlRequest)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Credentials = new NetworkCredential(username, password);
            request.Headers.Add("SOAPAction", soapAction);
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string responseString = null;

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            var xmlResponse = new XmlDocument();
            xmlResponse.LoadXml(responseString);

            return xmlResponse;
        }
    }
}
