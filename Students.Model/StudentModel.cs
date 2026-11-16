using System;
using System.Collections.Generic;
using System.Linq;
using Students.Model;

namespace Students.Model
{
   
    public class StudentModel
    {
        private readonly List<Student> _students;
        private int _nextId = 1;

        public StudentModel()
        {
            _students = new List<Student>();
        }

        public IReadOnlyList<Student> GetAllStudents()
        {
            return _students.AsReadOnly();
        }

        public void AddStudent(string firstName, string lastName, string group)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Имя не может быть пустым", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Фамилия не может быть пустым", nameof(lastName));
            if (string.IsNullOrWhiteSpace(group))
                throw new ArgumentException("Группа не может быть пустым", nameof(group));

            var student = new Student
            {
                Id = _nextId++,
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                Group = group.Trim()
            };

            _students.Add(student);
        }

        public void RemoveStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _students.Remove(student);
            }
            else
            {
                throw new ArgumentException($"Студент с ID {id} не найден", nameof(id));
            }
        }
    }
}
