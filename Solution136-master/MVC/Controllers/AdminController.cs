namespace MVC.Controllers
{
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        public ActionResult Index(int admin_id)
        {
            ViewBag.admin_id = admin_id;
            return this.View();
        }

        public ActionResult Edit(int admin_id)
        {
            ViewBag.admin_id = admin_id;
            return this.View();
        }

        public ActionResult StudentList()
        {
            return this.View();
        }

        public ActionResult EditStudent(string student_id)
        {
            ViewBag.student_id = student_id;
            return this.View();
        }

        public ActionResult InsertStudent()
        {
            return this.View();
        }

        public ActionResult DeleteStudent(string student_id)
        {
            ViewBag.student_id = student_id;
            return this.View();
        }

        public ActionResult CourseList()
        {
            return this.View();
        }

        public ActionResult EditCourse(int course_id) {
            ViewBag.course_id = course_id;
            return this.View();
        }

        public ActionResult InsertCourse() {
            return this.View();
        }

        public ActionResult DeleteCourse(int course_id) {
            ViewBag.course_id = course_id;
            return this.View();
        }

        public ActionResult PrerequisiteList()
        {
            return this.View();
        }

        public ActionResult EditPrerequisite(int id) {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult InsertPrerequisite() {
            return this.View();
        }

        public ActionResult DeletePrerequisite(int id) {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult DepartmentList()
        {
            return this.View();
        }

        public ActionResult EditDepartment(int department_id) {
            ViewBag.department_id = department_id;
            return this.View();
        }

        public ActionResult InsertDepartment()
        {
            return this.View();
        }

        public ActionResult DeleteDepartment(int department_id)
        {
            ViewBag.department_id = department_id;
            return this.View();
        }

        public ActionResult CapeList()
        {
            return this.View();
        }

        public ActionResult EditCape(int cape_id)
        {
            ViewBag.cape_id = cape_id;
            return this.View();
        }

        public ActionResult InsertCape()
        {
            return this.View();
        }

        public ActionResult DeleteCape(int cape_id)
        {
            ViewBag.cape_id = cape_id;
            return this.View();
        }

        public ActionResult AllEnrollmentList()
        {
            return this.View();
        }


        public ActionResult EditEnrollment(int schedule_id, string student_id)
        {
            ViewBag.schedule_id = schedule_id;
            ViewBag.student_id = student_id;
            return this.View();
        }

        public ActionResult DeleteEnrollment(int schedule_id, string student_id)
        {
            ViewBag.schedule_id = schedule_id;
            ViewBag.student_id = student_id;
            return this.View();
        }


        public ActionResult ScheduleList()
        {
            return this.View();
        }

        public ActionResult InsertSchedule()
        {
            return this.View();
        }

        public ActionResult EditSchedule(int schedule_id)
        {
            ViewBag.schedule_id = schedule_id;
            return this.View();
        }

        public ActionResult DeleteSchedule(int schedule_id)
        {
            ViewBag.schedule_id = schedule_id;
            return this.View();
        }
    }
}
