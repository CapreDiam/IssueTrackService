using System;
using ITS.Data.Dto;
using ITS.Inf.AMPQ.Messenger;
using ITS.Model.RPC;
using Newtonsoft.Json.Linq;

namespace ITS.Inf.RPC
{
    public abstract class RpcBase:IRpcClient
    {

        private readonly IMessenger _message = new Messenger();


        public abstract string Call(ItsEvent message);

        public void SendResult(string result, string corellationId)
        {

            _message.SendRpcRequest(result, corellationId);
        }

        protected T GetDto<T>(JObject o)
        {
            Console.WriteLine(typeof(T));

            try
            {
                return o.ToObject<T>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                //todo send error
            }
            return default(T);
        }
    }
}