using System;
using System.Collections.Generic;
using ITS.Model.Event;
using RabbitMQ.Client.Impl;

namespace ITS.Inf.AMPQ
{
    public interface IRabbitMq
    {
        void CreateExchange(String name, String type, bool durable, bool autoDelete, bool _internal, Dictionary<String, Object> arguments);

        void CreateQueue(String queue, bool durable, bool exclusive, bool autoDelete, Dictionary<String, Object> arguments);

        void BindQueue(String queue, String exchange, String routingKey);

        void BindExchange(String destanationExchange, String sourceExchange, String routingKey);

        void PublishMessage(String exchange, String routingKey, BasicProperties props, string body);

        void ListenToQueue(String queue, IListener listener);

    void CreateAndListenToQueue(String queue, String exchange, String routingKey, Dictionary<String, Object> arguments, IListener listener);

        
    }
}