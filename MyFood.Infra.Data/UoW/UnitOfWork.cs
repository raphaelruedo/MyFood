using MyFood.Domain.Interfaces;
using MyFood.Infra.Data.Context;

namespace MyFood.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyFoodContext _context;

        public UnitOfWork(MyFoodContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
