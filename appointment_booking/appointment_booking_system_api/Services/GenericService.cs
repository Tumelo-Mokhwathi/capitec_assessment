using appointment_booking_system.DataAccess;
using appointment_booking_system.Models;
using appointment_booking_system.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace appointment_booking_system.Services
{
    public class GenericService<TModel, TKey> : IGenericService<TModel, TKey> where TModel : BaseEntity<TKey>
    {
        private readonly ApplicationDbContext _context;

        public GenericService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _context.Set<TModel>().ToListAsync();
        }
    }
}
