using Newtonsoft.Json;
using MyFood.Domain.Core.Events;
using MyFood.Domain.Interfaces;
using MyFood.Infra.Data.Repository.EventSourcing;

namespace MyFood.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "System"
                 );

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
