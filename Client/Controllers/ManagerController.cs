using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class ManagerController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    // Auth
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Logout()
    {
        return View();
    }

    // Leaves Management
    public IActionResult ManageLeaveApplications()
    {
        return View();
    }

    public IActionResult ManageLeaveHistories()
    {
        return View();
    }

    
    // Employeee Management 
    public IActionResult GetAllEmployee()
    {
        return View();
    }

    public IActionResult GetEmployeeDetailByNik()
    {
        return View();
    }

    public IActionResult CreateEmployee()
    {
        return View();
    }


}
