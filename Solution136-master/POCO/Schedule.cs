namespace POCO
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        public int Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }

        public int CourseId { get; set; }

        public int ScheduleDayId { get; set; }

        public int ScheduleTimeId { get; set; }

        public int InstructorId { get; set; }

        public override string ToString()
        {
            return this.ScheduleId + "-" + this.Year + "-" + this.Quarter + "-" + this.Session + "-" + this.CourseId+"-"
                 + this.ScheduleDayId + "-" + this.ScheduleTimeId + "-" + this.InstructorId;
        }
    }
}
