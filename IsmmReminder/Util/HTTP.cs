using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IsmmReminder.Util
{
    public class HTTP
    {
        public Dictionary<string, string> Cookies = null;

        public string Request(string url)
        {
            string html = string.Empty;
            Uri uri = new Uri(url);

            CookieContainer cookieContainer = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            if (Cookies != null)
            {
                cookieContainer = new CookieContainer();
                foreach(var cookie in Cookies)
                {
                    cookieContainer.Add(uri, new Cookie(cookie.Key, cookie.Value));
                }
                
                request.CookieContainer = cookieContainer;
            }


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }
    }
}
