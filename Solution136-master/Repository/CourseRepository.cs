namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class CourseRepository : BaseRepository, ICourseRepository
    {
        private const string GetCourseListProcedure = "spGetCourseList";
        private const string GetCourseProcedure = "spGetCourse";
        private const string InsertCourseProcedure = "spInsertCourse";
        private const string UpdateCourseProcedure = "spUpdateCourse";
        private const string DeleteCourseProcedure = "spDeleteCourse";

        public List<Course> GetCourseList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var courseList = new List<Course>();

            try
            {
                var adapter = new SqlDataAdapter(GetCourseListProcedure, conn)
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
                    var course = new Course
                                     {
                                         CourseId = (int)dataSet.Tables[0].Rows[i]["course_id"],
                                         Title = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                                         CourseLevel =
                                             (CourseLevel)
                                             Enum.Parse(
                                                 typeof(CourseLevel),
                                                 dataSet.Tables[0].Rows[i]["course_level"].ToString()),
                                         Description = dataSet.Tables[0].Rows[i]["course_description"].ToString(),
                                         DepartmentId = (int)dataSet.Tables[0].Rows[i]["department_id"]
                                     };
                    courseList.Add(course);
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

            return courseList;
        }

        public Course GetCourse(int CourseId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var result = new Course();

            try
            {
                var adapter = new SqlDataAdapter(GetCourseProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@course_id"].Value = CourseId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                
                result = new Course
                {
                    CourseId = (int)dataSet.Tables[0].Rows[0]["course_id"],
                    Title = dataSet.Tables[0].Rows[0]["course_title"].ToString(),
                    CourseLevel =
                                            (CourseLevel)
                                            Enum.Parse(
                                                typeof(CourseLevel),
                                                dataSet.Tables[0].Rows[0]["course_level"].ToString()),
                    Description = dataSet.Tables[0].Rows[0]["course_description"].ToString(),
                    DepartmentId = (int)dataSet.Tables[0].Rows[0]["department_id"]
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


        public void InsertCourse(Course course, ref List<string> errors) {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertCourseProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                };
                
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_level", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_description", SqlDbType.VarChar));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@department_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@course_id"].Value = course.CourseId;
                adapter.SelectCommand.Parameters["@course_title"].Value = course.Title;
                adapter.SelectCommand.Parameters["@course_level"].Value = course.CourseLevel;
                adapter.SelectCommand.Parameters["@course_description"].Value = course.Description;
                adapter.SelectCommand.Parameters["@department_id"].Value = course.DepartmentId;

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

        public void UpdateCourse(Course course, ref List<string> errors) {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateCourseProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_level", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_description", SqlDbType.VarChar));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@department_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@course_id"].Value = course.CourseId;
                adapter.SelectCommand.Parameters["@course_title"].Value = course.Title;
                adapter.SelectCommand.Parameters["@course_level"].Value = course.CourseLevel;
                adapter.SelectCommand.Parameters["@course_description"].Value = course.Description;
                adapter.SelectCommand.Parameters["@department_id"].Value = course.DepartmentId;

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

        public void DeleteCourse(Course course, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteCourseProcedure, conn)
                {
                    SelectCommand =
                                          {
                                              CommandType =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@course_id"].Value = course.CourseId;

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
