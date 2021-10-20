using BitsPilani.CourseToCartPublisher.BL.Commands;
using BitsPilani.CourseToCartPublisher.BL.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitsPilani.CourseToCartPublisher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesToCartController: BaseController
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Post(List<CourseCartCheckoutDTO> command)
        {
            return await this.Mediator.Send(new CheckoutCourseCartCommand() { courseCartCheckoutDTOs = command });
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put(UpdateCourseCartCommand command)
        {
            return await this.Mediator.Send(command);
        }
        [HttpDelete("{userName}")]
        public async Task<ActionResult<bool>> Delete(string userName)
        {
            return await this.Mediator.Send(new DeleteCourseCartCommand { UserName = userName });
        }
    }
}
