using System;

namespace AspNetCoreWebAppTodoList.Model
{
    public class TimedFloat
    {
        public DateTimeOffset Timestamp { get; set; }
        public long OffsetInMillis { get; set; }
        public float Value { get; set; }
    }
}