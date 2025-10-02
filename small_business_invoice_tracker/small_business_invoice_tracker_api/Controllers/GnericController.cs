using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using small_business_invoice_tracker.Models;
using small_business_invoice_tracker.Response;
using small_business_invoice_tracker.Services.Interfaces;

namespace small_business_invoice_tracker.Controllers
{
    [ApiController]
    public class GenericController<TModel, TKey> : ControllerBase where TModel : BaseEntity<TKey>
    {
        private readonly IGenericService<TModel, TKey> _service;

        public GenericController(IGenericService<TModel, TKey> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync(), "Get");

        [HttpPost]
        public async Task<IActionResult> Create(TModel model) => OkOrError(await _service.CreateAsync(model), "Created");

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TKey id, TModel model) => OkOrError(await _service.UpdateAsync(id, model), "Updated");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(TKey id) => OkOrError(await _service.DeleteAsync(id), "Deleted");
        protected IActionResult Error(string result, string source) => ActionResponse.Error(System.Net.HttpStatusCode.InternalServerError, result, source);
        protected IActionResult Ok(object result, string source) => ActionResponse.Success(System.Net.HttpStatusCode.OK, result, source);
        protected IActionResult OkOrError<T>(Result<T> result, string source) => result.IsSuccess && result.Value != null ? Ok(result.Value, source) : Error(result.Error, source);
    }
}
