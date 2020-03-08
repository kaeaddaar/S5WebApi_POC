using System;
using System.Collections.Generic;
using System.Text;

namespace MakeApiCalls.Models
{
    public class ApiInfo : iApiInfo
    {
        public string Address { get; }
        public string HttpHttps { get; }
        public string Port { get; }
        public string Endpoint { get; }
        public string QueryString { get; }

        public ApiInfo ShallowCopy()
        {
            return (ApiInfo)this.MemberwiseClone();
        }

        public ApiInfo(string address, string httpHttps, string port, string endpoint, string queryString)
        {
            Address = address;
            HttpHttps = httpHttps;
            Port = port;
            Endpoint = endpoint;
            QueryString = queryString;
        }

        public string GetTarget()
        {
            if (Address == string.Empty) { throw new ArgumentException($"Address field is required, Cannot Be Empty"); }
            if (HttpHttps == string.Empty) { throw new ArgumentException($"HttpHttps field is required, Cannot Be Empty"); }
            if (Port == string.Empty) { throw new ArgumentException($"Port field is required, Cannot Be Empty"); }
            if (Endpoint == string.Empty) { throw new ArgumentException($"Endpoint field is required, Cannot Be Empty"); }
            //if (QueryString == string.Empty) { throw new ArgumentException($"QueryString field is required, Cannot Be Empty"); }

            string QuerystringMark = string.Empty;
            if (QueryString != string.Empty) { QuerystringMark = "?"; }
            string addr = string.Empty;
            addr = $"{HttpHttps}://{Address}:{Port}/{Endpoint}{QuerystringMark}{QueryString}";
            return addr;
        }
        //"http://184.70.255.10:2121/Windward/WebAPI/Inventory/Inventory/0?Fields=InventoryId&eCommerceExport=Y&PageSize=0&PageNumber=0"
    }

}
