using System;
using ITS.Inf.RPC;
using ITS.Model.AMPQ;
using ITS.Model.RPC;
using ITS.Model.SMC;

namespace ITS.Runner
{
    public class ITSRunner
    {

        private readonly StructureMapContainer _structureMapContainer = new StructureMapContainer();
        private RabbitMQService _rabbitMq;
        private IRPCClient _rpcClient;

        public ITSRunner()
        {
            _rabbitMq = _structureMapContainer.GetObject<RabbitMQService>();
            _rpcClient = _structureMapContainer.GetObject<IRPCClient>();
        }

        public void run()
        {
            createAndBindingExchange();
            listeningRunner();
        }

        private void createAndBindingExchange()
        {
            Console.WriteLine(_rabbitMq.Equals(null));
            _rabbitMq.createExchange("e.d.forward", "topic", true, false, false, null);
            _rabbitMq.createExchange("e.i.forward", "topic", true, false, false, null);
            _rabbitMq.createExchange("e.s.forward", "topic", true, false, false, null);

            string dPubExchange = string.Format("e.d.pub.{0}.{1}", "its", "its001");
            string iPubExchange = string.Format("e.i.pub.{0}.{1}", "its", "its001");
            string sPubExchange = string.Format("e.s.pub.{0}.{1}", "its", "its001");

            _rabbitMq.createExchange(dPubExchange, "topic", true, false, false, null);
            _rabbitMq.createExchange(iPubExchange, "topic", true, false, false, null);
            _rabbitMq.createExchange(sPubExchange, "topic", true, false, false, null);

            _rabbitMq.bindExchange("e.d.forward", dPubExchange, "#");
            _rabbitMq.bindExchange("e.i.forward", iPubExchange, "#");
            _rabbitMq.bindExchange("e.s.forward", sPubExchange, "#");
        }

        private void listeningRunner()
        {
            var __rpcListenr = new RPCListener();
            _rabbitMq.createAndListenToQueue("q.i.issue-track-service.its001", "e.i.forward", "#", null, __rpcListenr);
        }
    }
}