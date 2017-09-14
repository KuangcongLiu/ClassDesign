namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        private const string GetScheduleListProcedure = "spGetScheduleList";
        private const string GetScheduleProcedure = "spGetSchedule";
        private const string InsertScheduleProcedure = "spInsertSchedule";
        private const string UpdateScheduleProcedure = "spUpdateSchedule";
        private const string DeleteScheduleProcedure = "spDeleteSchedule";

        public List<Schedule> GetScheduleList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var scheduleList = new List<Schedule>();

            try
            {
                var adapter = new SqlDataAdapter(GetScheduleListProcedure, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var schedule = new Schedule
                    {
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"], 
                        Year = (int)dataSet.Tables[0].Rows[i]["year"], 
                        Quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString(), 
                        Session = dataSet.Tables[0].Rows[i]["session"].ToString(),
                        CourseId = (int)dataSet.Tables[0].Rows[i]["course_id"],
                        ScheduleDayId = (int)dataSet.Tables[0].Rows[i]["schedule_day_id"],
                        ScheduleTimeId = (int)dataSet.Tables[0].Rows[i]["schedule_time_id"],
                        InstructorId = (int)dataSet.Tables[0].Rows[i]["instructor_id"],

                    };
                    scheduleList.Add(schedule);
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

            return scheduleList;
        }


        public Schedule GetSchedule(int ScheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var result = new Schedule();

            try
            {
                var adapter = new SqlDataAdapter(GetScheduleProcedure, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@schedule_id"].Value = ScheduleId;


                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }


                result = new Schedule
                {
                    ScheduleId = (int)dataSet.Tables[0].Rows[0]["schedule_id"],
                    Year = (int)dataSet.Tables[0].Rows[0]["year"],
                    Quarter = dataSet.Tables[0].Rows[0]["quarter"].ToString(),
                    Session = dataSet.Tables[0].Rows[0]["session"].ToString(),
                    CourseId = (int)dataSet.Tables[0].Rows[0]["course_id"],
                    ScheduleDayId = (int)dataSet.Tables[0].Rows[0]["schedule_day_id"],
                    ScheduleTimeId = (int)dataSet.Tables[0].Rows[0]["schedule_time_id"],
                    InstructorId = (int)dataSet.Tables[0].Rows[0]["instructor_id"],

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


        public void InsertSchedule(Schedule schedule, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertScheduleProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@session", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@schedule_id"].Value = schedule.ScheduleId;
                adapter.SelectCommand.Parameters["@course_id"].Value = schedule.CourseId;
                adapter.SelectCommand.Parameters["@year"].Value = schedule.Year;
                adapter.SelectCommand.Parameters["@quarter"].Value = schedule.Quarter;
                adapter.SelectCommand.Parameters["@session"].Value = schedule.Session;
                adapter.SelectCommand.Parameters["@schedule_day_id"].Value = schedule.ScheduleDayId;
                adapter.SelectCommand.Parameters["@schedule_time_id"].Value = schedule.ScheduleTimeId;
                adapter.SelectCommand.Parameters["@instructor_id"].Value = schedule.InstructorId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
                System.Diagnostics.Debug.WriteLine("error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

        }


        public void UpdateSchedule(Schedule schedule, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateScheduleProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@session", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@schedule_id"].Value = schedule.ScheduleId;
                adapter.SelectCommand.Parameters["@course_id"].Value = schedule.CourseId;
                adapter.SelectCommand.Parameters["@year"].Value = schedule.Year;
                adapter.SelectCommand.Parameters["@quarter"].Value = schedule.Quarter;
                adapter.SelectCommand.Parameters["@session"].Value = schedule.Session;
                adapter.SelectCommand.Parameters["@schedule_day_id"].Value = schedule.ScheduleDayId;
                adapter.SelectCommand.Parameters["@schedule_time_id"].Value = schedule.ScheduleTimeId;
                adapter.SelectCommand.Parameters["@instructor_id"].Value = schedule.InstructorId;

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



        public void DeleteSchedule(Schedule schedule, ref List<string> errors)
        {
            System.Diagnostics.Debug.WriteLine("schedule id: " + schedule.ScheduleId);
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(DeleteScheduleProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@schedule_id"].Value = schedule.ScheduleId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("The error we have:");

                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
