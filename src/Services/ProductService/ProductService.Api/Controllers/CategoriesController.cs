using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Features.Categories.Queries.GetList;
using ProductService.Application.Features.Products.Queries.GetList;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListCategoryQuery { PageRequest = pageRequest });

            return Ok(response);
        }
    }
}
