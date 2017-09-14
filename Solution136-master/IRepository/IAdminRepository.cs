namespace IRepository
{
    using System.Collections.Generic;
    using POCO;

    public interface IAdminRepository
    {
        

        void UpdateAdmin(Admin admin, ref List<string> errors);

        Admin GetAdmin(int AdminID, ref List<string> errors);
    }
}
