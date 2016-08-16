using System;
using ITS.Model.SMC;
using RabbitMQ.Client;
using StructureMap;

namespace ITS.Model.AMPQ
{
    public class RabbitConfiguration
    {
        private readonly StructureMapContainer _structureMapContainer = new StructureMapContainer();
        private IModel iModel;

        public void Connect()
        {

            //todo refactore this, make parametres for connection in app.config
          /*  
           * ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "reindeer.rmq.cloudamqp.com";
            factory.Port = 5672;
            factory.UserName = "rfolccdv";
            factory.Password = "akCReLhVKmF29D8kGXy68zwcttD_xXP9";
            factory.VirtualHost = "rfolccdv";

            var connection = factory.CreateConnection();
            iModel = connection.CreateModel();
            _structureMapContainer.Inject<IModel>(iModel);
           */
            ConnectionFactory factory = new ConnectionFactory();
          //  factory.HostName = "37.57.25.31";

            factory.Uri = "amqp://admin:admin@178.137.30.143:5672//";

            //factory.HostName = "37.57.25.31";
            //factory.Port = 5672;
            //factory.UserName = "admin";
            //factory.Password = "admin";
            //factory.VirtualHost = "/";
            try
            {
                var connection = factory.CreateConnection();
                iModel = connection.CreateModel();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
            _structureMapContainer.Inject<IModel>(iModel);
        }

        public void Disconnect()
        {
            iModel.Close();
            _structureMapContainer.Inject<IModel>(iModel);
        }
    }
}