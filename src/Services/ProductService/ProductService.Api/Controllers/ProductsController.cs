using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Features.Products.Queries.GetByCategoryId;
using ProductService.Application.Features.Products.Queries.GetList;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListProductQuery { PageRequest = pageRequest });

            return Ok(response);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetListByCategoryId([FromRoute] Guid categoryId,[FromQuery] PageRequest pageRequest)
        { 
            var response = await Mediator.Send(new GetListByCategoryIdQuery { CategoryId= categoryId, PageRequest = pageRequest });

            return Ok(response);
        }
    }
}
