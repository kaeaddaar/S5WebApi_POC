using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using MakeApiCalls.Models;


namespace MakeApiCalls
{
    public class APITools
    {
        public void APICall(ApiInfo info, ref dynamic r, ref string Result)
        {
            try
            {
                string target = info.GetTarget();
                Console.WriteLine("target: " + target);
                var client = new RestClient(target);
                client.Authenticator = new HttpBasicAuthenticator("WEBAPI", "9dKqkZcvr44paCtR");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                Result = response.Content;

                r = JsonConvert.DeserializeObject<dynamic>(Result);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error In APICallComponent.APICall - {e.Message}");
            }

        }

    }
}
