using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Queries.GetCarWorkshopServicesQuery;

public class GetCarWorkshopServicesQuery : IRequest<IEnumerable<CarWorkshopServiceDto>>
{
    public string EncodedName { get; set; } = default!;
}
