using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatinApp.api.Data;
using DatinApp.api.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatinApp.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _autoMapper;

        public UserController(IDatingRepository repo, IMapper autoMapper)
        {
            _autoMapper = autoMapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Getsers()
        {
            var users = await _repo.GetUsers();
            var usersToReturn = _autoMapper.Map<IEnumerable<UserForDetailedDTO>>(users);
            return Ok(usersToReturn);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getser(int id)
        {
            var user = await _repo.GetUser(id);
            var userToReturn = _autoMapper.Map<UserForDetailedDTO>(user);
            
            return Ok(userToReturn);

        }
    }
}