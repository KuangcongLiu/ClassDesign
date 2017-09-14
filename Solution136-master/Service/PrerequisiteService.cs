namespace Service
{
    using System.Collections.Generic;
    using IRepository;
    using POCO;
    using System;

    public class PrerequisiteService
    {
        private readonly IPrerequisiteRepository repository;

        public PrerequisiteService(IPrerequisiteRepository repository)
        {
            this.repository = repository;
        }

        public List<Prerequisite> GetPrerequisiteList( ref List<string> errors)
        {
            return this.repository.GetPrerequisiteList( ref errors);
        }

        public Prerequisite GetPrerequisite(int PrerequisiteId, ref List<string> errors)
        {
            return this.repository.GetPrerequisite(PrerequisiteId, ref errors);
        }

        public void InsertPrerequisite(Prerequisite prerequisite, ref List<string> errors)
        {
            if (prerequisite == null){
                errors.Add("prerequisite cannnot be null when insert");
                return;
            }

            if (prerequisite.CourseId <= 0){
                errors.Add("course id cannot less than 1 when insert");
                return;
            }

            if (prerequisite.PrerequisiteId <= 0){
                errors.Add("prerequisite id cannot less than 1 when insert");
                return;
            }

            this.repository.InsertPrerequisite(prerequisite, ref errors);
        }

        public void UpdatePrerequisite(Prerequisite prerequisite, ref List<string> errors)
        {
            if (prerequisite == null){
                errors.Add("prerequisite cannnot be null when update");
                return;
            }

            if (prerequisite.CourseId <= 0){
                errors.Add("course id cannot less than 1 when update");
                return;
            }

            if (prerequisite.PrerequisiteId <= 0){
                errors.Add("prerequisite id cannot less than 1 when update");
                return;
            }

            this.repository.UpdatePrerequisite(prerequisite, ref errors);
        }

        public void DeletePrerequisite(Prerequisite prerequisite, ref List<string> errors)
        {
            if (prerequisite==null)
            {
                errors.Add("prerequisite cannot be null");
                return;
            }
            this.repository.DeletePrerequisite(prerequisite, ref errors);
        }
    }
}
