using appointment_booking_system.Models;
using appointment_booking_system.Response;
using appointment_booking_system.Services.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace appointment_booking_system.Controllers
{
    [ApiController]
    public class GenericController<TModel, TKey> : ControllerBase where TModel : BaseEntity<TKey>
    {     
        protected IActionResult Error(string result, string source) => ActionResponse.Error(System.Net.HttpStatusCode.InternalServerError, result, source);
        protected IActionResult Ok(object result, string source) => ActionResponse.Success(System.Net.HttpStatusCode.OK, result, source);
        protected IActionResult OkOrError<T>(Result<T> result, string source) => result.IsSuccess && result.Value != null ? Ok(result.Value, source) : Error(result.Error, source);
    }
}
