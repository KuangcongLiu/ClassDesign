/*
namespace WebApiTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using POCO;

    using WebApi.Controllers;

    /// <summary>
    /// department test cases
    /// </summary>
    [TestClass]
    public class DepartmentTest
    {
        [TestMethod]
        public void DepartmentInsertTest()
        {
            var department = new Department { DepartmentId = -1, Name = "CSE", Description = "CSE"};
            var departmentController = new DepartmentController();
            var insert = departmentController.InsertDepartment(department);
            Assert.AreEqual("error", insert);
        }

        [TestMethod]
        public void DepartmentInsertTest2()
        {
            var department = new Department { DepartmentId = 10, Name = "CSE", Description = "CSE" };
            var departmentController = new DepartmentController();
            var insert = departmentController.InsertDepartment(department);
            Assert.AreEqual("ok", insert);
        }
        
        [TestMethod]
        public void DepartmentUpdateTest()
        {
            var department = new Department { DepartmentId = -1, Name = "CSE", Description = "CSE" };
            var departmentController = new DepartmentController();
            var update = departmentController.UpdateDepartment(department);
            Assert.AreEqual("error", update);
        }

        [TestMethod]
        public void DepartmentUpdateTest2()
        {
            var department = new Department { DepartmentId = 10, Name = "CSE", Description = "Update description in test" };
            var departmentController = new DepartmentController();
            var update = departmentController.UpdateDepartment(department);
            Assert.AreEqual("ok", update);
        }
        
        [TestMethod]
        public void DepartmentDeleteTest()
        {
            var department = new Department { DepartmentId = -1, Name = "CSE", Description = "CSE" };
            var departmentController = new DepartmentController();
            var delete = departmentController.DeleteDepartment(department.DepartmentId);
            Assert.AreEqual("error", delete);
        }
        
        [TestMethod]
        public void DepartmentDeleteTest2()
        {
            var department = new Department { DepartmentId = 10, Name = "CSE", Description = "CSE" };
            var departmentController = new DepartmentController();
            var delete = departmentController.DeleteDepartment(department.DepartmentId);
            Assert.AreEqual("ok", delete);
        }

       
    }
}
*/