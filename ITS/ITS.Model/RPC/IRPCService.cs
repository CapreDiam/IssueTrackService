using System;

namespace ITS.Model.RPC
{
    public interface IRPCService
    {
        string createProject(String data);
        string addVersionToProject(String version, int projectId);
        string addParticipiantToProject(String data);
        string createIssue(String data);
        string changeStatusIssue(String status, int projectId);
        string addParticipiant(String data);

    }
}