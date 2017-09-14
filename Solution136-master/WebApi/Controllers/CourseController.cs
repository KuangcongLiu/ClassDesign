using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class CourseController : ApiController
    {
        [HttpGet]
        public List<Course> GetCourseList()
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();
            return service.GetCourseList(ref errors);
        }

        [HttpGet]
        public Course GetCourse(int CourseId)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();
            return service.GetCourse(CourseId, ref errors);
        }

        [HttpPost]
        public string InsertCourse(Course course)
        {
            var errors = new List<string>();
            var repository = new CourseRepository();
            var service = new CourseService(repository);
            service.InsertCourse(course, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateCourse(Course course)
        {
            var errors = new List<string>();
            var repository = new CourseRepository();
            var service = new CourseService(repository);
            service.UpdateCourse(course, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteCourse(Course course)
        {
            var errors = new List<string>();
            var repository = new CourseRepository();
            var service = new CourseService(repository);
            service.DeleteCourse(course, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }



    }
}