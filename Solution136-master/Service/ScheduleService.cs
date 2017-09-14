namespace Service
{
    using System.Collections.Generic;

    using IRepository;

    using POCO;

    public class ScheduleService
    {
        private readonly IScheduleRepository repository;

        public ScheduleService(IScheduleRepository repository)
        {
            this.repository = repository;
        }

        public void InsertSchedule(Schedule schedule, ref List<string> errors)
        {
            this.repository.InsertSchedule(schedule, ref errors);
        }

        public List<Schedule> GetScheduleList(ref List<string> errors)
        {
            return this.repository.GetScheduleList(ref errors);
        }

        public Schedule GetSchedule(int ScheduleId, ref List<string> errors)
        {
            return this.repository.GetSchedule(ScheduleId, ref errors);
        }

        public void UpdateSchedule(Schedule schedule, ref List<string> errors)
        {
            this.repository.UpdateSchedule(schedule, ref errors);
        }

        public void DeleteSchedule(Schedule schedule, ref List<string> errors)
        {
            this.repository.DeleteSchedule(schedule, ref errors);
        }
    }
}
