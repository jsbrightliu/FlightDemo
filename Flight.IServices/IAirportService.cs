using Flight.Models.Entities;

namespace Flight.IServices
{
    public interface IAirportService
    {
        Task<Airport?> GetAsync(int id);

        Task AddAsync(Airport airport);

        Task UpdateAsync(Airport airport);

        Task DeleteAsync(int id);

        Task<IList<Airport>> GetListAsync(string code);
    }
}
