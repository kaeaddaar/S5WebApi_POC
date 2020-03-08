using MakeApiCalls;
using MakeApiCalls.Models;
using System;
using DataForInventoryReconciliation.NSWAG;
using System.Text;

namespace APBills
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing APBills.Main");

            APITools Tool = new APITools();
            ApiInfo info = new ApiInfo
            (
                "192.168.0.5"
                , "http"
                , "2121"
                , "Windward/WebAPI/APBill/APBills/0"
                , ""
            );

            dynamic dyn = new object();
            string Result = string.Empty;

            try
            {
                Tool.APICall(info, ref dyn, ref Result);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error making API Call - {e.Message} in {e.Source}");
                Console.WriteLine($"API Call Info: {info.GetTarget()}");
            }

            Console.WriteLine(Result);
            Console.WriteLine(string.Empty);
            Console.WriteLine("----- ----- ----- ----- -----");
            Console.WriteLine("Finished displaying API Call Results, press any key to continue.");

            Console.WriteLine("Next: Writting to NSWAG data structure");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Begin Writting to NSWAG data structure");

            string BaseUrl = "http://184.70.255.10:2121/Windward/WebAPI/APBill/";
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();

            var byteArray = Encoding.ASCII.GetBytes("WEBAPI:9dKqkZcvr44paCtR");
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            //DataForInventoryReconciliation.NSWAG.APBillClient aPBillClient = new APBillClient(BaseUrl, httpClient);
            //Rootobject x = aPBillClient.HandshakeAsync().Result;
            //Console.WriteLine(x.result[0].Version);

            //DataForInventoryReconciliation.NSWAG.Client client = 
            //    new DataForInventoryReconciliation.NSWAG.Client(BaseUrl, httpClient);

            DataForInventoryReconciliation.NSWAG.APBillClient aPBillClient =
                new APBillClient(BaseUrl, httpClient);

            object r = aPBillClient.HandshakeAsync().Result;
            Console.WriteLine(r);

            Console.WriteLine("Done handshake, press any key to continue");
            Console.ReadKey();

            DataForInventoryReconciliation.NSWAG.Client client =
                new DataForInventoryReconciliation.NSWAG.Client(BaseUrl, httpClient);

            string number = "0";
            string? fields = null;
            int? pageSize = null;
            int? pageNumber = null;

            APBillsAPIGetResults APBillsResults = client.GetBillsAsync(number, fields, pageSize, pageNumber).Result;
            Console.WriteLine(APBillsResults.APIResponse);

            Console.WriteLine("Done");
            Console.ReadKey();
            Console.Clear();

        }
    }



}
