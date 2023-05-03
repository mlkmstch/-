using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ToDolist1
{
    internal class Task
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public bool IsCompleted { get; set; }

        private string ConnectionString = "Data Source=DESKTOP-BIO9OQ1;Initial Catalog=ToDoAppDatabase;Integrated Security=True;TrustServerCertificate=True";
        public List<Task> getUserTasks(int UserID)
        {
            List<Task> taskList = new List<Task>();

            SqlConnection con = new SqlConnection(ConnectionString);

            string selectSql = "select TaskID, UserID, TaskTitle, TaskDescription, Deadline, Completed from GetUserTasks where UserID='" + UserID.ToString() + "'";

            con.Open();

            SqlCommand cmd = new SqlCommand(selectSql, con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Task task = new Task();

                task.TaskID = Convert.ToInt32(dr["TaskID"]);
                task.Title = dr["TaskTitle"].ToString();
                task.Description = dr["TaskDescription"].ToString();
                task.Deadline = dr["Deadline"].ToString();

                if (dr["Completed"].ToString() == "NULL")
                {
                    task.IsCompleted = false;
                }
                taskList.Add(task);
            }
            con.Close();
            return taskList;
        }

        public void AddTask(int UserID, Task task)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            
            SqlCommand cmd = new SqlCommand("AddTask", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
            cmd.Parameters.Add(new SqlParameter("@Title", task.Title));
            cmd.Parameters.Add(new SqlParameter("@Description", task.Description));
            cmd.Parameters.Add(new SqlParameter("@Deadline", Convert.ToDateTime(task.Deadline)));
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public Task GetUserTask(int UserID, int TaskID)
        {
            Task task = new Task();

            SqlConnection con = new SqlConnection(ConnectionString);

            string selectSql = "select TaskID, UserID, TaskTitle, TaskDescription, Deadline, Completed from GetUserTasks where UserID='" + UserID.ToString() + "' and TaskID='" + TaskID.ToString() + "'";
            con.Open();
            
            SqlCommand cmd = new SqlCommand(selectSql, con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                task.TaskID = Convert.ToInt32(dr["TaskID"]);
                task.Title = dr["TaskTitle"].ToString();
                task.Description = dr["TaskDescription"].ToString();
                task.Deadline = dr["Deadline"].ToString();
                if (dr["Completed"].ToString() == "NULL")
                {
                    task.IsCompleted = false;
                }
            }
            con.Close();
            return task;
        }
        public void EditUserTask(int UserID, Task task)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Updatetask", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@TaskID", task.TaskID));
            cmd.Parameters.Add(new SqlParameter("@Title", task.Title));
            cmd.Parameters.Add(new SqlParameter("@Description", task.Description));
            cmd.Parameters.Add(new SqlParameter("@Deadline", Convert.ToDateTime(task.Deadline)));
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteUserTask(int UserID, int TaskID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("DeleteUserTask", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@TaskID", UserID));
            cmd.Parameters.Add(new SqlParameter("@UserID", TaskID));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
