namespace Leave_Management_App.Models
{
    public class DepartmentHistory : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid EmployeeGuid { get; set; }
        public Guid DepartmentGuid { get; set; }
    }
}
