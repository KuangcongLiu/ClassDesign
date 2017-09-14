using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;
    using System.Diagnostics;

    public class EnrollmentController : ApiController
    {
        [HttpGet]
        public List<Enrollment> GetAllEnrollmentList()
        {
            var service = new EnrollmentService(new EnrollmentRepository());
            var errors = new List<string>();
            return service.GetAllEnrollmentList(ref errors);
        }

        [HttpGet]
        public Enrollment GetEnrollment(string StudentId, int ScheduleId)
        {
            var service = new EnrollmentService(new EnrollmentRepository());
            var errors = new List<string>();
            return service.GetEnrollment(StudentId, ScheduleId,ref errors);
        }

        [HttpGet]
        public List<Enrollment> GetEnrollmentByStudentList(string StudentId)
        {
            var service = new EnrollmentService(new EnrollmentRepository());
            var errors = new List<string>();
            return service.GetEnrollmentListByStudent(StudentId, ref errors);
        }

        [HttpPost]
        public string InsertEnrollment(Enrollment enrollment)
        {
            var errors = new List<string>();
            var repository = new EnrollmentRepository();
            var service = new EnrollmentService(repository);
            service.InsertEnrollment(enrollment, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateEnrollment(Enrollment enrollment)
        {
            var errors = new List<string>();
            var repository = new EnrollmentRepository();
            var service = new EnrollmentService(repository);
            service.UpdateEnrollment(enrollment, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteEnrollment(Enrollment enrollment)
        {
            //System.Diagnostics.Debug.WriteLine(enrollment.StudentId + " !!!!!!!!!!!!!!!   " + enrollment.ScheduleId + "!!!!!!!!!");
            var errors = new List<string>();
            var repository = new EnrollmentRepository();
            var service = new EnrollmentService(repository);
            service.DeleteEnrollment(enrollment, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }



    }
}