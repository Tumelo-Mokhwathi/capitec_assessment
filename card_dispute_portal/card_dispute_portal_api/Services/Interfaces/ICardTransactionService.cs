using card_dispute_portal.Models;

namespace card_dispute_portal.Services.Interfaces
{
    public interface ICardTransactionService
    {
        Task<List<CardTransaction>> GetAllAsync();
        Task<CardTransaction?> GetByIdAsync(int id);
        Task<CardTransaction> CreateAsync(CardTransaction transaction);
        Task<CardTransaction?> UpdateDisputeAsync(int id, CardTransaction updated);
    }
}
