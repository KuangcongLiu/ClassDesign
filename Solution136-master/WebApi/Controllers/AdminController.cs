namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;
    using System.Diagnostics;

    public class AdminController : ApiController
    {
        [HttpGet]
        public Admin GetAdmin(int AdminId)
        {
            //System.Diagnostics.Debug.WriteLine("admin_id" + admin.AdminId);
            var errors = new List<string>();
            var repository = new AdminRepository();
            var service = new AdminService(repository);            
            return service.GetAdmin(AdminId, ref errors);
        }


        [HttpPost]
        public string UpdateAdmin(Admin admin)
        {
            var errors = new List<string>();
            var repository = new AdminRepository();
            var service = new AdminService(repository);
            service.UpdateAdmin(admin, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}