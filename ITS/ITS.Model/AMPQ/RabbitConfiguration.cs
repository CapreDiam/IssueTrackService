using System;
using ITS.Model.SMC;
using RabbitMQ.Client;
using System.Configuration;


namespace ITS.Model.AMPQ
{
    public class RabbitConfiguration
    {
       // private static Logger Log = LogManager.GetCurrentClassLogger();
        private readonly StructureMapContainer _structureMapContainer = new StructureMapContainer();
        private IModel _iModel;

        public void Connect()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    Uri = "amqp://admin:admin@37.57.25.31:5672//"
                };
                var connection = factory.CreateConnection();
                _iModel = connection.CreateModel();
                _structureMapContainer.Inject<IModel>(_iModel);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
            
        }

        public void Disconnect()
        {
            _iModel.Close();
            _structureMapContainer.Inject<IModel>(_iModel);
        }
    }
}