namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using System.Text.RegularExpressions;
    using POCO;

    public class StudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public void InsertStudent(Student student, ref List<string> errors)
        {
            System.Console.WriteLine("Lingfei");
            if (student == null)
            {
                errors.Add("Student cannot be null");
                return;
            }

            if (student.StudentId.Length < 5)
            {
                errors.Add("Invalid student ID");
                return;
            }

            if (!Regex.IsMatch(student.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add("Invalid student email");
                return;
            }

            this.repository.InsertStudent(student, ref errors);
        }

        public void UpdateStudent(Student student, ref List<string> errors)
        {
            if (student == null)
            {
                errors.Add("Student cannot be null");
                return;
            }

            if (string.IsNullOrEmpty(student.StudentId))
            {
                errors.Add("Invalid student id");
                return;
            }

            if (student.StudentId.Length < 5)
            {
                errors.Add("Invalid student id");
                return;
            }

            if (!Regex.IsMatch(student.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add("Invalid student email");
                return;
            }

            this.repository.UpdateStudent(student, ref errors);
        }

        public Student GetStudent(string StudentId, ref List<string> errors)
        {
            return this.repository.GetStudent(StudentId, ref errors);
        }

        public void DeleteStudent(Student student, ref List<string> errors)
        {
            if (student == null)
            {
                errors.Add("Invalid student");
                return;
            }

            this.repository.DeleteStudent(student, ref errors);
        }

        public List<Student> GetStudentList(ref List<string> errors)
        {
            return this.repository.GetStudentList(ref errors);
        }
    }
}
