using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using small_business_invoice_tracker.DataAccess;
using small_business_invoice_tracker.Helpers;
using small_business_invoice_tracker.Models;
using small_business_invoice_tracker.Services.Interfaces;

namespace small_business_invoice_tracker.Services
{
    public class GenericService<TModel, TKey> : IGenericService<TModel, TKey> where TModel : BaseEntity<TKey>
    {
        private readonly ApplicationDbContext _context;

        public GenericService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TModel> GetByIdAsync(TKey id)
        {
            var entity = await _context.Set<TModel>().FindAsync(id);

            if (entity is null) throw new NotFoundException($"Entity with ID {id} not found.");

            return entity;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var items = await _context.Set<TModel>().ToListAsync();

            if (typeof(TModel) == typeof(Invoice))
            {
                var today = DateOnly.FromDateTime(DateTime.UtcNow);

                foreach (var item in items)
                {
                    if (item is Invoice invoice)
                    {
                        if (invoice.Status == InvoiceStatus.Pending && invoice.DueDate < today)
                        {
                            invoice.Status = InvoiceStatus.Overdue;
                            invoice.ModifiedDate = DateTime.UtcNow;
                        }
                    }
                }

                await _context.SaveChangesAsync();
            }

            return items;
        }

        public async Task<Result<TModel>> CreateAsync(TModel entity)
        {
            var createdDateProperty = typeof(TModel).GetProperty("CreatedDate");
            createdDateProperty?.SetValue(entity, DateTime.Now);

            var statusProperty = typeof(TModel).GetProperty("Status");
            statusProperty?.SetValue(entity, InvoiceStatus.Pending);

            _context.Set<TModel>().Add(entity);
            await _context.SaveChangesAsync();
            return Result.Success(entity);
        }

        public async Task<Result<TModel>> UpdateAsync(TKey id, TModel entity)
        {
            var existingEntity = await GetByIdAsync(id);

            typeof(TModel).GetProperty("Id")?.SetValue(entity, id);
            typeof(TModel).GetProperty("ModifiedDate")?.SetValue(entity, DateTime.Now);

            return existingEntity is null ? Result.Failure<TModel>($"Entity with ID {id} not found.") : await UpdateAndSaveChangesAsync(existingEntity, entity);
        }

        public async Task<Result<TModel>> DeleteAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);
            return entity is null ? Result.Failure<TModel>($"Entity with ID {id} not found.") : await RemoveAndSaveChangesAsync(entity);
        }

        private async Task<Result<TModel>> UpdateAndSaveChangesAsync(TModel existingEntity, TModel newValues)
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(newValues);
            await _context.SaveChangesAsync();
            return Result.Success(existingEntity);
        }

        private async Task<Result<TModel>> RemoveAndSaveChangesAsync(TModel entity)
        {
            _context.Set<TModel>().Remove(entity);
            await _context.SaveChangesAsync();
            return Result.Success(entity);
        }
    }
}
