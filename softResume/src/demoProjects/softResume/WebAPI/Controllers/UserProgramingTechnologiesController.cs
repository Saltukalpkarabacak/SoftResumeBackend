using Application.Features.UserProgramingTechnologies.Queries;
using Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddress;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProgramingTechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserProgramingTechnologyQuery getListUserSocialMediaAddressQuery = new() { PageRequest = pageRequest };
            var result = await Mediator!.Send(getListUserSocialMediaAddressQuery);
            return Ok(result);
        }

    }
}
