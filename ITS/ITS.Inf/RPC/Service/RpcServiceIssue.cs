using ITS.Data.Dto;
using ITS.Model.RPC;
using NLog;

namespace ITS.Inf.RPC.Service
{
    public class RpcServiceIssue:IRpcServiceIssues
    {

        private static Logger _log = LogManager.GetCurrentClassLogger();

        public string AddVersionToProject(IssueDto version, int projectId)
        {
            //todo something
            return "200";
        }

        public string CreateIssue(IssueDto data)
        {
            //todo something
            return "200";
        }

        public string ChangeStatusIssue(IssueDto status, int projectId)
        {
            //todo something
            return "200";
        }

    }
}