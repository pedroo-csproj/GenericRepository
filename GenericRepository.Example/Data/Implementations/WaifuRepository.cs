using GenericRepository.Example.Data.Interfaces;
using GenericRepository.Implementations;

namespace GenericRepository.Example.Data.Implementations;

public class WaifuRepository : Repository, IWaifuRepository
{
    public WaifuRepository(ApplicationDataContext applicationDataContext) : base(applicationDataContext)
    {
    }
}