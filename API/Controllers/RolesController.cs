﻿using API.Contracts;
using API.Data;
using API.DTOs.Roles;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Admin/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        //dependency injection dilakukan
        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        //method get dari http untuk getall universities
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _roleRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var data = result.Select(i => (RoleDto)i);
            return Ok(new ResponseOkHandler<IEnumerable<RoleDto>>(data));
        }
        //method get dari http untuk getByGuid role
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _roleRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));

            }
            return Ok(new ResponseOkHandler<RoleDto>((RoleDto)result));
        }
        //method post dari http untuk create role
        [HttpPost]
        public IActionResult Create(CreateRoleDto createRoleDto)
        {
            try
            {
                Role toCreate = createRoleDto;

                var result = _roleRepository.Create(toCreate);
                return Ok(new ResponseOkHandler<string>("Data Created Successfully"));
{

                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }
        }

        //method put dari http untuk Update role
        [HttpPut]
        public IActionResult Update(RoleDto roleDto)
        {
            try
            {
                var entity = _roleRepository.GetByGuid(roleDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));
                }
                //entity.Name = roleDto.Name;
                 entity = RoleDto.ConvertToRole(roleDto, entity);
  
                var result = _roleRepository.Update(entity);
                return Ok(new ResponseOkHandler<String>("Data Updated"));

            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }
        //method delete dari http untuk delete role
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                var role = _roleRepository.GetByGuid(guid);
                if (role is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                var result = _roleRepository.Delete(role);
                return Ok(new ResponseOkHandler<String>("Data Deleted"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }
    }
}
