using System;
using ITS.Data.Dto;
using ITS.Model.Event;
using ITS.Model.RPC;
using Nancy.Json;

namespace ITS.Inf.RPC
{
    public class RPCListener:IListener
    {
        private IRPCClient _rpcClient = new RPCClient();

        public void callback(string msg)
        {
            Console.WriteLine(msg);
            JavaScriptSerializer request = new JavaScriptSerializer();
            ITSEvent _event =
                (ITSEvent)request.DeserializeObject(
                    msg);
            var result = _rpcClient.call(_event);
        }
    }
}