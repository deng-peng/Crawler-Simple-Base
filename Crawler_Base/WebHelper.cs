using System.IO;
using System.Net;
using System.Text;

namespace Crawler_Base
{
    class WebHelper
    {
        private const int Timeout = 60000;
        private static readonly Encoding _defaultEncoding = Encoding.GetEncoding(936);

        public static string GetPage(string url)
        {
            return GetPage(url, null);
        }

        public static string GetPage(string url, CookieContainer cookieContainer)
        {
            return GetPage(url, cookieContainer, null, null);
        }

        public static string GetPage(string url, CookieContainer cookieContainer, int timeOut)
        {
            return GetPage(url, cookieContainer, null, null, timeOut);
        }

        public static string GetPage(string url, CookieContainer cookieContainer, WebProxy proxy)
        {
            return GetPage(url, cookieContainer, null, proxy);
        }

        public static string GetPage(string url, CookieContainer cookieContainer, int timeOut, Encoding endoing)
        {
            return GetPage(url, cookieContainer, null, null, timeOut, false, endoing);
        }

        public static string GetPage(string url, CookieContainer cookieContainer, string referer, WebProxy proxy)
        {
            return GetPage(url, cookieContainer, referer, proxy, Timeout);
        }

        public static string GetPage(string url, CookieContainer cookieContainer, string referer, WebProxy proxy, int timeOut)
        {
            return GetPage(url, cookieContainer, referer, proxy, Timeout, true);
        }

        public static string GetPage(string url, CookieContainer cookieContainer, string referer, WebProxy proxy, int timeOut, bool neadProxy)
        {
            return GetPage(url, cookieContainer, referer, proxy, timeOut, neadProxy, _defaultEncoding);
        }

        public static string GetPage(string url, CookieContainer cookieContainer, string referer, WebProxy proxy, int timeOut, bool neadProxy, Encoding endoing)
        {
            var responseUrl = "";

            return GetPage(url, cookieContainer, referer, proxy, timeOut, neadProxy, endoing, false, out responseUrl);
        }

        public static string GetPage(string url, CookieContainer cookieContainer, string referer, WebProxy proxy, int timeOut, bool neadProxy, Encoding endoing, bool onlyResponseUrl, out string responseUrl)
        {
            responseUrl = "";

            var tryTimes = 1;
            var content = "";

        Again:

            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;

                if (request == null)
                {
                    return "";
                }

                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "GET";
                request.UserAgent = "User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)"; // "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.2; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.Accept = "text/html, application/xhtml+xml, */*"; // "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.Headers.Add("Accept-Language", "zh-CN");
                request.KeepAlive = true;
                request.Timeout = timeOut;

                request.Proxy = proxy;

                if (!string.IsNullOrEmpty(referer))
                {
                    request.Referer = referer;
                }

                //发送请求并获取相应回应数据 
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (onlyResponseUrl)
                    {
                        responseUrl = response.ResponseUri.OriginalString;
                    }
                    else
                    {
                        using (var instream = response.GetResponseStream())
                        {
                            using (var sr = new StreamReader(instream, endoing, true))
                            {
                                content = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                if (tryTimes > 0)
                {
                    tryTimes--;

                    goto Again;
                }

                throw;
            }

            return content;
        }


        public static string PostPage(string url, string body, CookieContainer cookieContainer, string referer)
        {
            return PostPage(url, body, cookieContainer, referer, null, Timeout, false, _defaultEncoding);
        }

        public static string PostPage(string url, string body, CookieContainer cookieContainer, string referer, Encoding encode)
        {
            return PostPage(url, body, cookieContainer, referer, null, Timeout, false, encode);
        }

        public static string PostPage(string url, string body, CookieContainer cookieContainer, string referer, WebProxy proxy, int timeOut, bool neadProxy, Encoding endoing)
        {
            int tryTimes = 1;
            string content = "";

        Again:

            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;

                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "Post";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.2; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.Accept = "*/*";
                request.Headers.Add("Accept-Language", "zh-cn");
                request.KeepAlive = true;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Pragma", "no-cache");
                request.Timeout = timeOut;

                request.Proxy = proxy;

                if (!string.IsNullOrEmpty(referer))
                {
                    request.Referer = referer;
                }

                byte[] bytesReq = Encoding.UTF8.GetBytes(body);

                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bytesReq, 0, bytesReq.Length);
                }

                //发送请求并获取相应回应数据 
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var instream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(instream, endoing, true))
                        {
                            content = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                if (tryTimes > 0)
                {
                    tryTimes--;
                    goto Again;
                }

                throw;
            }

            return content;
        }

    }

}
