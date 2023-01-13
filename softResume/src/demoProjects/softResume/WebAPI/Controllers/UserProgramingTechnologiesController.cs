using Application.Features.UserProgramingTechnologies.Commands.CreateUserProgramingTechnologies;
using Application.Features.UserProgramingTechnologies.Commands.DeleteUserProgramingTechnologies;
using Application.Features.UserProgramingTechnologies.Commands.UpdateUserProgramingTechnologies;
using Application.Features.UserProgramingTechnologies.Queries.GetByIdUserProgramingTechnology;
using Application.Features.UserProgramingTechnologies.Queries.GetListUserProgramingTechnology;
using Application.Features.UserProgramingTechnologies.Queries.GetListUserProgramingTechnologyByDynamic;
using Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Queries.GetByIdUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddressByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProgramingTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserProgramingTechnologyCommand createUserProgramingTechnologyCommand)
        {
            var result = await Mediator!.Send(createUserProgramingTechnologyCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserProgramingTechnologiesCommand updateUserProgramingTechnologiesCommand)
        {
            var result = await Mediator!.Send(updateUserProgramingTechnologiesCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserProgramingTechnologyCommand deleteUserProgramingTechnologyCommand)
        {
            var result = await Mediator!.Send(deleteUserProgramingTechnologyCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserProgramingTechnologyQuery getListUserSocialMediaAddressQuery = new() { PageRequest = pageRequest };
            var result = await Mediator!.Send(getListUserSocialMediaAddressQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserProgramingTechnologyQuery getByIdUserProgramingTechnologyQuery)
        {
            var result = await Mediator!.Send(getByIdUserProgramingTechnologyQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            var getListUserProgramingTechnologyByDynamicQuery = new GetListUserProgramingTechnologyByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator!.Send(getListUserProgramingTechnologyByDynamicQuery);
            return Ok(result);

        }

    }
}
