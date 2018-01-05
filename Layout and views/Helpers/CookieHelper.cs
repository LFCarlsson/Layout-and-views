using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Layout_and_views.Helpers
{
    public static class CookieHelper
    {
        public static bool CookieExists(HttpCookie cookie)
        {
            return cookie != null;
        }

        public static string Serialize(object o)
        {
            try
            {
                return new JavaScriptSerializer().Serialize(o);
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public static T Deserialize<T>(string s)
        {
            try
            {
                return new JavaScriptSerializer().Deserialize<T>(s);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        public static void WriteCookie(HttpCookie responseCookie, string key, object data, DateTime expire)
        {
            responseCookie[key] = Serialize(data);
            responseCookie.Expires = expire;
        }

        public static T ReadCookie<T>(HttpCookie requestCookie, string key)
        {
            if (CookieExists(requestCookie))
            {
                return Deserialize<T>(requestCookie[key]);
            }
            else
            {
                return default(T);
            }
        }
    }
}