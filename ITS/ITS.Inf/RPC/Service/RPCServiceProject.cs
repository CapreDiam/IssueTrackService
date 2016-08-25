using ITS.Data.Dto;
using ITS.Model.RPC;
using NLog;

namespace ITS.Inf.RPC.Service
{
    public class RpcServiceProject:IRpcServiceProject
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        public string CreateProject(ProjectDto data)
        {
            _log.Info("create project");
            return "200";
        }
    }
}