namespace Domain.Entities
{
    public class Employee
    {
        public required long EmployeeID { get; set; }   
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string PersonalPhone { get; set; }
        public required string Mobile { get; set; }
        public required string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public DateTime DateOfJoining { get; set; }
        public required string PassportNo { get; set; }
        public required string PAN { get; set; }
        public int WorkExperience { get; set; }
        public long? ReportsTo { get; set; }  
        public required string Department { get; set; }
        public required string AddedBy { get; set; }
        public string? ModifyBy { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime? ModifyAt { get; set; }
    }
}
