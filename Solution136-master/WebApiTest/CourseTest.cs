/*
namespace WebApiTest
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using POCO;

    using WebApi.Controllers;
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CourseInsertTest()
        {
            var course = new Course { CourseId =110, DepartmentId = -1, Title = "CSE course", CourseLevel= CourseLevel.lower, Description = "CSE course" };
            var courseController = new CourseController();
            var insert = courseController.InsertCourse(course);
            Assert.AreEqual("error", insert);
        }

        [TestMethod]
        public void CourseInsertTest2()
        {
            var course = new Course { CourseId = 110, DepartmentId = 1, Title = "CSE course", CourseLevel = CourseLevel.lower, Description = "CSE course" };
            var courseController = new CourseController();
            var insert = courseController.InsertCourse(course);
            Assert.AreEqual("ok", insert);
        }

        [TestMethod]
        public void CourseUpdateTest()
        {
            var course = new Course { CourseId = 110, DepartmentId = -1, Title = "CSE course update", CourseLevel = CourseLevel.lower, Description = "CSE course" };
            var courseController = new CourseController();
            var update = courseController.UpdateCourse(course);
            Assert.AreEqual("error", update);
        }

        [TestMethod]
        public void CourseUpdateTest2()
        {
            var course = new Course { CourseId = 110, DepartmentId = 1, Title = "CSE course update", CourseLevel = CourseLevel.lower, Description = "CSE course" };
            var courseController = new CourseController();
            var update = courseController.UpdateCourse(course);
            Assert.AreEqual("ok", update);
        }

        [TestMethod]
        public void CourseDeleteTest()
        {
            var course = new Course { CourseId = -110, DepartmentId = 1, Title = "CSE course delete", CourseLevel = CourseLevel.lower, Description = "CSE course" };
            var courseController = new CourseController();
            var delete = courseController.DeleteCourse(course.CourseId);
            Assert.AreEqual("error", delete);
        }

        [TestMethod]
        public void CourseDeleteTest2()
        {
            var course = new Course { CourseId = 110, DepartmentId = 1, Title = "CSE course update", CourseLevel = CourseLevel.lower, Description = "CSE course" };
            var courseController = new CourseController();
            var delete = courseController.DeleteCourse(course.CourseId);
            Assert.AreEqual("ok", delete);
        }
    }
}
*/