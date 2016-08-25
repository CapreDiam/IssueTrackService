using System;
using ITS.Inf.RPC;
using ITS.Inf.RPC.Listeners;
using ITS.Model.AMPQ;
using ITS.Model.RPC;
using ITS.Model.SMC;

namespace ITS.Runner
{
    public class ItsRunner
    {

        private readonly StructureMapContainer _structureMapContainer = new StructureMapContainer();
        private RabbitMqService _rabbitMq;
        private IRpcClient _rpcClient;

        public ItsRunner()
        {
            _rabbitMq = _structureMapContainer.GetObject<RabbitMqService>();
            _rpcClient = _structureMapContainer.GetObject<IRpcClient>();
        }

        public void Run()
        {
            CreateAndBindingExchange();
            ListeningRunner();
        }

        private void CreateAndBindingExchange()
        {
            Console.WriteLine(_rabbitMq.Equals(null));
            _rabbitMq.CreateExchange("e.debug.forward", "topic", true, false, false, null);
            _rabbitMq.CreateExchange("e.issue.forward", "topic", true, false, false, null);
            _rabbitMq.CreateExchange("e.status.forward", "topic", true, false, false, null);
            _rabbitMq.CreateExchange("e.project.forward", "topic", true, false, false, null);
            _rabbitMq.CreateExchange("e.participiant.forward", "topic", true, false, false, null);

            string dPubExchange = string.Format("e.debug.pub.{0}.{1}", "its", "its001");
            string iPubExchange = string.Format("e.issue.pub.{0}.{1}", "its", "its001");
            string sPubExchange = string.Format("e.status.pub.{0}.{1}", "its", "its001");
            string partPubExchange = string.Format("e.participiant.pub.{0}.{1}", "its", "its001");
            string projPubExchange = string.Format("e.project.pub.{0}.{1}", "its", "its001");

            _rabbitMq.CreateExchange(dPubExchange, "topic", true, false, false, null);
            _rabbitMq.CreateExchange(iPubExchange, "topic", true, false, false, null);
            _rabbitMq.CreateExchange(sPubExchange, "topic", true, false, false, null);
            _rabbitMq.CreateExchange(partPubExchange, "topic", true, false, false, null);
            _rabbitMq.CreateExchange(projPubExchange, "topic", true, false, false, null);

            _rabbitMq.BindExchange("e.debug.forward", dPubExchange, "#");
            _rabbitMq.BindExchange("e.issue.forward", iPubExchange, "#");
            _rabbitMq.BindExchange("e.project.forward", projPubExchange, "#");
            _rabbitMq.BindExchange("e.participiant.forward", partPubExchange, "#");
        }

        private void ListeningRunner()
        {
            var rpcListenerIssues = new RpcListenerIssues();
            var rpcListenerProject = new RpcListenerProject();
            var rpcListenerParticipiant = new RpcListenerPartcipiant();
            _rabbitMq.CreateAndListenToQueue("q.i.issue-track-service.ci.its001", "e.issue.forward", "r.i.create-issue.its.its001", null, rpcListenerIssues);
            _rabbitMq.CreateAndListenToQueue("q.pr.issue-track-service.avtp.its001", "e.project.forward", "r.i.add-version-to-project.its.its001", null, rpcListenerProject);
            _rabbitMq.CreateAndListenToQueue("q.pr.issue-track-service.aptp.its001", "e.project.forward", "r.i.add-participiant-to-project.its.its001", null, rpcListenerParticipiant);
            _rabbitMq.CreateAndListenToQueue("q.i.issue-track-service.csi.its001", "e.issue.forward", "r.i.change-status-issue.its.its001", null, rpcListenerProject);
            _rabbitMq.CreateAndListenToQueue("q.par.issue-track-service.ap.its001", "e.participiant.forward", "r.i.add-participiant.its.its001", null, rpcListenerParticipiant);
        }
    }
}