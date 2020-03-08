using System;
using System.Collections.Generic;
using System.Text;

namespace MakeApiCalls.Models
{
    public interface iApiInfo
    {
        string Address { get; }
        string HttpHttps { get; }
        string Port { get; }
        string Endpoint { get; }
        string QueryString { get; }

    }
}
