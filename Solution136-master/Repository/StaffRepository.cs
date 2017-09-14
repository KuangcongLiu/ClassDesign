namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class StaffRepository : BaseRepository, IStaffRepository
    {

        private const string UpdateStaffProcedure = "spUpdateStaff";

        private const string GetStaffProcedure = "spGetStaff";



        public void UpdateStaff(Staff staff, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateStaffProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@staff_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));


                adapter.SelectCommand.Parameters["@staff_id"].Value = staff.StaffId;
                adapter.SelectCommand.Parameters["@email"].Value = staff.Email;
                adapter.SelectCommand.Parameters["@password"].Value = staff.Password;

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




        public Staff GetStaff(int StaffId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var result = new Staff();
            try
            {
                var adapter = new SqlDataAdapter(GetStaffProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@staff_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@staff_id"].Value = StaffId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                result = new Staff()
                {
                    StaffId = (int)dataSet.Tables[0].Rows[0]["staff_id"],
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
