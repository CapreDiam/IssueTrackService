using ITS.Data.Dto;
using ITS.Model.RPC;
using NLog;

namespace ITS.Inf.RPC.Service
{
    public class RpcServiceIssue:IRPCServiceIssue
    {

        private static Logger Log = LogManager.GetCurrentClassLogger();

        public string addVersionToProject(IssueDto version, int projectId)
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

    }
}