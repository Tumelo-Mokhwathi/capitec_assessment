using card_dispute_portal.DataAccess;
using card_dispute_portal.Helpers;
using card_dispute_portal.Models;
using card_dispute_portal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace card_dispute_portal.Services
{
    public class CardTransactionService : ICardTransactionService
    {
        private readonly ApplicationDbContext _context;

        public CardTransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CardTransaction>> GetAllAsync()
        {
            return await _context.CardTransactions.ToListAsync();
        }

        public async Task<CardTransaction?> GetByIdAsync(int id)
        {
            return await _context.CardTransactions.FindAsync(id);
        }

        public async Task<CardTransaction> CreateAsync(CardTransaction transaction)
        {
            if (transaction.CreatedDate == default)
                transaction.CreatedDate = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(transaction.DisputeReason) && transaction.DisputeStatus == null)
                transaction.DisputeStatus = DisputeStatus.Pending;

            _context.CardTransactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<CardTransaction?> UpdateDisputeAsync(int id, CardTransaction updated)
        {
            var transaction = await _context.CardTransactions.FindAsync(id);
            if (transaction == null) return null;

            transaction.DisputeReason = updated.DisputeReason ?? transaction.DisputeReason;
            transaction.DisputeStatus = updated.DisputeStatus ?? transaction.DisputeStatus;
            transaction.ModifiedDate = updated.ModifiedDate ?? transaction.ModifiedDate;

            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}