using System.Threading.Tasks;

namespace DGuard.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}