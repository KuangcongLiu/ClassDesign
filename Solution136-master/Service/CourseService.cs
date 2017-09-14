namespace Service
{
    using System.Collections.Generic;
    using IRepository;
    using POCO;
    using System;

    public class CourseService
    {
        private readonly ICourseRepository repository;

        public CourseService(ICourseRepository repository){
            this.repository = repository;
        }


        public List<Course> GetCourseList(ref List<string> errors)
        {
            return this.repository.GetCourseList(ref errors);
        }

        public Course GetCourse(int CourseId, ref List<string> errors)
        {
            return this.repository.GetCourse(CourseId, ref errors);
        }


        public void InsertCourse(Course course, ref List<string> errors) {
            if (course == null) {
                errors.Add("course cannnot be null when insert");
                return;
            }

            if (course.CourseId <= 0) {
                errors.Add("course id cannot less than 1 when insert");
                return;
            }

            if (course.Title == ""){
                errors.Add("course title cannot be null when insert");
                return;
            }

            if (course.DepartmentId <= 0){
                errors.Add("course department id cannot be less than 1 when insert");
                return;
            }
            this.repository.InsertCourse(course, ref errors);
        }

        public void UpdateCourse(Course course, ref List<string> errors) {
            if (course == null){
                errors.Add("course cannot be null when update");
                return;
            }

            if (course.CourseId <= 0){
                errors.Add("course id cannot less than 1 when udpate");
                return;
            }

            if (course.Title == ""){
                errors.Add("course title cannot be null when update");
                return;
            }

            if (course.DepartmentId <=0){
                errors.Add("course department id cannot be less than 1 when update");
                return;
            }

            this.repository.UpdateCourse(course, ref errors);
        }

        public void DeleteCourse(Course course, ref List<string> errors) {
            if (course==null) {
                errors.Add("course cannot be null");
                return;
            }
            this.repository.DeleteCourse(course, ref errors);
        }
    }
}
