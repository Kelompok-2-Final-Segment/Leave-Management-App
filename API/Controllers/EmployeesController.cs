using API.Contracts;
using API.DTOs.Employees;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        //membuat employee repository untuk mengakses database sebagai readonly dan private
        private readonly IEmployeeRepository _employeeRepository;
        //dependency injection dilakukan
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        //[HttpGet("details")]
        ////membuat authorize khusus manager
        //[Authorize(Policy = "Manager")]
        //public IActionResult GetDetails()
        //{
        //    var employee = _employeeRepository.GetAll();
        //    if (!employee.Any())
        //    {
        //        return NotFound(new ResponseNotFoundHandler("Data Not Found"));
        //    }
        //    var employeeDetails = from emp in employee
        //                          select new EmployeeDetailsDto
        //                          {
        //                              Guid = emp.Guid,

        //                              FullName = string.Concat(emp.FirstName, " ", emp.LastName),
        //                              BirthDate = emp.BirthDate,
        //                              Gender = emp.Gender.ToString(),
        //                              HiringDate = emp.HiringDate,
        //                              Email = emp.Email,
        //                              PhoneNumber = emp.PhoneNumber,

        //                          };

        //    return Ok(new ResponseOkHandler<IEnumerable<EmployeeDetailsDto>>(employeeDetails));
        //}

        //method get dari http untuk getall universities
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employeeRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var data = result.Select(i => (EmployeeDto)i);
            return Ok(new ResponseOkHandler<IEnumerable<EmployeeDto>>(data));
        }
        //method get dari http untuk getByGuid employee
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _employeeRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));

            }
            return Ok(new ResponseOkHandler<EmployeeDto>((EmployeeDto)result));
        }
        //method post dari http untuk create employee
        //[HttpPost]
        //public IActionResult Create(CreateEmployeeDto createEmployeeDto)
        //{
        //    try
        //    {
        //        Employee toCreate = createEmployeeDto;
        //        toCreate.NIK = GenerateNIKHandler.GenerateNIK(_employeeRepository.GetLastNik());
        //        var result = _employeeRepository.Create(toCreate);
        //        return Ok(new ResponseOkHandler<string>("Date Created Successfully"));

        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
        //    }
        //}

        //method put dari http untuk Update employee
        [HttpPut]
        public IActionResult Update(EmployeeDto employeeDto)
        {
            try
            {
                var entity = _employeeRepository.GetByGuid(employeeDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }

                entity = EmployeeDto.ConvertToEMployee(employeeDto, entity);
                var result = _employeeRepository.Update(entity);
                return Ok(new ResponseOkHandler<String>("Data Updated"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Update Data", e.Message));
            }

        }
        //method delete dari http untuk delete employee
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                var employee = _employeeRepository.GetByGuid(guid);
                if (employee is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                var result = _employeeRepository.Delete(employee);
                return Ok(new ResponseOkHandler<String>("Data Deleted"));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }
    }
}
