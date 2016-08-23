using ITS.Data.Dto;

namespace ITS.Model.RPC
{
    public interface IRPCClient
    {
        string Call(ITSEvent message);
        void SendResult(string result, string corellationID);

    }
}