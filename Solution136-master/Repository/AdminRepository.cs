namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class AdminRepository : BaseRepository, IAdminRepository
    {

        private const string UpdateAdminProcedure = "spUpdateAdmin";

        private const string GetAdminProcedure = "spGetAdmin";



        public void UpdateAdmin(Admin admin, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateAdminProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
            

                adapter.SelectCommand.Parameters["@admin_id"].Value = admin.AdminId;
                adapter.SelectCommand.Parameters["@email"].Value = admin.Email;
                adapter.SelectCommand.Parameters["@password"].Value = admin.Password;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }




        public Admin GetAdmin(int AdminId, ref List<string> errors)
        {
            //System.Diagnostics.Debug.WriteLine("admin_id: "+admin.AdminId);
            var conn = new SqlConnection(ConnectionString);
            var result = new Admin();
            try
            {
                var adapter = new SqlDataAdapter(GetAdminProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@admin_id"].Value = AdminId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                result = new Admin()
                {
                    AdminId =(int) dataSet.Tables[0].Rows[0]["admin_id"],
                    Email = dataSet.Tables[0].Rows[0]["email"].ToString(),
                    Password = dataSet.Tables[0].Rows[0]["password"].ToString()
                };
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return result;
        }
    }
}
