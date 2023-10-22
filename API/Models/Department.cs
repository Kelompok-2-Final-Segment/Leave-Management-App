namespace Leave_Management_App.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public Guid ManagerGuid { get; set; }
    }
}
