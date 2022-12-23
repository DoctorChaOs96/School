using School.Entities;

namespace School.Services
{
    public class StudentDto
    {
        public StudentDto(StudentEntity entity)
        {
            FirstName = entity.FirstName;
            LastName = entity.LastName; 
            SchoolId = entity.SchoolId;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SchoolId { get; set; }
    }
}

// new SrudentDto(entity);
// Entity - object that has specified list of properties or field (DAL - Data Access Layer)
// DTO - Data Transfer Object (BLL - Business Logic Layer, or Service layer)
// class - ...
