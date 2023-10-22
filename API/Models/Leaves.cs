namespace Leave_Management_App.Models
{
    public class Leaves : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
        public Guid EmployeeGuid { get; set; }
        public Guid LeaveTypeGuid { get; set; }
    }
}
