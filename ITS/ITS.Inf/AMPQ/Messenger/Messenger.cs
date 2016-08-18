using ITS.Model.AMPQ;
using ITS.Model.SMC;

namespace ITS.Inf.AMPQ.Messenger
{
    public class Messenger:IMessenger
    {
        private readonly StructureMapContainer _structureMapContainer = new StructureMapContainer();
        private IRabbitMQ _rabbitMq;

        public Messenger()
        {
            _rabbitMq = _structureMapContainer.GetObject<RabbitMQService>();
        }

        public void sendStatus(string message, string routingKey)
        {
            
        }

        public void sendRPCRequest(string message, string routingKey)
        {
            _rabbitMq.publishMessage("e.i.pub.its.its001", routingKey, null, message);
        }
    }
}