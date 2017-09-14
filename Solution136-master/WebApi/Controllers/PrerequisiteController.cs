namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;
    using System.Diagnostics;
    public class PrerequisiteController : ApiController
    {
       
        [HttpGet]
        public List<Prerequisite> GetPrerequisiteList()
        {
            var service = new PrerequisiteService(new PrerequisiteRepository());
            var errors = new List<string>();
            return service.GetPrerequisiteList(ref errors);
        }

        [HttpGet]
        public Prerequisite GetPrerequisite(int Id)
        {
            var service = new PrerequisiteService(new PrerequisiteRepository());
            var errors = new List<string>();
            return service.GetPrerequisite(Id, ref errors);
        }

        [HttpPost]
        public string InsertPrerequisite(Prerequisite prerequisite)
        {
            var errors = new List<string>();
            var repository = new PrerequisiteRepository();
            var service = new PrerequisiteService(repository);
            service.InsertPrerequisite(prerequisite, ref errors);
            //Debug.WriteLine(errors[0]);
            if (errors.Count == 0)
            {
                return "ok";
            }


            return "error";
        }

        [HttpPost]
        public string UpdatePrerequisite(Prerequisite prerequisite)
        {
            var errors = new List<string>();
            var repository = new PrerequisiteRepository();
            var service = new PrerequisiteService(repository);
            service.UpdatePrerequisite(prerequisite, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeletePrerequisite(Prerequisite prerequisite)
        {
            var errors = new List<string>();
            var repository = new PrerequisiteRepository();
            var service = new PrerequisiteService(repository);
            service.DeletePrerequisite(prerequisite, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}