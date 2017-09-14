

namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;
    using System.Web.Http.Cors;

    public class ScheduleController : ApiController
    {
        [HttpGet]
        public List<Schedule> GetScheduleList()
        {
            var service = new ScheduleService(new ScheduleRepository());
            var errors = new List<string>();
            return service.GetScheduleList(ref errors);
        }

        [HttpGet]
        public Schedule GetSchedule(int ScheduleId)
        {
            var service = new ScheduleService(new ScheduleRepository());
            var errors = new List<string>();
            return service.GetSchedule(ScheduleId, ref errors);
        }

        [HttpPost]
        public string InsertSchedule(Schedule schedule)
        {
            System.Diagnostics.Debug.WriteLine("schedule id: " + schedule.ScheduleId);
            var errors = new List<string>();
            var repository = new ScheduleRepository();
            var service = new ScheduleService(repository);
            service.InsertSchedule(schedule, ref errors);
            //System.Diagnostics.Debug.WriteLine(errors[0]);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateSchedule(Schedule schedule)
        {
            System.Diagnostics.Debug.WriteLine("id: " + schedule.ScheduleId);
            var errors = new List<string>();
            var repository = new ScheduleRepository();
            var service = new ScheduleService(repository);
            service.UpdateSchedule(schedule, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteSchedule(Schedule schedule)
        {
            var errors = new List<string>();
            var repository = new ScheduleRepository();
            var service = new ScheduleService(repository);
            service.DeleteSchedule(schedule, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }



    }
}