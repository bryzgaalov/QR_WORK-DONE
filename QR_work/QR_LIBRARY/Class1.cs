using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace QR_LIBRARY
{
    public class QR
    {
        public static string website { get; set; }= "http://qrcoder.ru";

         public static  bool genQR(string text,int size,out string message,out byte[] result)
        {
            string query = string.Format("code/?{0}&{1}&0", text, size);
            var client = new RestClient(website);

            var request = new RestRequest(query);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                message = response.Content;
                result = null;
                return false;
            }
            else
            {
                message = response.Content;
                result = response.RawBytes;
                return true;
            }

        }
    }
}
