using Academy.Domain;
using Academy.Domain.Interfaces.Repository;
using Academy.Application.Interfaces;
using Academy.Domain.Models;

namespace Academy.Application.Services
{
    public class StudentService : IBaseService<Student, int>
    {
        private readonly IBaseRepository<Student, int> _studentRepository;

        public StudentService(IBaseRepository<Student, int> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student Add(Student student)
        {
            if (student == null)                      
                throw new ArgumentNullException("The student is required to edit");

            student.Username = GenerateUsername(student.FirstName, student.LastName);

            var result = _studentRepository.Add(student);
            _studentRepository.SaveChanges();

            return result;
        }

        public void Delete(int studentId)
        {            
            _studentRepository.Delete(studentId);
            _studentRepository.SaveChanges();
        }

        public void Edit(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("The student is required");

            _studentRepository.Edit(student);
            _studentRepository.SaveChanges();
        }

        public Student GetEntity(int studentId)
        {
            return _studentRepository.GetEntity(studentId);
        }

        public List<Student> GetList()
        {
            return _studentRepository.GetList();
        }

        private string GenerateUsername(string firstName, string lastName)
        {
            string[] fn = firstName.ToLower().Split(' ');
            string[] ln = lastName.ToLower().Split(' ');
            string username = "";

            List<Student> students = GetList();
            List<string> DbUserNames = students.Select(_ => _.Username).ToList();

            foreach (var name in fn)
            {
                foreach (var lname in ln)
                {
                    var concat = string.Format($"{name}.{lname}");
                    if (!DbUserNames.Contains(concat))
                    {
                        username = concat; 
                        break;
                    }
                }
            }
            return username;
        }
    }
}
