namespace Service
{
    using System.Collections.Generic;
    using IRepository;
    using POCO;
    using System;

    public class AdminService
    {
        private readonly IAdminRepository repository;

        public AdminService(IAdminRepository repository)
        {
            this.repository = repository;
        }


        public Admin GetAdmin(int AdminId, ref List<string> errors)
        {
            return this.repository.GetAdmin(AdminId, ref errors);
        }




        public void UpdateAdmin(Admin admin, ref List<string> errors)
        {
            if (admin == null)
            {
                errors.Add("Admin cannot be null when update");
                throw new ArgumentException();
            }
            this.repository.UpdateAdmin(admin, ref errors);
        }

    }
}
