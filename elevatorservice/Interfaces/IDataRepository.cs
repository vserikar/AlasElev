namespace elevatorservice.Interfaces
{
   public interface IDataRepository
        {
            bool updatePendingState(byte elevatorId, sbyte floorNumber);
            IEnumerable<sbyte> getPendingQueue(byte elevatorId);
        sbyte getNextMove(byte elevatorId);
            
         }
    }

