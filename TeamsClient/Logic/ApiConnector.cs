using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Connector;

namespace Logic
{
    public static class ApiConnector
    {
        public static void Connect()
        {
            Connector.InitializeClient();
        }
    }
}
