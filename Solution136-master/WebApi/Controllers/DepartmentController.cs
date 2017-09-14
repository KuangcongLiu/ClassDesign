using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class DepartmentController : ApiController
    {
        [HttpGet]
        public List<Department> GetDepartmentList()
        {
            var service = new DepartmentService(new DepartmentRepository());
            var errors = new List<string>();
            return service.GetDepartmentList(ref errors);
        }

        [HttpGet]
        public Department GetDepartment(int DepartmentId)
        {
            var service = new DepartmentService(new DepartmentRepository());
            var errors = new List<string>();
            return service.GetDepartment(DepartmentId, ref errors);
        }

        [HttpPost]
        public string InsertDepartment(Department department)
        {
            var errors = new List<string>();
            var repository = new DepartmentRepository();
            var service = new DepartmentService(repository);
            service.InsertDepartment(department, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateDepartment(Department department)
        {
            System.Diagnostics.Debug.WriteLine("testing: "+department.DepartmentId);
            var errors = new List<string>();
            var repository = new DepartmentRepository();
            var service = new DepartmentService(repository);
            service.UpdateDepartment(department, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteDepartment(Department department)
        {
            var errors = new List<string>();
            var repository = new DepartmentRepository();
            var service = new DepartmentService(repository);
            service.DeleteDepartment(department, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }



    }
}