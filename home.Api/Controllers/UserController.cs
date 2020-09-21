using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using home.Api.Data;
using home.Api.Dto.Dto;
using home.Api.Models.Users;
using home.Api.Servcie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace home.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IMapper mapper,IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await userService.GetUsers();
            var userDtos = mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }
        [HttpGet("{userId}",Name =nameof(GetUser))]
        public async Task<ActionResult<UserDto>> GetUser(Guid userId)
        {
            var user = await userService.GetUser(userId);
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody]UserDto user)
        {
            var addUser = mapper.Map<User>(user);
            userService.AddUser(addUser);
            await userService.SaveAsync();
            var retuntUser = mapper.Map<UserDto>(addUser);
            return CreatedAtRoute(nameof(GetUser), new { userId = retuntUser.Id }, retuntUser);
        }
    }
}
