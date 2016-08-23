using ITS.Data.Dto;

namespace ITS.Model.RPC
{
    public interface IRPCServiceProject
    {
        string createProject(ProjectDTO data);
    }
}