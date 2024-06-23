using arbovirose.Application.Usecases.User;
using arbovirose.Domain.Dtos.User;
using arbovirose.WebApi.Requestmodels.User;
using arbovirose.WebApi.Responsemodels;
using arbovirose.WebApi.Responsemodels.User;
using arbovirose.WebApi.Validators.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace arbovirose.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        public UserController(ILogger<UserController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Criar um novo usário
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Usuário criado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
       // [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<MessageResponse>> Create([FromBody] CreateUserRequest data, [FromServices] CreateUser createUser)
        {
            try
            {
                var validator = new CreateUserValidator();
                var result = validator.Validate(data);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                var userData = new CreateUserDTO()
                {
                    Name = data.Name,
                    Email = data.Email,
                    ProfileId = data.ProfileId
                };

                var user = await createUser.Execute(userData);

                this._logger.LogInformation("Usuário criado com sucesso");
                var response = new MessageResponse("Usuário criado com sucesso");
                return Ok(response);
            }
            catch (Exception ex) 
            {
                this._logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Desativa um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Usuário desativado com Sucesso</response>
        /// <response code="400">Erro na operação</response> 
        /// <response code="401">Acesso não autorizado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<MessageResponse>> Deactivate([FromRoute] Guid id, [FromServices] DeactivateUser deactivateUser)
        {
            try
            {
                var user = await deactivateUser.Execute(id);

                this._logger.LogInformation("Usuário desativado com sucesso");

                var response = new MessageResponse("Usuário desativado com sucesso");

                return Ok(response);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Usuárioa retornados com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<GetAllUserResponse>>> GetAll([FromServices] GetAllUser getAllUser)
        {
            try
            {
                var users = await getAllUser.Execute();
                var usersResponse = this._mapper.Map<IEnumerable<GetAllUserResponse>>(users);

                this._logger.LogInformation("Usuários retornados com sucesso");

                return Ok(usersResponse);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
