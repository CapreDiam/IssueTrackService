using System;
using System.Collections.Generic;
using System.Text;
using ITS.Data.Dto;
using ITS.Inf.AMPQ;
using ITS.Model.AMPQ;
using ITS.Model.Event;
using ITS.Model.SMC;
using Nancy.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Impl;


namespace ITS.Model.AMPQ
{
    public class RabbitMQService:IRabbitMQ
    {
        private readonly StructureMapContainer _structureMapContainer = new StructureMapContainer();
        private readonly Encoding unicode = Encoding.Unicode;
        private IModel channel;

        public delegate void ListenerDelegate(String message);
        public event ListenerDelegate recieve;

        public RabbitMQService()
        {
            channel = _structureMapContainer.GetObject<IModel>();
        }

        public void createExchange(String name, String type, bool durable, bool autoDelete, bool _internal, Dictionary<String, Object> arguments)
        {
            Console.WriteLine(String.Format("[INFO] - Create exchange {0}", name));
            try
            {
                channel.ExchangeDeclare(exchange: name,
                                   type:type,
                                   durable: durable,
                                   autoDelete: autoDelete,
                                   arguments: arguments);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           
        }


        public void createQueue(string queue, bool durable, bool exclusive, bool autoDelete, Dictionary<string, object> arguments)
        {
            channel.QueueDeclare(queue: queue,
                durable: durable,
                exclusive: exclusive,
                autoDelete: autoDelete,
                arguments: arguments);
        }

        public void bindQueue(string queue, String exchange, string routingKey)
        {
            channel.QueueBind(queue:queue, exchange: exchange, routingKey:routingKey);
        }

        public void bindExchange(string destanationExchange, string sourceExchange, string routingKey)
        {
            channel.ExchangeBind(destination:destanationExchange,source:sourceExchange, routingKey:routingKey);
        }

        public void publishMessage(string exchange, string routingKey, BasicProperties props, string body)
        {
            
            var _body = unicode.GetBytes(body);
            channel.BasicPublish(exchange:exchange, routingKey:routingKey,basicProperties:props, body:_body);
        }

        public void listenToQueue(string queue, IListener listener)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                    //todo refactor this
                   /* JavaScriptSerializer request = new JavaScriptSerializer();
                    ITSEvent routes_list =
                        (ITSEvent) request.DeserializeObject(
                            message); */
                     listener.callback(message);
            };
            channel.BasicConsume(queue: queue,
                                 noAck: true,
                                 consumer: consumer);
        }

        public void createAndListenToQueue(string queue, string exchange, string routingKey, Dictionary<string, object> arguments, IListener listener)
        {
            createQueue(queue:queue, durable:true, autoDelete:false, exclusive:false, arguments:arguments);
            bindQueue(queue, exchange,routingKey);
            listenToQueue(queue, listener);
        }
    }
}