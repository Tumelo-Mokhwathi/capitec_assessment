using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using small_business_invoice_tracker.Helpers;
using small_business_invoice_tracker.Models;
using small_business_invoice_tracker.Services.Interfaces;

namespace small_business_invoice_tracker.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceTrackersController : GenericController<Invoice, int>
    {
        private readonly IGenericService<Invoice, int> _service;
        public InvoiceTrackersController(IGenericService<Invoice, int> service) : base(service)
        {
            _service = service;
        }

        [HttpPatch("{id}/pay")]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            var invoice = await _service.GetByIdAsync(id);
            if (invoice == null) return NotFound();

            invoice.Status = InvoiceStatus.Paid;
            invoice.ModifiedDate = DateTime.UtcNow;

            await _service.UpdateAsync(id, invoice);

            return Ok(invoice);
        }
    }
}
