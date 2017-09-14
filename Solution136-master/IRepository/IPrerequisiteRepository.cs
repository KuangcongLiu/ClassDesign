namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IPrerequisiteRepository
    {
        List<Prerequisite> GetPrerequisiteList(ref List<string> errors);
        Prerequisite GetPrerequisite(int PrerequisiteId, ref List<string> errors);
        void InsertPrerequisite(Prerequisite prerequisite, ref List<string> errors);
        void UpdatePrerequisite(Prerequisite prerequisite, ref List<string> errors);
        void DeletePrerequisite(Prerequisite prerequisite, ref List<string> errors);
    }
}

