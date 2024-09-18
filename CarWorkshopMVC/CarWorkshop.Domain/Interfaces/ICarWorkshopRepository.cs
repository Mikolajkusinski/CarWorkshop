namespace CarWorkshop.Domain.Interfaces;

public interface ICarWorkshopRepository
{
    Task Create(Domain.Entities.CarWorkshop carWorkshop);
    Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll();
    Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName);
    Task<Domain.Entities.CarWorkshop?> GetByName(string name);

    Task Commit();
}
