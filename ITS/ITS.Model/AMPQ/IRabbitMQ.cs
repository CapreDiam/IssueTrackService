using System;
using System.Collections.Generic;
using ITS.Model.Event;
using RabbitMQ.Client.Impl;

namespace ITS.Model.AMPQ
{
    public interface IRabbitMQ
    {
        void createExchange(String name, String type, bool durable, bool autoDelete, bool _internal, Dictionary<String, Object> arguments);

        void createQueue(String queue, bool durable, bool exclusive, bool autoDelete, Dictionary<String, Object> arguments);

        void bindQueue(String queue, String exchange, String routingKey);

        void bindExchange(String destanationExchange, String sourceExchange, String routingKey);

        void publishMessage(String exchange, String routingKey, BasicProperties props, byte[] body);

        void listenToQueue(String queue, IListener listener);

    void createAndListenToQueue(String queue, String exchange, String routingKey, Dictionary<String, Object> arguments, IListener listener);

        
    }
}