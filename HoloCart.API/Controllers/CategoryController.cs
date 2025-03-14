using HoloCart.API.Base;
using HoloCart.Core.Features.DepartmentFeatures.Commands.Requests;
using HoloCart.Core.Features.DepartmentFeatures.Queries.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class CategoryController : AppControllerBase
    {
        [HttpGet(Router.CategoryRouting.GetById)]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var Response = await Mediator.Send(new GetCategoryByIdRequest(id));
            return NewResult(Response);
        }

        [HttpGet(Router.CategoryRouting.GetAll)]
        public async Task<IActionResult> GetAllCategory()
        {
            var Response = await Mediator.Send(new GetCategoriesRequest());
            return Ok(Response);
        }
        [HttpPost(Router.CategoryRouting.Create)]
        public async Task<IActionResult> AddCategory([FromForm] AddCategoryRequest Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpPut(Router.CategoryRouting.Update)]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryRequest Command)
        {
            var Response = await Mediator.Send(Command);
            return NewResult(Response);
        }

        [HttpDelete(Router.CategoryRouting.Delete)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var Response = await Mediator.Send(new DeleteCategoryRequest(id));
            return NewResult(Response);
        }



    }
}
