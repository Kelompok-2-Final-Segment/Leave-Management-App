using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Leaves
{
    public class CreateLeaveDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public StatusLevel Status { get; set; }
        public string Remarks { get; set; }

        public static implicit operator Leave(CreateLeaveDto dto)
        {
            return new Leave
            {
                Guid = new Guid(),
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Description = dto.Description,
                Status = dto.Status,
                Remarks = dto.Remarks,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
