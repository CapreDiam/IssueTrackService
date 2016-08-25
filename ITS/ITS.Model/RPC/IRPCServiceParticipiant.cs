using ITS.Data.Dto;

namespace ITS.Model.RPC
{
    public interface IRpcServiceParticipiant
    {
        string AddParticipiantToProject(ParticipiantDto data, int idProject);


        string AddParticipiant(ParticipiantDto data);
    }
}