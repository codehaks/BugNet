using BugNet.Data;
using BugNet.Models;
using System.Diagnostics;

namespace BugNet.Service;

public class BugService : IBugService
{
    private readonly BugDbContext _db;

    public BugService(BugDbContext db)
    {
        _db = db;
    }

    public IList<Bug> GetAll()
    {
        return _db.Bugs.ToList();
    }

    public void Create(Bug bug)
    {
        _db.Bugs.Add(bug);
        _db.SaveChanges();
    }


}
