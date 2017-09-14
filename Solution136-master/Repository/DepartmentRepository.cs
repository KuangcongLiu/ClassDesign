namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        private const string GetDepartmentListProcedure = "spGetDepartmentList";
        private const string GetDepartmentProcedure = "spGetDepartment";
        private const string InsertDepartmentProcedure = "spInsertDepartment";
        private const string UpdateDepartmentProcedure = "spUpdateDepartment";
        private const string DeleteDepartmentProcedure = "spDeleteDepartment";

        public List<Department> GetDepartmentList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var DepartmentList = new List<Department>();

            try
            {
                var adapter = new SqlDataAdapter(GetDepartmentListProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var Department = new Department
                    {
                        DepartmentId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["department_id"].ToString()),
                        Name = dataSet.Tables[0].Rows[i]["department_name"].ToString(),
                        Description = dataSet.Tables[0].Rows[i]["department_description"].ToString()
                    };
                    DepartmentList.Add(Department);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return DepartmentList;
        }

        public Department GetDepartment(int DepartmentId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var result = new Department();

            try
            {
                var adapter = new SqlDataAdapter(GetDepartmentProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@department_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@department_id"].Value = DepartmentId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

         
                result = new Department
                {
                    DepartmentId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["department_id"].ToString()),
                    Name = dataSet.Tables[0].Rows[0]["department_name"].ToString(),
                    Description = dataSet.Tables[0].Rows[0]["department_description"].ToString()
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

        public void InsertDepartment(Department department, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertDepartmentProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@department_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@department_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@department_description", SqlDbType.VarChar));
  
                adapter.SelectCommand.Parameters["@department_id"].Value = department.DepartmentId;
                adapter.SelectCommand.Parameters["@department_name"].Value = department.Name;
                adapter.SelectCommand.Parameters["@department_description"].Value = department.Description;

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

        public void UpdateDepartment(Department department, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateDepartmentProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@department_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@department_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@department_description", SqlDbType.VarChar));

                adapter.SelectCommand.Parameters["@department_id"].Value = department.DepartmentId;
                adapter.SelectCommand.Parameters["@department_name"].Value = department.Name;
                adapter.SelectCommand.Parameters["@department_description"].Value = department.Description;

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

        public void DeleteDepartment(Department department, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteDepartmentProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@department_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@department_id"].Value = department.DepartmentId;

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
    }

}
