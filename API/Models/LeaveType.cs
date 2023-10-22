namespace Leave_Management_App.Models
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; }
        public int MinDuration { get; set; }
        public int MaxDuration { get; set; }
    }
}
