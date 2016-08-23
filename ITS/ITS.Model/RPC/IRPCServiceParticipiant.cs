

using ITS.Data.Dto;

namespace ITS.Model.RPC
{
    public interface IRPCServiceParticipiant
    {
        string addParticipiantToProject(ParticipiantDto data, int idProject);


        string addParticipiant(ParticipiantDto data);
    }
}