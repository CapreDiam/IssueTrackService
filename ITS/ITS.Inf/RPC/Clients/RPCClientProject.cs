using System;
using ITS.Data.Dto;
using ITS.Inf.RPC.Service;
using ITS.Model.RPC;
using Newtonsoft.Json.Linq;

namespace ITS.Inf.RPC.Clients
{
    public class RPCClientProject:RPCBase
    {

        private readonly IRPCServiceProject _rpcServiceProject = new RPCServiceProject();

        public override string Call(ITSEvent message)
        {
            Console.WriteLine(message);

            string result;

            var _data = getDto<ProjectDTO>((JObject)message.Data);

            result = _rpcServiceProject.createProject(_data);
            return result;
        }
    }
}