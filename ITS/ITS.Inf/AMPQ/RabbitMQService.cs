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
    public class RabbitMqService:IRabbitMq
    {
        private readonly StructureMapContainer _structureMapContainer = new StructureMapContainer();
        private readonly Encoding _unicode = Encoding.Unicode;
        private IModel _channel;

        public delegate void ListenerDelegate(String message);
        public event ListenerDelegate Recieve;

        public RabbitMqService()
        {
            _channel = _structureMapContainer.GetObject<IModel>();
        }

        public void CreateExchange(String name, String type, bool durable, bool autoDelete, bool _internal, Dictionary<String, Object> arguments)
        {
            Console.WriteLine(String.Format("[INFO] - Create exchange {0}", name));
            try
            {
                _channel.ExchangeDeclare(exchange: name,
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


        public void CreateQueue(string queue, bool durable, bool exclusive, bool autoDelete, Dictionary<string, object> arguments)
        {
            _channel.QueueDeclare(queue: queue,
                durable: durable,
                exclusive: exclusive,
                autoDelete: autoDelete,
                arguments: arguments);
        }

        public void BindQueue(string queue, String exchange, string routingKey)
        {
            _channel.QueueBind(queue:queue, exchange: exchange, routingKey:routingKey);
        }

        public void BindExchange(string destanationExchange, string sourceExchange, string routingKey)
        {
            _channel.ExchangeBind(destination:destanationExchange,source:sourceExchange, routingKey:routingKey);
        }

        public void PublishMessage(string exchange, string routingKey, BasicProperties props, string body)
        {
            
            var _body = _unicode.GetBytes(body);
            _channel.BasicPublish(exchange:exchange, routingKey:routingKey,basicProperties:props, body:_body);
        }

        public void ListenToQueue(string queue, IListener listener)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                    //todo refactor this
                   /* JavaScriptSerializer request = new JavaScriptSerializer();
                    ITSEvent routes_list =
                        (ITSEvent) request.DeserializeObject(
                            message); */
                     listener.Callback(message);
            };
            _channel.BasicConsume(queue: queue,
                                 noAck: true,
                                 consumer: consumer);
        }

        public void CreateAndListenToQueue(string queue, string exchange, string routingKey, Dictionary<string, object> arguments, IListener listener)
        {
            CreateQueue(queue:queue, durable:true, autoDelete:false, exclusive:false, arguments:arguments);
            BindQueue(queue, exchange,routingKey);
            ListenToQueue(queue, listener);
        }
    }
}