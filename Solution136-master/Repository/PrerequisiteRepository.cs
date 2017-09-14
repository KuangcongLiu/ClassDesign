namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class PrerequisiteRepository : BaseRepository, IPrerequisiteRepository
    {
        private const string GetPrerequisiteListProcedure = "spGetPrerequisiteList";
        private const string GetPrerequisiteProcedure = "spGetPrerequisite";
        private const string InsertPrerequisiteProcedure = "spInsertPrerequisite";
        private const string UpdatePrerequisiteProcedure = "spUpdatePrerequisite";
        private const string DeletePrerequisiteProcedure = "spDeletePrerequisite";

        public List<Prerequisite> GetPrerequisiteList( ref List<string> errors) {
            var conn = new SqlConnection(ConnectionString);
            var PrerequisiteList = new List<Prerequisite>();

            try
            {
                var adapter = new SqlDataAdapter(GetPrerequisiteListProcedure, conn)
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
                    var prerequisite = new Prerequisite
                    {
                        Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["id"].ToString()),
                        CourseId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["course_id"].ToString()),
                        
                        PrerequisiteId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["prerequisite_id"].ToString()),
                    };
                    PrerequisiteList.Add(prerequisite);
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

            return PrerequisiteList;
        }

        public Prerequisite GetPrerequisite(int Id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var result = new Prerequisite();

            try
            {
                var adapter = new SqlDataAdapter(GetPrerequisiteProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@id"].Value = Id;
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

    
                result = new Prerequisite
                {
                    Id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["id"].ToString()),
                    CourseId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["course_id"].ToString()),

                    PrerequisiteId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["prerequisite_id"].ToString()),
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

        public void InsertPrerequisite(Prerequisite prerequisite, ref List<string> errors) {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertPrerequisiteProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prerequisite_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@id"].Value = prerequisite.Id;
                adapter.SelectCommand.Parameters["@course_id"].Value = prerequisite.CourseId;
                adapter.SelectCommand.Parameters["@prerequisite_id"].Value = prerequisite.PrerequisiteId;

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
        public void UpdatePrerequisite(Prerequisite prerequisite, ref List<string> errors) {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdatePrerequisiteProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prerequisite_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@id"].Value = prerequisite.Id;
                adapter.SelectCommand.Parameters["@course_id"].Value = prerequisite.CourseId;
                adapter.SelectCommand.Parameters["@prerequisite_id"].Value = prerequisite.PrerequisiteId;

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
        public void DeletePrerequisite(Prerequisite prerequisite, ref List<string> errors) {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeletePrerequisiteProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@id"].Value = prerequisite.Id;

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
