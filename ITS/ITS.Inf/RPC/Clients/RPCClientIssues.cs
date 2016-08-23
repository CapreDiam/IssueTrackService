using System;
using ITS.Data.Dto;
using ITS.Inf.AMPQ.Messenger;
using ITS.Inf.RPC.Service;
using ITS.Model.RPC;
using Newtonsoft.Json.Linq;

namespace ITS.Inf.RPC.Clients
{
    public class RPCClientIssues:RPCBase
    {

        private readonly IRPCServiceIssue _irpcServiceIssue = new RpcServiceIssue();
        private readonly IMessenger _message = new Messenger();

        public override string Call(ITSEvent message)
        {
            Console.WriteLine(message);

            string result;

            var _data = getDto<IssueDto>((JObject) message.Data);
            
            
                    result = _irpcServiceIssue.createIssue(_data);
                //    break;
               
                //case ITSTypeMessage.ADD_VERSION_TO_PROJECT:
                //{
                //    var _issue = getDto<IssueDto>(_data);
                //    result = _irpcServiceIssue.addVersionToProject(_issue, 1);
                //    break;
                //}
                //case ITSTypeMessage.ADD_PARTICIPIANT_TO_PROJECT:
                //{
                //    var _participiant = getDto<ParticipiantDto>(_data);
                //    result = _irpcServiceIssue.addParticipiantToProject(_participiant, 23);
                //    break;
                //}
                //case ITSTypeMessage.CREATE_ISSUE:
                //{
                //    var _issue = getDto<IssueDto>(_data);
                //    result = _irpcServiceIssue.createIssue(_issue);
                //    break;
                //}
                //case ITSTypeMessage.CHANGE_STATUS_ISSUE:
                //{
                //    var _issue = getDto<IssueDto>(_data);
                //    result = _irpcServiceIssue.changeStatusIssue(_issue, 45);
                //    break;
                //}
                //case ITSTypeMessage.ADD_PARTICIPIANT:
                //{
                //    var _participiant = getDto<ParticipiantDto>(_data);
                //    result = _irpcServiceIssue.addParticipiant(_participiant);
                //    break;
                //}
                //default:
                //{
                //    result = "{\"ERROR\":200}";
                //   break; 
                //}

            return "0";
        }
            

         

       
    }
}