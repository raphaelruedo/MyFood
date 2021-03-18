using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyFood.Application.ViewModels;

namespace MyFood.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        void Register(ProductViewModel productViewModel);
        void Update(ProductViewModel productViewModel);
        void Remove(Guid id);
        Task<ProductViewModel> GetById(Guid id);
        Task<IEnumerable<ProductViewModel>> GetAll();
        //IList<ProductHistoryData> GetAllHistory(Guid id);
    }
}
