using System;
using ITS.Data.Enum.Issue;

namespace ITS.Data.Dto
{
    public class ITSEvent
    {
        public TimeSpan Time { get; set; }
        public ITSTypeMessage Type { get; set; }
        public Guid CorelationId { get; set; }
        public Object Data { get; set; }
    }
}