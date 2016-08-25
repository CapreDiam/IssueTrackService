using System;
using ITS.Data.Dto;

using ITS.Inf.RPC.Service;
using ITS.Model.RPC;
using Newtonsoft.Json.Linq;

namespace ITS.Inf.RPC.Clients
{
    public class RpcClientParticipiant:RpcBase
    {
        private readonly IRpcServiceParticipiant _irpcServiceParticipiant = new RpcServiceParticipiant();

        public override string Call(ItsEvent message)
        {
            Console.WriteLine(message);

            var data = GetDto<ParticipiantDto>((JObject)message.Data);
            data.Validate();

            
            var result = _irpcServiceParticipiant.AddParticipiant(data); 
            return result;
        }
    }
}