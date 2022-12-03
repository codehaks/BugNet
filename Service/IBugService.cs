using BugNet.Models;

namespace BugNet.Service
{
    public interface IBugService
    {
        void Create(Bug bug);
        IList<Bug> GetAll();
    }
}