using System;
using ITS.Data.Dto;
using ITS.Inf.RPC.Clients;
using ITS.Model.Event;
using Newtonsoft.Json;
using NLog;

namespace ITS.Inf.RPC.Listeners
{
    public class RpcListenerProject:IListener
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        private readonly RpcBase _rpcClient = new RpcClientProject();

        public void Callback(string msg)
        {
            Console.WriteLine(msg);
            try
            {
                var _event = JsonConvert.DeserializeObject<ItsEvent>(msg);
                _rpcClient.Call(_event);
            }
            catch (Exception exception)
            {
                _log.Error(exception);
                Console.WriteLine(exception.ToString());
            }
        }
    }
}