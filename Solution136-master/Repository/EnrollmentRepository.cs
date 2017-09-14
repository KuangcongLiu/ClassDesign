

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
    public class EnrollmentRepository : BaseRepository, IEnrollmentRepository
    {
        private const string GetEnrollmentListByStudentProcedure = "spGetEnrollmentListByStudent";
        private const string GetAllEnrollmentListProcedure = "spGetAllEnrollmentList";
        private const string InsertEnrollmentProcedure = "spInsertEnrollment";
        private const string UpdateEnrollmentProcedure = "spUpdateEnrollment";
        private const string DeleteEnrollmentProcedure = "spDeleteEnrollment";
        private const string GetEnrollmentProcedure = "spGetEnrollment";

        public List<Enrollment> GetAllEnrollmentList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var enrollmentList = new List<Enrollment>();

            try
            {
                var adapter = new SqlDataAdapter(GetAllEnrollmentListProcedure, conn)
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
                    var enrollment = new Enrollment
                    {
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        Grade = dataSet.Tables[0].Rows[i]["grade"].ToString()

                    };
                    enrollmentList.Add(enrollment);
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

            return enrollmentList;

        }

        public List<Enrollment> GetEnrollmentListByStudent(string StudentId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var enrollmentList = new List<Enrollment>();

            try
            {
                var adapter = new SqlDataAdapter(GetEnrollmentListByStudentProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters["@student_id"].Value = StudentId;
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var enrollment = new Enrollment
                    {
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        Grade = dataSet.Tables[0].Rows[i]["grade"].ToString()

                    };
                    enrollmentList.Add(enrollment);
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

            return enrollmentList;

        }


        public Enrollment GetEnrollment(string StudentId, int ScheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var result = new Enrollment();

            try
            {
                var adapter = new SqlDataAdapter(GetEnrollmentProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@student_id"].Value = StudentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = ScheduleId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }


                    result = new Enrollment
                    {
                        StudentId = dataSet.Tables[0].Rows[0]["student_id"].ToString(),
                        ScheduleId = (int)dataSet.Tables[0].Rows[0]["schedule_id"],
                        Grade = dataSet.Tables[0].Rows[0]["grade"].ToString()

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


        public void InsertEnrollment(Enrollment enrollment, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertEnrollmentProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@grade", SqlDbType.VarChar, 10));

                adapter.SelectCommand.Parameters["@student_id"].Value = enrollment.StudentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = enrollment.ScheduleId;
                adapter.SelectCommand.Parameters["@grade"].Value = enrollment.Grade;

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

        public void DeleteEnrollment(Enrollment enrollment, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteEnrollmentProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@schedule_id"].Value = enrollment.ScheduleId;
                adapter.SelectCommand.Parameters["@student_id"].Value = enrollment.StudentId;

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

        public void UpdateEnrollment(Enrollment enrollment, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateEnrollmentProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@grade", SqlDbType.VarChar, 10));

                adapter.SelectCommand.Parameters["@student_id"].Value = enrollment.StudentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = enrollment.ScheduleId;
                adapter.SelectCommand.Parameters["@grade"].Value = enrollment.Grade;

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
