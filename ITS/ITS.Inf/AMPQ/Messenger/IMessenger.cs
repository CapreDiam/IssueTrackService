namespace ITS.Inf.AMPQ.Messenger
{
    public interface IMessenger
    {
        void SendStatus(string message, string routingKey);
        void SendRpcRequest(string message, string routingKey);
    }
}