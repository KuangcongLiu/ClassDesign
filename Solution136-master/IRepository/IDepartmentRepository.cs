namespace IRepository
{
    using System.Collections.Generic;
    using POCO;

    public interface IDepartmentRepository
    {
        List<Department> GetDepartmentList(ref List<string> errors);
        Department GetDepartment(int DepartmentId, ref List<string> errors);
        void InsertDepartment(Department department, ref List<string> errors);
        void UpdateDepartment(Department department, ref List<string> errors);
        void DeleteDepartment(Department department, ref List<string> errors);
    }
}
