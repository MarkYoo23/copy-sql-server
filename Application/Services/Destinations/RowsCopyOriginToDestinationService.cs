using Application.Models.Destinations;
using Domain.Models.CopyData;
using Domain.Repositories.Destinations;
using Domain.Repositories.Sources;

namespace Application.Services.Destinations;

public class RowsCopyOriginToDestinationService
{
    private readonly IColumnInfoRepository _columnInfoRepository;
    private readonly IDynamicGetDataRepository _dynamicGetDataRepository;
    private readonly IDynamicAddDataRepository _dynamicAddDataRepository;

    public RowsCopyOriginToDestinationService(
        IColumnInfoRepository columnInfoRepository,
        IDynamicGetDataRepository dynamicGetDataRepository,
        IDynamicAddDataRepository dynamicAddDataRepository)
    {
        _columnInfoRepository = columnInfoRepository;
        _dynamicGetDataRepository = dynamicGetDataRepository;
        _dynamicAddDataRepository = dynamicAddDataRepository;
    }

    public async Task ExecuteAsync(RowCopyOriginToDestinationRequest request)
    {
        // 테이블 정보 분석
        var columnComputedInfos = await _columnInfoRepository.FindAllAsync(request.Origin.Name);
        
        // 테이블 데이터 호출
        var sourceData = await _dynamicGetDataRepository.GetAllAsync(
            request.Origin.Name,
            request.Origin.Schema);

        // 테이블 정보 생성
        var table = Table.Create(
            request.Destination,
            columnComputedInfos,
            sourceData);

        // 테이블 데이터를 삽입
        await _dynamicAddDataRepository.AddAsync(table);
    }
}
