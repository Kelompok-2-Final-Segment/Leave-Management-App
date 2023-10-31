namespace API.DTOs.Leaves
{
    public class LeaveStatisticStaffDto
    {
        public int TotalRequest { get; set; }
        public int Approved { get; set; }
        public int Rejected { get; set; }
        public int Pending { get; set; }
        public int Cancelled { get; set; }

    }
}
