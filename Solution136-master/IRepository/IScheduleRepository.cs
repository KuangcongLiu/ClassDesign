namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IScheduleRepository
    {
        List<Schedule> GetScheduleList(ref List<string> errors);
        Schedule GetSchedule(int ScheduleId, ref List<string> errors);
        void InsertSchedule(Schedule schedule, ref List<string> errors);
        void UpdateSchedule(Schedule schedule, ref List<string> errors);
        void DeleteSchedule(Schedule schedule, ref List<string> errors);
    }
}
