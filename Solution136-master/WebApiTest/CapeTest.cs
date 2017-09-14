/*
namespace WebApiTest
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using POCO;

    using WebApi.Controllers;
    [TestClass]
    public class CapeTest
    {
        [TestMethod]
        public void CapeInsertTest()
        {
            var cape = new Cape { CapeId = -10, ScheduleId = 100, Rate = 5, CapeDescription = "cape" };
            var capeController = new CapeController();
            var insert = capeController.InsertCape(cape);
            Assert.AreEqual("error", insert);
        }

        [TestMethod]
        public void CapeInsertTest2()
        {
            var cape = new Cape { CapeId = 10, ScheduleId = 100, Rate = 5, CapeDescription = "cape" };
            var capeController = new CapeController();
            var insert = capeController.InsertCape(cape);
            Assert.AreEqual("ok", insert);
        }

        [TestMethod]
        public void CapeUpdateTest()
        {
            var cape = new Cape { CapeId = -10, ScheduleId = 100, Rate = 5, CapeDescription = "cape" };
            var capeController = new CapeController();
            var update = capeController.UpdateCape(cape);
            Assert.AreEqual("error", update);
        }

        [TestMethod]
        public void CapeUpdateTest2()
        {
            var cape = new Cape { CapeId = 10, ScheduleId = 100, Rate = 5, CapeDescription = "cape" };
            var capeController = new CapeController();
            var update = capeController.UpdateCape(cape);
            Assert.AreEqual("ok", update);
        }

        [TestMethod]
        public void CapeDeleteTest()
        {
            var cape = new Cape { CapeId = -10, ScheduleId = 100, Rate = 5, CapeDescription = "cape" };
            var capeController = new CapeController();
            var delete = capeController.DeleteCape(cape.CapeId);
            Assert.AreEqual("error", delete);
        }

        [TestMethod]
        public void CapeDeleteTest2()
        {
            var cape = new Cape { CapeId = 10, ScheduleId = 100, Rate = 5, CapeDescription = "cape" };
            var capeController = new CapeController();
            var delete = capeController.DeleteCape(cape.CapeId);
            Assert.AreEqual("ok", delete);
        }


    }
}
*/