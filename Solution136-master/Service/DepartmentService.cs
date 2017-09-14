namespace Service
{
    using System.Collections.Generic;
    using IRepository;
    using POCO;
    using System;

    public class DepartmentService
    {
        private readonly IDepartmentRepository repository;

        public DepartmentService(IDepartmentRepository repository) {
            this.repository = repository;
        }

        public List<Department> GetDepartmentList(ref List<string> errors){
            return this.repository.GetDepartmentList(ref errors);
        }

        public Department GetDepartment(int DepartmentId, ref List<string> errors)
        {
            return this.repository.GetDepartment(DepartmentId, ref errors);
        }

        public void InsertDepartment(Department department, ref List<string> errors) {
            if (department == null){
                errors.Add("department cannnot be null when insert");
                return;
            }

            if (department.DepartmentId <= 0){
                errors.Add("department id cannot less than 1 when insert");
                return;
            }

            if (department.Name == ""){
                errors.Add("department name cannot be null when insert");
                return;
            }
            this.repository.InsertDepartment(department, ref errors);
        }

        public void UpdateDepartment(Department department, ref List<string> errors) {
            if (department == null){
                errors.Add("department cannnot be null when update");
                return;
            }

            if (department.DepartmentId <= 0){
                errors.Add("department id cannot less than 1 when update");
                return;
            }

            if (department.Name == ""){
                errors.Add("department name cannot be null when update");
                return;
            }

            this.repository.UpdateDepartment(department, ref errors);
        }

        public void DeleteDepartment(Department department, ref List<string> errors) {
            if (department== null) {
                errors.Add("department cannot be null");
                return;
            }
            this.repository.DeleteDepartment(department, ref errors);
        }
    }
}
