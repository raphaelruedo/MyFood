using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyFood.Application.ViewModels;

namespace MyFood.Application.Interfaces
{
    public interface IOrderAppService : IDisposable
    {
        void Register(OrderViewModel orderViewModel);
        void Update(OrderViewModel orderViewModel);
        void Remove(Guid id);
        Task<OrderViewModel> GetById(Guid id);
        Task<IEnumerable<OrderViewModel>> GetAll();
        //IList<OrderHistoryData> GetAllHistory(Guid id);
    }
}
