using API.Models;

namespace API.DTOs.LeaveTypes
{
    public class LeaveTypeDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int MinDuration { get; set; }
        public int MaxDuration { get; set; }

        public static explicit operator LeaveTypeDto(LeaveType leavetype)
        {
            return new LeaveTypeDto
            {
                Guid = leavetype.Guid,
                Name = leavetype.Name,
                MinDuration = leavetype.MinDuration,
                MaxDuration = leavetype.MaxDuration,
          
            };
        }
    }
}
