using ITS.Data.Dto;

namespace ITS.Model.RPC
{
    public interface IRpcServiceProject
    {
        string CreateProject(ProjectDto data);
    }
}