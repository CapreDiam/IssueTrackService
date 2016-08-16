using System;
using ITS.Inf.AMPQ.Messenger;
using ITS.Inf.RPC;
using ITS.Model.AMPQ;
using ITS.Model.RPC;
using ITS.Model.SMC;
using ITS.Runner;

namespace ITS.Launcher
{
    public class Launcher
    {
        private readonly StructureMapContainer _structureMapContainer = new StructureMapContainer();
        private RabbitConfiguration _rabbitConfiguration;
        private ITSRunner _runner;

        

        private void initialization()
        {
            initializationRabbit();
            initializatinRunner();
        }

        public void start(string[] args)
        {
            initialization();
            _runner.run();
        }

        public void stop()
        {
            //todo close all connection;
        }

        private void initializationRabbit()
        {
            _rabbitConfiguration = new RabbitConfiguration();
            _rabbitConfiguration.Connect();

            var _rabbitService = new RabbitMQService();
            var _message = new Messenger();
            var _rpcClient = new RPCClient();

            _structureMapContainer.Inject<RabbitConfiguration>(_rabbitConfiguration);
            _structureMapContainer.Inject<RabbitMQService>(_rabbitService);
            _structureMapContainer.Inject<IMessenger>(_message);
            _structureMapContainer.Inject<IRPCClient>(_rpcClient);
        }

        private void initializatinRunner()
        {
            _runner = new ITSRunner();
        }

    }
}