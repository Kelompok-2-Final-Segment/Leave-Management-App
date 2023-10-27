using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Leaves
{
    public class EditLeaveDto
    {
        public Guid Guid { get; set; }
        public StatusLevel Status { get; set; }
        public string Remarks { get; set; }

        public static Leave EditLeaveByManager(EditLeaveDto editLeaveDto, Leave leave)
        {
            leave.Status = editLeaveDto.Status;
            leave.RemarksManager = editLeaveDto.Remarks;
            leave.ModifiedDate = DateTime.Now;
            return leave;
        }

        public static Leave EditLeaveByHR(EditLeaveDto editLeaveDto, Leave leave)
        {
            leave.Status = editLeaveDto.Status;
            leave.RemarksHR = editLeaveDto.Remarks;
            leave.ModifiedDate = DateTime.Now;
            return leave;
        }
    }
}
