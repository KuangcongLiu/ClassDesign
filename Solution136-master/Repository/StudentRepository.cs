namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class StudentRepository : BaseRepository, IStudentRepository
    {
        private const string InsertStudentProcedure = "spInsertStudent";
        private const string UpdateStudentProcedure = "spUpdateStudent";
        private const string DeleteStudentProcedure = "spDeleteStudent";
        private const string GetStudentListProcedure = "spGetStudentList";
        private const string GetStudentProcedure = "spGetStudent";



        public void InsertStudent(Student student, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertStudentProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@ssn", SqlDbType.VarChar, 9));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@shoe_size", SqlDbType.Float));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@weight", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = student.StudentId;
                adapter.SelectCommand.Parameters["@ssn"].Value = student.SSN;
                adapter.SelectCommand.Parameters["@first_name"].Value = student.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = student.LastName;
                adapter.SelectCommand.Parameters["@email"].Value = student.Email;
                adapter.SelectCommand.Parameters["@password"].Value = student.Password;
                adapter.SelectCommand.Parameters["@shoe_size"].Value = student.ShoeSize;
                adapter.SelectCommand.Parameters["@weight"].Value = student.Weight;

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

        public void UpdateStudent(Student student, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateStudentProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@ssn", SqlDbType.VarChar, 9));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@shoe_size", SqlDbType.Float));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@weight", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = student.StudentId;
                adapter.SelectCommand.Parameters["@ssn"].Value = student.SSN;
                adapter.SelectCommand.Parameters["@first_name"].Value = student.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = student.LastName;
                adapter.SelectCommand.Parameters["@email"].Value = student.Email;
                adapter.SelectCommand.Parameters["@password"].Value = student.Password;
                adapter.SelectCommand.Parameters["@shoe_size"].Value = student.ShoeSize;
                adapter.SelectCommand.Parameters["@weight"].Value = student.Weight;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
                System.Diagnostics.Debug.WriteLine("Error:"+ e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void DeleteStudent(Student student, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteStudentProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@student_id"].Value = student.StudentId;

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

        public List<Student> GetStudentList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var studentList = new List<Student>();

            try
            {
                var adapter = new SqlDataAdapter(GetStudentListProcedure, conn)
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
                    var student = new Student
                                      {
                                          StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                                          FirstName = dataSet.Tables[0].Rows[i]["first_name"].ToString(),
                                          LastName = dataSet.Tables[0].Rows[i]["last_name"].ToString(),
                                          SSN = dataSet.Tables[0].Rows[i]["ssn"].ToString(),
                                          Email = dataSet.Tables[0].Rows[i]["email"].ToString(),
                                          Password = dataSet.Tables[0].Rows[i]["password"].ToString(),
                                          ShoeSize =
                                              (float)
                                              Convert.ToDouble(dataSet.Tables[0].Rows[i]["shoe_size"].ToString()),
                                          Weight = Convert.ToInt32(dataSet.Tables[0].Rows[i]["weight"].ToString())
                                      };
                    studentList.Add(student);
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

            return studentList;
        }

        public Student GetStudent(string StudentId, ref List<string> errors) {
            var conn = new SqlConnection(ConnectionString);
            var result = new Student();
            
            try
            {
                var adapter = new SqlDataAdapter(GetStudentProcedure, conn)
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
               
                result = new Student()
                {
                    StudentId = dataSet.Tables[0].Rows[0]["student_id"].ToString(),
                    FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString(),
                    LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString(),
                    SSN = dataSet.Tables[0].Rows[0]["ssn"].ToString(),
                    Email = dataSet.Tables[0].Rows[0]["email"].ToString(),
                    Password = dataSet.Tables[0].Rows[0]["password"].ToString(),
                    ShoeSize =
                                            (float)
                                            Convert.ToDouble(dataSet.Tables[0].Rows[0]["shoe_size"].ToString()),
                    Weight = Convert.ToInt32(dataSet.Tables[0].Rows[0]["weight"].ToString())
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
