namespace elevatorservice.Implementations
{
    using elevatorservice.Interfaces;
    using elevatorservice.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

        class DataRepository : IDataRepository
        {
            private Dictionary<byte, Elevator> ElevatorPool = new Dictionary<byte, Elevator>();
            private object lockObject = new object();

            public DataRepository()
            {
                // Initialize elevators
                this.ElevatorPool.Add(1, new Elevator() { Id = 1, Capacity = 500, isActive = true });
            }
            public sbyte getNextMove(byte elevatorId)
            {
                Elevator el = this.ElevatorPool[elevatorId];
            if (!el.PendingQueue.Any())
            {
                return -10;
            }
                return el.PendingQueue.Peek();
            }

            public IEnumerable<sbyte> getPendingQueue(byte elevatorId)
            {
                Elevator el = this.ElevatorPool[elevatorId];
                return el.PendingQueue.ToList();
            }

            public bool updatePendingState(byte elevatorId, sbyte floorNumber)
            {
                lock (lockObject)
                {
                    this.ElevatorPool[elevatorId].PendingQueue.Enqueue(floorNumber);
                }

                return true;
            }
        }
    }
