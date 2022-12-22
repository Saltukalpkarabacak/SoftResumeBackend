using Application.Features.ProgramingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgramingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgramingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.ProgramingLanguages.Queries.GetListProgrammingLanguageByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        /// <summary>
        /// Programlama dili ekleme işlemi.
        /// </summary>
        /// <param name="createProgrammingLanguageCommand">Eklenecek programlama dili bilgileri.</param>
        /// <returns>Eklenen programlama dili bilgileri.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            var result = await Mediator!.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }

        /// <summary>
        /// Programlama dili güncelleme işlemi.
        /// </summary>
        /// <param name="updateProgrammingLanguageCommand">Güncellenecek programlama dili bilgileri.</param>
        /// <returns>Güncellenen programlama dili bilgileri.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            var result = await Mediator!.Send(updateProgrammingLanguageCommand);
            return Ok(result);
        }

        /// <summary>
        /// Programlama dili silme işlemi.
        /// </summary>
        /// <param name="deleteProgrammingLanguageCommand">Silinecek programlama dili bilgileri.</param>
        /// <returns>Silinen programlama dili bilgileri.</returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            var result = await Mediator!.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }

        /// <summary>
        /// Programlama dili bilgilerini getirme işlemi.
        /// </summary>
        /// <param name="getByIdProgrammingLanguageQuery">Getirilecek programlama dili bilgileri.</param>
        /// <returns>Getirilen programlama dili bilgileri.</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            var result = await Mediator!.Send(getByIdProgrammingLanguageQuery);
            return Ok(result);
        }

        /// <summary>
        /// Programlama dillerini getirme işlemi.
        /// </summary>
        /// <param name="pageRequest">Sayfalama bilgileri.</param>
        /// <returns>Getirilen programlama dilleri bilgileri.</returns>
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            var result = await Mediator!.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        /// <summary>
        /// Programlama dillerini getirme işlemi dinamik sorgu ile.
        /// </summary>
        /// <param name="pageRequest">Sayfalama bilgileri.</param>
        /// <param name="dynamic">Dinamik sorgu bilgileri.</param>
        /// <returns>Getirilen programlama dilleri bilgileri.</returns>
        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            var getListByDynamicProgrammingLanguageQuery = new GetListProgrammingLanguageByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator!.Send(getListByDynamicProgrammingLanguageQuery);
            return Ok(result);
        }
    }
}
