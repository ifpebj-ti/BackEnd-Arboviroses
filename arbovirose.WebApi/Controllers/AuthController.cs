using arbovirose.Application.Usecases.Auth;
using arbovirose.Domain.Dtos.Auth;
using arbovirose.WebApi.Requestmodels.Auth;
using arbovirose.WebApi.Responsemodels;
using arbovirose.WebApi.Responsemodels.Auth;
using arbovirose.WebApi.Validators.Auth;
using Microsoft.AspNetCore.Mvc;

namespace arbovirose.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Realizar login
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Login realizado com Sucesso</response>
        /// <response code="404">Erro na operação</response>
        /// <response code="400">Erro na operação</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest data, [FromServices] Login login)
        {
            try
            {
                var validator = new LoginValidator();
                var result = validator.Validate(data);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                var loginData = new LoginDTO()
                {
                    Email = data.Email,
                    Password = data.Password,
                };

                var token = await login.Execute(loginData);

                this._logger.LogInformation("Login realizado com sucesso");
                return Ok(new LoginResponse { Token = token});
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }


        /// <summary>
        /// Alterar senha no primeiro acesso
        /// </summary>
        /// <response code="200">Login realizado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        [HttpPost("primaryaccess")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MessageResponse>> PrimaryAccess([FromBody] PrimaryAccessRequest data, [FromServices] PrimaryAccess primaryAccess)
        {
            try
            {
                var validator = new PrimaryAccessValidator();
                var result = validator.Validate(data);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }
                var primaryAccessData = new PrimaryAccessDTO()
                {
                    Email = data.Email,
                    Password = data.Password,
                    UniqueCode = data.UniqueCode,
                };

                await primaryAccess.Execute(primaryAccessData);

                this._logger.LogInformation("Senha alterda com sucesso");
                var response = new MessageResponse("Senha alterda com sucesso");
                return Ok(response);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}
