using CSharpFunctionalExtensions;

namespace appointment_booking_system.Services.Interfaces
{
    public interface IGenericService<TModel, TKey>
    {
        Task<IEnumerable<TModel>> GetAllAsync();
    }
}
