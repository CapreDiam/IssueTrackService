using System;
using ITS.Data.Dto;
using ITS.Data.Enum.Issue;
using ITS.Inf.AMPQ.Messenger;
using ITS.Inf.RPC.Service;
using ITS.Model.RPC;
using Newtonsoft.Json.Linq;

namespace ITS.Inf.RPC.Clients
{
    public class RpcClientIssues:RpcBase
    {

        private readonly IRpcServiceIssues _irpcServiceIssue = new RpcServiceIssue();
        private readonly IMessenger _message = new Messenger();

        public override string Call(ItsEvent message)
        {
            Console.WriteLine(message);

            var data = GetDto<IssueDto>((JObject) message.Data);


            switch (message.Type)
            {
                case ItsTypeMessage.ChangeStatusIssue:
                {
                    _irpcServiceIssue.ChangeStatusIssue(data, 1);
                    break;
                }
                    case ItsTypeMessage.CreateIssue:
                {
                    _irpcServiceIssue.CreateIssue(data);
                    break;
                }
                    case ItsTypeMessage.AddVersionToProject:
                {
                    _irpcServiceIssue.AddVersionToProject(data, 1);
                    break;
                }
                default:
                {
                    return "400";
                }
            }   
            return "0";
        }
            

         

       
    }
}