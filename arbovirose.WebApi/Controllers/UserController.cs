﻿using arbovirose.Application.Usecases.User;
using arbovirose.Domain.Dtos.User;
using arbovirose.WebApi.Requestmodels.User;
using arbovirose.WebApi.Responsemodels;
using arbovirose.WebApi.Validators.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace arbovirose.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Criar um novo usário
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Usuário criado com Sucesso</response>
        /// <response code="400">Erro na operação</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
                    Password = data.Password,
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
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    }
}
