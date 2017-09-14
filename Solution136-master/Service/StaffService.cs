namespace Service
{
    using System.Collections.Generic;
    using IRepository;
    using POCO;
    using System;

    public class StaffService
    {
        private readonly IStaffRepository repository;

        public StaffService(IStaffRepository repository)
        {
            this.repository = repository;
        }


        public Staff GetStaff(int StaffId, ref List<string> errors)
        {
            return this.repository.GetStaff(StaffId, ref errors);
        }




        public void UpdateStaff(Staff staff, ref List<string> errors)
        {
            if (staff == null)
            {
                errors.Add("Staff cannot be null when update");
                return;
            }
            this.repository.UpdateStaff(staff, ref errors);
        }

    }
}
