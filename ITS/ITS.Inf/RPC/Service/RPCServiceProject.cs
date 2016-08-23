using ITS.Data.Dto;
using ITS.Model.RPC;
using NLog;

namespace ITS.Inf.RPC.Service
{
    public class RPCServiceProject:IRPCServiceProject
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        public string createProject(ProjectDTO data)
        {
            Log.Info("create project");
            return "200";
        }
    }
}