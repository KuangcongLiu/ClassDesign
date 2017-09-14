namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ICourseRepository
    {
        List<Course> GetCourseList(ref List<string> errors);
        Course GetCourse(int CourseId, ref List<string> errors);
        void InsertCourse(Course course, ref List<string> errors);
        void UpdateCourse(Course course, ref List<string> errors);
        void DeleteCourse(Course course, ref List<string> errors);
    }
}
