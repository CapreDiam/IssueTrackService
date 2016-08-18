using ITS.Data.Dto;
using ITS.Data.Enum.Issue;

namespace ITS.Model.RPC
{
    public class RPCService:IRPCService
    {
       
        public string createProject(ProjectDTO data)
        {
            //todo something
            return "200";
        }

        public string addVersionToProject(IssueDto version, int projectId)
        {
            //todo something
            return "200";
        }

        public string addParticipiantToProject(ParticipiantDto data, int idProject)
        {
            //todo something
            return "200";
        }

        public string createIssue(IssueDto data)
        {
            //todo something
            return "200";
        }

        public string changeStatusIssue(IssueDto status, int projectId)
        {
            //todo something
            return "200";
        }

        public string addParticipiant(ParticipiantDto data)
        {
            //todo something
            return "200";
        }
    }
}