using System;
using ITS.Inf.AMPQ;
using ITS.Inf.AMPQ.Messenger;
using ITS.Inf.RPC;
using ITS.Inf.RPC.Clients;
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
        private ItsRunner _runner;

        

        private void Initialization()
        {
            InitializationRabbit();
            InitializatinRunner();
        }

        public void Start(string[] args)
        {
            Initialization();
            _runner.Run();
        }

        public void Stop()
        {
            //todo close all connection;
        }

        private void InitializationRabbit()
        {
            _rabbitConfiguration = new RabbitConfiguration();
            _rabbitConfiguration.Connect();

            var rabbitService = new RabbitMqService();
            var message = new Messenger();
            var rpcClient = new RpcClientIssues();


            _structureMapContainer.Inject<RabbitConfiguration>(_rabbitConfiguration);
            _structureMapContainer.Inject<RabbitMqService>(rabbitService);
            _structureMapContainer.Inject<IMessenger>(message);
            _structureMapContainer.Inject<IRpcClient>(rpcClient);
      
        }

        private void InitializatinRunner()
        {
            _runner = new ItsRunner();
        }

    }
}