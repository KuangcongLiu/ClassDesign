namespace IRepository
{

    using System.Collections.Generic;

    using POCO;

    public interface IEnrollmentRepository
    {
        List<Enrollment> GetEnrollmentListByStudent(string StudentId, ref List<string> errors);
        List<Enrollment> GetAllEnrollmentList(ref List<string> errors);

        Enrollment GetEnrollment(string StudentId, int ScheduleId, ref List<string> errors);

        void InsertEnrollment(Enrollment enrollment, ref List<string> errors);

        void DeleteEnrollment(Enrollment enrollment, ref List<string> errors);

        void UpdateEnrollment(Enrollment enrollment, ref List<string> errors);
    }
}
