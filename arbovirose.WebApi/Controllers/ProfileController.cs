using arbovirose.Application.Usecases.Profile;
using arbovirose.Domain.Dtos.Profile;
using arbovirose.WebApi.Requestmodels.Profile;
using arbovirose.WebApi.Responsemodels;
using arbovirose.WebApi.Validators.Profile;
using Microsoft.AspNetCore.Mvc;

namespace arbovirose.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        public ProfileController(ILogger<ProfileController> logger) 
        {
            this._logger = logger;
        }

        /// <summary>
        /// Criar um novo perfil
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Perfil criado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MessageResponse>> Create([FromBody] CreateProfileRequest data, [FromServices] CreateProfile createProfile)
        {
            try
            {
                var validator = new CreateProfileValidator();
                var result = validator.Validate(data);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                var profileData = new CreateProfileDTO()
                {
                    Office = data.Office
                };

                await createProfile.Execute(profileData);

                this._logger.LogInformation("Perfil criado com sucesso");
                var response = new MessageResponse("Perfil criado com sucesso");
                return Ok(response);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
