using card_dispute_portal.Models;
using card_dispute_portal.Services.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace card_dispute_portal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTransactionsController : GenericController<CardTransaction, int>
    {
        private readonly ICardTransactionService _service;

        public CardTransactionsController(ICardTransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result, "Get");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await _service.GetByIdAsync(id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CardTransaction transaction)
        {
            var result = await _service.CreateAsync(transaction);
            return OkOrError<CardTransaction>(result, "Transaction Created");
        }

        [HttpPut("{id}/dispute")]
        public async Task<IActionResult> UpdateDispute(int id, [FromBody] CardTransaction updated)
        {
            var result = await _service.UpdateDisputeAsync(id, updated);
            if (result == null) return Error($"Transaction {id} not found", nameof(UpdateDispute));

            return OkOrError<CardTransaction>(result, "Dispute Updated");
        }
    }
}
