using System;
using ITS.Data.Dto;
using ITS.Data.Enum.Issue;

namespace ITS.Model.RPC
{
    public interface IRPCService
    {
        string createProject(ProjectDTO data);
        string addVersionToProject(IssueDto version, int projectId);
        string addParticipiantToProject(ParticipiantDto data, int idProject);
        string createIssue(IssueDto data);
        string changeStatusIssue(IssueDto status, int projectId);
        string addParticipiant(ParticipiantDto data);

    }
}