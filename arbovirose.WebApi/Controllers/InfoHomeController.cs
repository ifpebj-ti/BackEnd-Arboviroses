using arbovirose.Application.Usecases.InfoHome;
using arbovirose.Domain.Dtos.InfoHome;
using arbovirose.WebApi.Requestmodels.InfoHome;
using arbovirose.WebApi.Responsemodels;
using arbovirose.WebApi.Responsemodels.InfoHome;
using arbovirose.WebApi.Validators.InfoHome;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace arbovirose.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoHomeController : ControllerBase
    {
        private readonly ILogger<InfoHomeController> _logger;
        public InfoHomeController(ILogger<InfoHomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Adicionar informações na home
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Informações da home adicionadas com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Administrator, Editor")]
        public async Task<ActionResult<MessageResponse>> Add([FromForm] AddInfoHomeRequest data, [FromServices] AddInfoHome addInfoHome)
        {
            try
            {
                var validator = new AddInfoHomeValidator();
                var result = validator.Validate(data);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                using Stream fileStream = data.File.OpenReadStream();
                var fileBuffer = new byte[fileStream.Length];

                using (fileStream)
                {
                    await fileStream.ReadAsync(fileBuffer, 0, (int)fileStream.Length);
                }

                var InfoHomeData = new AddInfoHomeDTO()
                {
                    Topic = data.Topic,
                    Title = data.Title,
                    TitleLink = data.TitleLink,
                    Link = data.Link,
                    File = fileBuffer,
                    OriginalFileName = data.File.FileName.Split(".")[0],
                    TypeFile = data.File.ContentType.Split("/")[1],
                    Size = (double)fileStream.Length / (1024 * 1024),
                };

                await addInfoHome.Execute(InfoHomeData);

                this._logger.LogInformation("Informações adicionadas com sucesso");
                var response = new MessageResponse("Informações adicionadas com sucesso");
                return Ok(response);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Listar informações da home
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Informações da home retornadas com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Administrator, Editor")]
        public async Task<ActionResult<IEnumerable<InfoHomeResponse>>> GetAll([FromServices] GetAllInfoHome getAllInfoHome)
        {
            try
            {
                var infoHome = await getAllInfoHome.Execute();

                var response = infoHome.Select(info => new InfoHomeResponse()
                {
                    Id = info.Id,
                    Topic = info.Topic,
                    Title = info.Title,
                    TitleLink = info.TitleLink,
                    Link = info.Link,
                });

                this._logger.LogInformation("Informações retornadas com sucesso");
                return Ok(response);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Editar informações na home
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Administrator, Editor")]
        public async Task<ActionResult<InfoHomeResponse>> Edit([FromBody] EditInfoHomeRequest data, [FromServices] EditInfoHome editInfoHome)
        {
            try
            {
                var editInfoHomeData = new EditInfoHomeDTO()
                {
                    Id = data.Id,
                    Topic = data.Topic,
                    Title = data.Title,
                    TitleLink = data.TitleLink,
                    Link = data.Link,
                    File = data.File,
                    OriginalFileName = data.OriginalFileName,
                    TypeFile = data.TypeFile,
                    Size = data.Size,
                };

                var updatedInfoHome = await editInfoHome.Execute(editInfoHomeData);

                var response = new InfoHomeResponse()
                {
                    Id = updatedInfoHome.Id,
                    Topic = updatedInfoHome.Topic,
                    Title = updatedInfoHome.Title,
                    TitleLink = updatedInfoHome.TitleLink,
                    Link = updatedInfoHome.Link,
                };

                _logger.LogInformation("Informações editadas com sucesso");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletar informações da home
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Administrator, Editor")]
        public async Task<ActionResult<MessageResponse>> Delete([FromBody] DeleteInfoHomeRequest data, [FromServices] DeleteInfoHome deleteInfoHome)
        {
            try
            {
                var deleteInfoHomeData = new DeleteInfoHomeDTO()
                {
                    Id = data.Id,
                    TypeFile = data.TypeFile,
                    OriginalFileName = data.OriginalFileName,
                };

                await deleteInfoHome.Execute(deleteInfoHomeData);

                _logger.LogInformation("Informações deletadas com sucesso");
                var response = new MessageResponse("Informações deletadas com sucesso");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
