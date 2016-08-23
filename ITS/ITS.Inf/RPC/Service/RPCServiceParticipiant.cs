
using ITS.Data.Dto;
using ITS.Model.RPC;

namespace ITS.Inf.RPC.Service
{
    public class RPCServiceParticipiant:IRPCServiceParticipiant
    {
       

        public string addParticipiantToProject(ParticipiantDto data, int idProject)
        {
            return "200";
        }

        public string addParticipiant(ParticipiantDto data)
        {
            return "200";
        }
    }
}