//using gnyang.samples.application.Commands;
using gnyang.samples.application.Queries;
using gnyang.samples.domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gnyang.samples.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet(Name = "GetWeatherForecast2")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet(Name = "GetWeatherForecast3")]
        public async Task<IActionResult> Get()
        {
            var command = new GetProductSummaryWithPaginationQuery("TESST");
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        ////[HttpGet(Name = "GetWeatherForecast3")]
        ////public async Task<IActionResult> GetProductSummaryDtoWithPagenation([AsParameters] GetProductSummaryWithPaginationQuery query)
        ////{
        ////    var result = await _mediator.Send(query);

        ////    return Ok(result);
        ////}
        //[HttpGet(Name = "GetWeatherForecast3")]
        //public async Task<string> GetProductSummaryDtoWithPagenation([AsParameters] GetProductSummaryWithPaginationQuery query)
        //{
        //    return await _mediator.Send(query);
        //}

        ////[HttpGet(Name = "GetWeatherForecast3")]
        ////public async Task<PaginatedList<ProductSummaryDto>> GetProductSummaryDtoWithPagenation([AsParameters] GetProductSummaryWithPaginationQuery query)
        ////{
        ////    return await _mediator.Send(query);
        ////}

        //public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        //{
        //    await _mediator.Send(command);

        //    return Ok(new ApiResponse<string>
        //    {
        //        Success = true,
        //        Code = 0,
        //        Message = string.Empty,
        //        Result = string.Empty
        //    });
        //}

        //public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        //{
        //    await _mediator.Send(command);

        //    return Ok(new ApiResponse<string>
        //    {
        //        Success = true,
        //        Code = 0,
        //        Message = string.Empty,
        //        Result = string.Empty
        //    });
        //}
    }
}
