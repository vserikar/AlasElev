namespace elevatorservice.Models
{
    class Elevator
        {
            public byte Id { get; set; }
            public uint Capacity { get; set; }
            public bool isActive { get; set; }

            public Queue<sbyte> PendingQueue { get; set; }

            public Elevator()
            {
                this.PendingQueue = new Queue<sbyte>();
            }
        }
}
