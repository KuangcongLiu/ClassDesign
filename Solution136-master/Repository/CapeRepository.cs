namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using IRepository;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using POCO;
    public class CapeRepository : BaseRepository, ICapeRepository
    {
        private const string GetCapeProcedure = "spGetCape";
        private const string GetCapeListProcedure = "spGetCapeList";
        private const string InsertCapeProcedure = "spInsertCape";
        private const string UpdateCapeProcedure = "spUpdateCape";
        private const string DeleteCapeProcedure = "spDeleteCape";




        public List<Cape> GetCapeList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var capeList = new List<Cape>();

            try
            {
                var adapter = new SqlDataAdapter(GetCapeListProcedure, conn)
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
                    var cape = new Cape
                    {
                        CapeId = (int)dataSet.Tables[0].Rows[i]["cape_id"],
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        Rate = (int)dataSet.Tables[0].Rows[i]["rate"],
                        CapeDescription = dataSet.Tables[0].Rows[i]["cape_description"].ToString(),
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString()

                    };
                    capeList.Add(cape);
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

            return capeList;

        }

        public Cape GetCape(int CapeId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var result = new Cape();

            try
            {
                var adapter = new SqlDataAdapter(GetCapeProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@cape_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@cape_id"].Value = CapeId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                
                result = new Cape
                {
                    CapeId = (int)dataSet.Tables[0].Rows[0]["cape_id"],
                    ScheduleId = (int)dataSet.Tables[0].Rows[0]["schedule_id"],
                    Rate = (int)dataSet.Tables[0].Rows[0]["rate"],
                    CapeDescription = dataSet.Tables[0].Rows[0]["cape_description"].ToString(),
                    StudentId = dataSet.Tables[0].Rows[0]["student_id"].ToString()

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



        public void InsertCape(Cape cape, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertCapeProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@cape_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@rate", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@cape_description", SqlDbType.VarChar));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@cape_id"].Value = cape.CapeId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = cape.ScheduleId;
                adapter.SelectCommand.Parameters["@rate"].Value = cape.Rate;
                adapter.SelectCommand.Parameters["@cape_description"].Value = cape.CapeDescription;
                adapter.SelectCommand.Parameters["@student_id"].Value = cape.StudentId;

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

        public void DeleteCape(Cape cape, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteCapeProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@cape_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@cape_id"].Value = cape.CapeId;

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

        public void UpdateCape(Cape cape, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateCapeProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@cape_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@rate", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@cape_description", SqlDbType.VarChar));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@cape_id"].Value = cape.CapeId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = cape.ScheduleId;
                adapter.SelectCommand.Parameters["@rate"].Value = cape.Rate;
                adapter.SelectCommand.Parameters["@cape_description"].Value = cape.CapeDescription;
                adapter.SelectCommand.Parameters["@student_id"].Value = cape.StudentId;

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
