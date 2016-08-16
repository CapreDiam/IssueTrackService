namespace ITS.Inf.AMPQ.Messenger
{
    public interface IMessenger
    {
        void sendStatus(string message, string routingKey);
        void sendRPCRequest(string message);
    }
}