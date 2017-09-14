namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using System.Text.RegularExpressions;
    using POCO;

    public class EnrollmentService
    {
        private readonly IEnrollmentRepository repository;

        public EnrollmentService(IEnrollmentRepository repository)
        {
            this.repository = repository;
        }

        public void InsertEnrollment(Enrollment enrollment, ref List<string> errors)
        {
            

            this.repository.InsertEnrollment(enrollment, ref errors);
        }

        public void UpdateEnrollment(Enrollment enrollment, ref List<string> errors)
        {
           

            this.repository.UpdateEnrollment(enrollment, ref errors);
        }

        public List<Enrollment> GetEnrollmentListByStudent(string StudentId, ref List<string> errors)
        {
           

            return this.repository.GetEnrollmentListByStudent(StudentId, ref errors);
        }

        public void DeleteEnrollment(Enrollment enrollment, ref List<string> errors)
        {
            this.repository.DeleteEnrollment(enrollment, ref errors);
        }

        public List<Enrollment> GetAllEnrollmentList(ref List<string> errors)
        {
            return this.repository.GetAllEnrollmentList(ref errors);
        }


        public Enrollment GetEnrollment(string StudentId, int ScheduleId, ref List<string> errors)
        {
            return this.repository.GetEnrollment(StudentId, ScheduleId ,ref errors);
        }
    }
}
