using System;

namespace AspNetCoreWebAppTodoList.Model
{
    public class VoltageItem
    {
        public long Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public float Value { get; set; }
    }
}