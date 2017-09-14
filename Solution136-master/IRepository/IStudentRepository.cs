namespace IRepository
{
    using System.Collections.Generic;
    using POCO;

    public interface IStudentRepository
    {
        void InsertStudent(Student student, ref List<string> errors);

        void UpdateStudent(Student student, ref List<string> errors);

        void DeleteStudent(Student student, ref List<string> errors);

        List<Student> GetStudentList(ref List<string> errors);
        Student GetStudent(string StudentId, ref List<string> errors);
    }
}
