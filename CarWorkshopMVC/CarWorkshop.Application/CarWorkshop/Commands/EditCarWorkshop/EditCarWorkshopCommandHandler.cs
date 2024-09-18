using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;

public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;

    public EditCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository)
    {
        _carWorkshopRepository = carWorkshopRepository;
    }

    public async Task<Unit> Handle(
        EditCarWorkshopCommand request,
        CancellationToken cancellationToken
    )
    {
        var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName!);

        carWorkshop.Description = request.Description;
        carWorkshop.About = request.About;

        carWorkshop.ContactDetails.City = request.City;
        carWorkshop.ContactDetails.Street = request.Street;
        carWorkshop.ContactDetails.PostalCode = request.PostalCode;
        carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;

        await _carWorkshopRepository.Commit();

        return Unit.Value;
    }
}
