using AutoMapper;
using Contracts;
using Entities.DTO.UserDTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IManagerContract _managerContract;
        private readonly IMapper _mapper;

        public UserController(IManagerContract managerContract, IMapper mapper)
        {
            this._managerContract = managerContract ?? throw new ArgumentNullException(nameof(managerContract));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("Get-All-Users")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_managerContract.userContract.GetAll());
        }           
       

        [HttpGet("Get-User-By-Id/{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _managerContract.userContract.GetById(id);
            if(user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("Create-User")]
        public ActionResult<User> CreateUser(UserCreateDto userCreate)
        {
            var userToCreate = _mapper.Map<User>(userCreate);
            var createdUser = _managerContract.userContract.Create(userToCreate);
            _managerContract.Save();
            return CreatedAtAction(nameof(GetAllUsers), createdUser);
        }

        [HttpPut("Update-User")]
        public ActionResult<User> UpdateUser(User user)
        {
            if(user is null)
            {
                return BadRequest();
            }
            _managerContract.userContract.Update(user);
            _managerContract.Save();
            return NoContent();
        }

       

        [HttpDelete("Delete-User-By-Id/{id}")]
        public ActionResult DeleteUserById(int id)
        {

            var user = _managerContract.userContract.GetById(id);
            if(user is null)
            {
                return BadRequest();
            }
            _managerContract.userContract.Delete(user);
            _managerContract.Save();
            return NoContent();
        }
    }
}
