using System;
using ITS.Data.Dto;
using ITS.Inf.RPC.Clients;
using ITS.Model.Event;
using ITS.Model.RPC;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

namespace ITS.Inf.RPC.Listeners
{
    public class RpcListenerIssues:IListener
    {
        private readonly RpcBase _rpcClient = new RpcClientIssues();
        private static Logger _log = LogManager.GetCurrentClassLogger();

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