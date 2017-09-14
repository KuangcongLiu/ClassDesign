/*
namespace ServiceTest
{
    using System;
    using System.Collections.Generic;

    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;

    [TestClass]
    public class DepartmentServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertDepartmentErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IDepartmentRepository>();
            var DepartmentService = new DepartmentService(mockRepository.Object);

            //// Act
            DepartmentService.InsertDepartment(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertDepartmentErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IDepartmentRepository>();
            var departmentService = new DepartmentService(mockRepository.Object);
            var department = new Department { DepartmentId = -1 };

            //// Act
            departmentService.InsertDepartment(department, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertDepartmentErrorTest3()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IDepartmentRepository>();
            var departmentService = new DepartmentService(mockRepository.Object);
            var department = new Department { Name = "" };

            //// Act
            departmentService.InsertDepartment(department, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateDepartmentErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IDepartmentRepository>();
            var departmentService = new DepartmentService(mockRepository.Object);

            //// Act
            departmentService.UpdateDepartment(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateDepartmentErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IDepartmentRepository>();
            var departmentService = new DepartmentService(mockRepository.Object);
            var department = new Department { DepartmentId = -1 };

            //// Act
            departmentService.UpdateDepartment(department, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateDepartmentErrorTest3()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IDepartmentRepository>();
            var departmentService = new DepartmentService(mockRepository.Object);
            var department = new Department { Name = "" };

            //// Act
            departmentService.UpdateDepartment(department, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteDepartmentErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<IDepartmentRepository>();
            var departmentService = new DepartmentService(mockRepository.Object);

            //// Act
            departmentService.DeleteDepartment(-1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

    }
}
*/