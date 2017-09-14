/*
namespace WebApiTest
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using POCO;

    using WebApi.Controllers;
    [TestClass]
    public class PrerequisiteTest
    {
        [TestMethod]
        public void PrerequisiteInsertTest()
        {
            var prerequisite = new Prerequisite { Id = -10, CourseId = 1, PrerequisiteId = 2};
            var prerequisiteController = new PrerequisiteController();
            var insert = prerequisiteController.InsertPrerequisite(prerequisite);
            Assert.AreEqual("error", insert);
        }

        [TestMethod]
        public void PrerequisiteInsertTest2()
        {
            var prerequisite = new Prerequisite { Id = 10, CourseId = 1, PrerequisiteId = 2 };
            var prerequisiteController = new PrerequisiteController();
            var insert = prerequisiteController.InsertPrerequisite(prerequisite);
            Assert.AreEqual("ok", insert);
        }

        [TestMethod]
        public void PrerequisiteUpdateTest()
        {
            var prerequisite = new Prerequisite { Id = -10, CourseId = 1, PrerequisiteId = 2 };
            var prerequisiteController = new PrerequisiteController();
            var update = prerequisiteController.UpdatePrerequisite(prerequisite);
            Assert.AreEqual("error", update);
        }

        [TestMethod]
        public void PrerequisiteUpdateTest2()
        {
            var prerequisite = new Prerequisite { Id = 10, CourseId = 1, PrerequisiteId = 2 };
            var prerequisiteController = new PrerequisiteController();
            var update = prerequisiteController.UpdatePrerequisite(prerequisite);
            Assert.AreEqual("ok", update);
        }

        [TestMethod]
        public void PrerequisiteDeleteTest()
        {
            var prerequisite = new Prerequisite { Id = -10, CourseId = 1, PrerequisiteId = 2 };
            var prerequisiteController = new PrerequisiteController();
            var delete = prerequisiteController.DeletePrerequisite(prerequisite.Id);
            Assert.AreEqual("error", delete);
        }

        [TestMethod]
        public void PrerequisiteDeleteTest2()
        {
            var prerequisite = new Prerequisite { Id = 10, CourseId = 1, PrerequisiteId = 2 };
            var prerequisiteController = new PrerequisiteController();
            var delete = prerequisiteController.DeletePrerequisite(prerequisite.Id);
            Assert.AreEqual("ok", delete);
        }

    }
}
*/