using Academy.Domain.Interfaces.Repository;
using Academy.Domain.Models;
using Academy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Data.Repository
{
    public class StudentRepository : IBaseRepository<Student, int>
    {
        private readonly SampleContext _db;

        public StudentRepository(SampleContext db)
        {
            _db = db;
        }
        public Student Add(Student student)
        {
            _db.Students.Add(student);
            return student;
        }

        public void Delete(int studentId)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)            
                _db.Students.Remove(student);
        }

        public void Edit(Student newData)
        {
            var student = _db.Students.Where(_ => _.Id == newData.Id).FirstOrDefault();

            if (student != null)
            {
                student.Id = student.Id;
                student.FirstName = newData.FirstName;
                student.LastName = newData.LastName;
                student.Age = newData.Age;
                student.Career = newData.Career;

                _db.Update(student);
            }
        }

        public Student GetEntity(int studentId)
        {
            return _db.Students.Where(_ => _.Id == studentId).FirstOrDefault() 
                ?? throw new ArgumentNullException($"Id {studentId} is not found");
        }

        public List<Student> GetList()
        {
            return _db.Students.ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
