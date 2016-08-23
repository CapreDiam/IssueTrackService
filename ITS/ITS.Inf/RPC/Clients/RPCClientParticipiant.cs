using System;
using ITS.Data.Dto;
using ITS.Inf.AMPQ.Messenger;
using ITS.Inf.RPC.Service;
using ITS.Model.RPC;
using Newtonsoft.Json.Linq;

namespace ITS.Inf.RPC.Clients
{
    public class RPCClientParticipiant:RPCBase
    {
        private readonly IRPCServiceParticipiant _irpcServiceParticipiant = new RPCServiceParticipiant();

        public override string Call(ITSEvent message)
        {
            Console.WriteLine(message);

            string result;

            var _data = getDto<ParticipiantDto>((JObject)message.Data);


            result = _irpcServiceParticipiant.addParticipiant(_data); 
            //    break;

            return result;
        }
    }
}