using System;
using ITS.Data.Dto;
using ITS.Model.Event;
using ITS.Model.RPC;
using Nancy.Json;
using Newtonsoft.Json;

namespace ITS.Inf.RPC
{
    public class RPCListener:IListener
    {
        private IRPCClient _rpcClient = new RPCClient();

        public void callback(string msg)
        {
            Console.WriteLine(msg);
            try
            {
                var _event = JsonConvert.DeserializeObject<ITSEvent>(msg);
                _rpcClient.call(_event);
            }
            catch (Exception exception)
            {
                throw;
            }
        }


    }
}