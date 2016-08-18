using System;
using System.Runtime.Remoting.Messaging;
using ITS.Data.Dto;
using ITS.Data.Enum.Issue;
using ITS.Inf.AMPQ.Messenger;
using ITS.Model.RPC;
using Newtonsoft.Json.Linq;

namespace ITS.Inf.RPC
{
    public class RPCClient:IRPCClient
    {

        private readonly IRPCService _rpcService = new RPCService();
        private readonly IMessenger _message = new Messenger();

        public string call(ITSEvent message)
        {
            Console.WriteLine(message);

            

            //todo make mapping
            string result;

            var type = message.Type;
            var _data = (JObject) message.Data;
            
            switch (type)
            {
                case ITSTypeMessage.CREATE_PROJECT:
                {
                    var _project = getDto<ProjectDTO>(_data);
                    result = _rpcService.createProject(_project);
                    break;
                }
                case ITSTypeMessage.ADD_VERSION_TO_PROJECT:
                {
                    var _issue = getDto<IssueDto>(_data);
                    result = _rpcService.addVersionToProject(_issue, 1);
                    break;
                }
                case ITSTypeMessage.ADD_PARTICIPIANT_TO_PROJECT:
                {
                    var _participiant = getDto<ParticipiantDto>(_data);
                    result = _rpcService.addParticipiantToProject(_participiant, 23);
                    break;
                }
                case ITSTypeMessage.CREATE_ISSUE:
                {
                    var _issue = getDto<IssueDto>(_data);
                    result = _rpcService.createIssue(_issue);
                    break;
                }
                case ITSTypeMessage.CHANGE_STATUS_ISSUE:
                {
                    var _issue = getDto<IssueDto>(_data);
                    result = _rpcService.changeStatusIssue(_issue, 45);
                    break;
                }
                case ITSTypeMessage.ADD_PARTICIPIANT:
                {
                    var _participiant = getDto<ParticipiantDto>(_data);
                    result = _rpcService.addParticipiant(_participiant);
                    break;
                }
                default:
                {
                    result = "{\"ERROR\":200}";
                   break; 
                }
            }
            

            sendResult(result, message.CorelationId.ToString());
            return result;
        }

        public void sendResult(string result, string corellationID)
        {
            _message.sendRPCRequest(result, corellationID);
        }

        private T getDto<T>(JObject o)
        {
            try
            {
                return o.ToObject<T>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                //todo send error
            }
            return default(T);
        }
    }
}