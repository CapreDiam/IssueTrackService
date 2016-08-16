using System;
using ITS.Data.Dto;
using ITS.Data.Enum.Issue;
using ITS.Model.RPC;

namespace ITS.Inf.RPC
{
    public class RPCClient:IRPCClient
    {

        private readonly IRPCService _rpcService = new RPCService();

        public string call(ITSEvent message)
        {
            Console.WriteLine(message);

            

            //todo make mapping
            string result;

            var type = message.Type;
            
            switch (type)
            {
                case ITSTypeMessage.CREATE_PROJECT:
                {
                    result = _rpcService.createProject(message.ToString());
                    break;
                }
                case ITSTypeMessage.ADD_VERSION_TO_PROJECT:
                {
                    result = _rpcService.addVersionToProject(message.ToString(), 1);
                    break;
                }
                case ITSTypeMessage.ADD_PARTICIPIANT_TO_PROJECT:
                {
                    result = _rpcService.addParticipiantToProject(message.ToString());
                    break;
                }
                case ITSTypeMessage.CREATE_ISSUE:
                {
                    result = _rpcService.createIssue(message.ToString());
                    break;
                }
                case ITSTypeMessage.CHANGE_STATUS_ISSUE:
                {
                    result = _rpcService.changeStatusIssue(message.ToString(), 45);
                    break;
                }
                case ITSTypeMessage.ADD_PARTICIPIANT:
                {
                    result = _rpcService.addParticipiant(message.ToString());
                    break;
                }
                default:
                {
                    result = "ERROR";
                   break; 
                }
            }
            return result;
        }
    }
}