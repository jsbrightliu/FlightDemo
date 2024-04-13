using Flight.IServices;
using Flight.Models;
using Flight.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flight.Services
{
    public class AirportService : IAirportService
    {
        private readonly FlightContext _context;

        public AirportService(FlightContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Airport airport)
        {
            await _context.Airports.AddAsync(airport);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var airport = await GetAsync(id);
            if (airport != null)
            {
                _context.Airports.Remove(airport);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Airport?> GetAsync(int id)
        {
            Airport? airport = await _context.Airports.FirstOrDefaultAsync(p => p.Id == id);
            return airport;
        }

        public async Task<IList<Airport>> GetPagedListAsync(int page, int rows)
        {
            var start = (page - 1) * rows;
            return await _context.Airports.Skip(start).Take(rows).ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Airports.CountAsync();
        }

        public async Task UpdateAsync(Airport airport)
        {
            _context.Airports.Update(airport);
            await _context.SaveChangesAsync();
        }
    }
}
