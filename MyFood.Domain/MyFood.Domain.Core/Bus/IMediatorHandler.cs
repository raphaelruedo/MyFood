using System.Threading.Tasks;
using MyFood.Domain.Core.Commands;
using MyFood.Domain.Core.Events;

namespace MyFood.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
