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
    public class CapeServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertCourseErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);

            //// Act
            capeService.InsertCape(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertCapeErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);
            var cape = new Cape{ CapeId = -1 };

            //// Act
            capeService.InsertCape(cape, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertCapeErrorTest3()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);
            var cape = new Cape { ScheduleId = -1 };

            //// Act
            capeService.InsertCape(cape, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateCapeErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);

            //// Act
            capeService.UpdateCape(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateCapeErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);
            var cape = new Cape { CapeId = -1 };

            //// Act
            capeService.UpdateCape(cape, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateCapeErrorTest3()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);
            var cape = new Cape { ScheduleId = -1 };

            //// Act
            capeService.UpdateCape(cape, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteCapeErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ICapeRepository>();
            var capeService = new CapeService(mockRepository.Object);

            //// Act
            capeService.DeleteCape(-1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

    }
}
*/