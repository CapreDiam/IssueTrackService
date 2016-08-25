using System;
using ITS.Data.Dto;
using ITS.Inf.RPC.Service;
using ITS.Model.RPC;
using Newtonsoft.Json.Linq;

namespace ITS.Inf.RPC.Clients
{
    public class RpcClientProject:RpcBase
    {

        private readonly IRpcServiceProject _rpcServiceProject = new RpcServiceProject();

        public override string Call(ItsEvent message)
        {
            Console.WriteLine(message);

            string result;

            var data = GetDto<ProjectDto>((JObject)message.Data);

            result = _rpcServiceProject.CreateProject(data);
            return result;
        }
    }
}