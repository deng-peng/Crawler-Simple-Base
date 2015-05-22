using System;

namespace Crawler_Base
{
    public static class Utils
    {
        public static string GetContent(string dataHtml, string startTag, string endTag)
        {
            if (string.IsNullOrEmpty(dataHtml))
                return "";
            int start = dataHtml.IndexOf(startTag) + startTag.Length;
            if (start < startTag.Length)
                return "";

            int end = dataHtml.IndexOf(endTag, start);
            if (end < start)
                return "";
            return dataHtml.Substring(start, end - start);
        }
        public static string GetContent(string dataHtml, string startTag)
        {
            if (string.IsNullOrEmpty(dataHtml))
                return "";
            int start = dataHtml.IndexOf(startTag) + startTag.Length;
            if (start < 0)
                return "";

            return dataHtml.Substring(start);
        }

        public static string GetJsTimestamp()
        {
            var t = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            return t.ToString();
        }
    }
}
