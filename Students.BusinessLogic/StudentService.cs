using System;
using System.Collections.Generic;
using System.Linq;
using Students.Model;

namespace Students.BusinessLogic
{
    public class StudentService
    {
        private readonly List<Student> _students = new List<Student>();
        private int _nextId = 1;

        public List<Student> GetAll()
        {
            return _students.ToList(); // Возвращаем копию, чтобы защитить внутренний список
        }

        public void Add(string firstName, string lastName, string group)
        {
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(group))
            {
                throw new ArgumentException("Все поля студента должны быть заполнены!");
            }

            var newStudent = new Student
            {
                Id = _nextId++,
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                Group = group.Trim()
            };

            _students.Add(newStudent);
        }

        public void Remove(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _students.Remove(student);
            }
            else
            {
                throw new InvalidOperationException("Студент с таким ID не найден.");
            }
        }
    }
}
