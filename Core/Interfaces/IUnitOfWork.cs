namespace Core.Interfaces;
    public interface IUnitOfWork
    {
        ITeam Teams {get;}
        IDriver Drivers {get;}
        Task<int> SaveAsync();
    }
