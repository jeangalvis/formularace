using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbFirstContext context;
    public ITeam _team;
    public IDriver _driver;
    public UnitOfWork(DbFirstContext _context)
    {
        context = _context;
    }
    public ITeam Teams{
        get{
            if(_team == null){
                _team = new TeamRepository(context);
            }
            return _team;
        }
    }

    public IDriver Drivers{
        get{
            if(_driver == null){
                _driver = new DriverRepository(context);
            }
            return _driver;
        }
    }


    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}
