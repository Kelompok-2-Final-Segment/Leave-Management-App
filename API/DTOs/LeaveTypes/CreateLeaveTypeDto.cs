using API.Models;

namespace API.DTOs.LeaveTypes
{
    public class CreateLeaveTypeDto
    {
        public string Name { get; set; }
        public int Balance { get; set; }
        public bool FemaleOnly { get; set; }
        public int MinDuration { get; set; }
        public int MaxDuration { get; set; }

        public static implicit operator LeaveType(CreateLeaveTypeDto dto)
        {
            return new LeaveType
            {
                Guid = Guid.NewGuid(),
                Name = dto.Name,
                Balance = dto.Balance,
                FemaleOnly = dto.FemaleOnly,
                MinDuration = dto.MinDuration,
                MaxDuration = dto.MaxDuration,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }
    }
}
