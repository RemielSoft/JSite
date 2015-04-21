using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePayment
{
    public static class PaymentGen
    {
        public static List<string> payment
        {
            get 
            { 
                return Get<List<string>>("payments");
            }
            set
            {
                Set<List<string>>("payments", value); 
            }
        }

        /// <summary> Gets. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <returns> . </returns>
        private static T Get<T>(string key)
        {
            object o = HttpContext.Current.Session[key];
            if (o is T)
            {
                return (T)o;
            }
            return default(T);
        }

        /// <summary> Sets. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="key">  The key. </param>
        /// <param name="item"> The item. </param>
        private static void Set<T>(string key, T item)
        {
            HttpContext.Current.Session[key] = item;
        }
    }
}