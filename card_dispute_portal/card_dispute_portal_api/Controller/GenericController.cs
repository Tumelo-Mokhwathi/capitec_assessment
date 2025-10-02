using card_dispute_portal.Models;
using card_dispute_portal.Response;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace card_dispute_portal.Controller
{
    [ApiController]
    public class GenericController<TModel, TKey> : ControllerBase where TModel : BaseEntity<TKey>
    {
        protected IActionResult Error(string result, string source) => ActionResponse.Error(System.Net.HttpStatusCode.InternalServerError, result, source);
        protected IActionResult Ok(object result, string source) => ActionResponse.Success(System.Net.HttpStatusCode.OK, result, source);
        protected IActionResult OkOrError<T>(Result<T> result, string source) => result.IsSuccess && result.Value != null ? Ok(result.Value, source) : Error(result.Error, source);
    }
}
