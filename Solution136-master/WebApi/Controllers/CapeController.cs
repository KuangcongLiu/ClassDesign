using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class CapeController : ApiController
    {
        [HttpGet]
        public List<Cape> GetCapeList()
        {
            var service = new CapeService(new CapeRepository());
            var errors = new List<string>();
            return service.GetCapeList(ref errors);
        }

        [HttpGet]
        public Cape GetCape(int CapeId)
        {
            //System.Diagnostics.Debug.WriteLine("cape_id" + cape.CapeId);
            var service = new CapeService(new CapeRepository());
            var errors = new List<string>();
            return service.GetCape(CapeId, ref errors);
        }

        [HttpPost]
        public string InsertCape(Cape cape)
        {
            var errors = new List<string>();
            var repository = new CapeRepository();
            var service = new CapeService(repository);
            service.InsertCape(cape, ref errors);
            //System.Diagnostics.Debug.WriteLine(errors[0]);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateCape(Cape cape)
        {
            var errors = new List<string>();
            var repository = new CapeRepository();
            var service = new CapeService(repository);
            service.UpdateCape(cape, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteCape(Cape cape)
        {
            var errors = new List<string>();
            var repository = new CapeRepository();
            var service = new CapeService(repository);
            service.DeleteCape(cape, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }



    }
}