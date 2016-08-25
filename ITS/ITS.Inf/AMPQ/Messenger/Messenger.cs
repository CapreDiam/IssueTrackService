using ITS.Model.AMPQ;
using ITS.Model.SMC;

namespace ITS.Inf.AMPQ.Messenger
{
    public class Messenger:IMessenger
    {
        private readonly StructureMapContainer _structureMapContainer = new StructureMapContainer();
        private IRabbitMq _rabbitMq;

        public Messenger()
        {
            _rabbitMq = _structureMapContainer.GetObject<RabbitMqService>();
        }

        public void SendStatus(string message, string routingKey)
        {
            
        }

        public void SendRpcRequest(string message, string routingKey)
        {
            _rabbitMq.PublishMessage("e.i.pub.its.its001", routingKey, null, message);
        }
    }
}