
using ITS.Data.Dto;
using ITS.Model.RPC;

namespace ITS.Inf.RPC.Service
{
    public class RpcServiceParticipiant:IRpcServiceParticipiant
    {
       

        public string AddParticipiantToProject(ParticipiantDto data, int idProject)
        {
            return "200";
        }

        public string AddParticipiant(ParticipiantDto data)
        {
            return "200";
        }
    }
}