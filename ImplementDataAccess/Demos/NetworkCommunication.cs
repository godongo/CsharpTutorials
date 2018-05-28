using System;
using System.IO;
using System.Net;

namespace ImplementDataAccess.Demos
{
    class NetworkCommunication
    {
        internal static void SimpleWebRequest()
        {
            // Create method inspects the address that you pass to it and then selects the correct protocol
            // implementation
            /* If you would pass the address http://www.microsoft.com to it, it would see
               that you are working with the HTTP protocol and it would return an HttpWebRequest.*/

            WebRequest request = WebRequest.Create(@"http://www.microsoft.com");

            WebResponse response = request.GetResponse();

            StreamReader responseStream = new StreamReader(response.GetResponseStream());

            string responseText = responseStream.ReadToEnd();

            Console.WriteLine(responseText); // Displays the HTML of the website

            response.Close();
        } 
    }
}
