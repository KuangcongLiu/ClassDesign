

namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;
    using System.Web.Http.Cors;

    public class StaffController : ApiController
    {
        [HttpGet]
        public Staff GetStaff(int StaffId)
        {
            System.Diagnostics.Debug.WriteLine("staffId: " + StaffId);
            var service = new StaffService(new StaffRepository());
            var errors = new List<string>();
            return service.GetStaff(StaffId, ref errors);
        }

        [HttpPost]
        public string UpdateStaff(Staff staff)
        {
            var errors = new List<string>();
            var repository = new StaffRepository();
            var service = new StaffService(repository);
            service.UpdateStaff(staff, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}