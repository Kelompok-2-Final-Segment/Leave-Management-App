using API.Models;

namespace API.DTOs.LeaveTypes
{
    public class LeaveTypeDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public bool FemaleOnly { get; set; }
        public string? Remarks { get; set; }
        public int MinDuration { get; set; }
        public int MaxDuration { get; set; }

        public static explicit operator LeaveTypeDto(LeaveType leavetype)
        {
            return new LeaveTypeDto
            {
                Guid = leavetype.Guid,
                Name = leavetype.Name,
                Balance = leavetype.Balance,
                FemaleOnly = leavetype.FemaleOnly,
                Remarks = leavetype.Remarks,
                MinDuration = leavetype.MinDuration,
                MaxDuration = leavetype.MaxDuration,

            };
        }
        public static LeaveType ConvertToLeaveType(LeaveTypeDto leavetypeDto, LeaveType leaveType)
        {
            leaveType.Name = leavetypeDto.Name;
            leaveType.Balance = leavetypeDto.Balance;
            leaveType.FemaleOnly = leavetypeDto.FemaleOnly;
            leaveType.Remarks = leavetypeDto.Remarks; 
            leaveType.MinDuration = leavetypeDto.MinDuration;
            leaveType.MaxDuration = leavetypeDto.MaxDuration;
            leaveType.ModifiedDate = DateTime.Now;
            return leaveType;
        }
    }
}
