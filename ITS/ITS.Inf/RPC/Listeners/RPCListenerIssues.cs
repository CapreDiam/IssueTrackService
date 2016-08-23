using System;
using ITS.Data.Dto;
using ITS.Model.Event;
using ITS.Model.RPC;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ITS.Inf.RPC.Listeners
{
    public class RPCListenerIssues:IListener
    {
        private RPCBase _rpcClient = new RPCClientIssues();

        public void callback(string msg)
        {
            Console.WriteLine(msg);
            try
            {
                var _event = JsonConvert.DeserializeObject<ITSEvent>(msg);
                _event.Data = ((JObject) _event.Data).ToObject<IssueDto>();
                
                _rpcClient.Call(_event);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }


    }
}