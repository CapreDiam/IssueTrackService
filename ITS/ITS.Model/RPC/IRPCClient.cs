using ITS.Data.Dto;

namespace ITS.Model.RPC
{
    public interface IRpcClient
    {
        string Call(ItsEvent message);
        void SendResult(string result, string corellationId);

    }
}