using ITS.Data.Dto;

namespace ITS.Model.RPC
{
    public interface IRpcServiceIssues
    {
       
        string AddVersionToProject(IssueDto version, int projectId);
        string CreateIssue(IssueDto data);
        string ChangeStatusIssue(IssueDto status, int projectId);


    }
}