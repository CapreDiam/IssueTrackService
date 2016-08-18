﻿using ITS.Data.Dto;

namespace ITS.Model.RPC
{
    public interface IRPCClient
    {
        string call(ITSEvent message);
        void sendResult(string result, string corellationID);

    }
}