﻿

using API.Models;
using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Employees
{
    public class EmployeeDto
    {
        public Guid Guid { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate {  get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate {  get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public Guid DepartmentGuid { get; set; }


        //membuat implicit operator untuk update
        public static implicit operator Employee(EmployeeDto employeeDto)
        {
            return new Employee
            {
                Guid = employeeDto.Guid,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                BirthDate = employeeDto.BirthDate,
                Gender = employeeDto.Gender,
                HiringDate = employeeDto.HiringDate,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                ModifiedDate = DateTime.Now

            };
        }
        //membuat explicit operator untuk response get, create , getbyid
        public static explicit operator EmployeeDto(Employee employee)
        {
            return new EmployeeDto
            {
                Guid =employee.Guid,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                DepartmentGuid = employee.DepartmentGuid,

            };
        }

    }
}
