using Domain.Models.Masters;
using Domain.Repositories.Sources;

namespace Application.Services.DatabaseObjects;

public class SystemObjectReadService
{
    private readonly ISystemObjectRepository _systemObjectRepository;

    public SystemObjectReadService(ISystemObjectRepository systemObjectRepository)
    {
        _systemObjectRepository = systemObjectRepository;
    }

    public async Task<IEnumerable<SystemObject>> GetAsync() => await _systemObjectRepository.GetAllAsync();
}
