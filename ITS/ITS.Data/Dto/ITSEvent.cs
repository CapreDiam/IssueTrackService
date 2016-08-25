using System;
using ITS.Data.Enum.Issue;

namespace ITS.Data.Dto
{
    public class ItsEvent
    {
        public int Time { get; set; }
        public ItsTypeMessage Type { get; set; }
        public Guid CorelationId { get; set; }
        public Object Data { get; set; }


        public void Validate()
        {
            if (Time < 0) throw new System.ArgumentException("Time can't  be less 0");
        }
    }
}