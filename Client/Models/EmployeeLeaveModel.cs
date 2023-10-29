namespace Client.Models;

public class EmployeeLeaveModel
{
    public string EmployeeGuid { get; set; }
    public string NIK { get; set; }
    public string FullName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Department { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveType { get; set; }

}
