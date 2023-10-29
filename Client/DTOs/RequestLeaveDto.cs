using API.DTOs.Leaves;

namespace Client.DTOs
{
    public class RequestLeaveDto
    {
        public IEnumerable<AvailableLeaveDto> LeaveType { get; set; }
        public CreateLeaveDto Leave { get; set; }
    }
}
