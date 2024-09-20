using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;

public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IUserContext _userContext;

    public EditCarWorkshopCommandHandler(
        ICarWorkshopRepository carWorkshopRepository,
        IUserContext userContext
    )
    {
        _carWorkshopRepository = carWorkshopRepository;
    }

    public async Task<Unit> Handle(
        EditCarWorkshopCommand request,
        CancellationToken cancellationToken
    )
    {
        var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName!);
        var user = _userContext.GetCurrnetUser();
        var IsEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

        if (!IsEditable)
        {
            return Unit.Value;
        }

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
