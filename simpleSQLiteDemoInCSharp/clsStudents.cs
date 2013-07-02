using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace simpleSQLiteDemoInCSharp
{
    public class clsStudents : clsModel
    {
        public clsStudents(SQLiteConnection @conn) : base(@conn) { }

        public DataTable getAllStudents()
        {
            DataTable dt = new DataTable();
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Students";
            SQLiteDataAdapter db = new SQLiteDataAdapter(command);
            db.Fill(dt);
            return dt;
        }

        public DataTable getStudent(String @studentID)
        {
            DataTable dt = new DataTable();
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Students WHERE studentID = @studentID";
            //To Prevent SQL injection, all user input will be parameterized.
            command.Parameters.Add(new SQLiteParameter("@studentID", @studentID));
            SQLiteDataAdapter db = new SQLiteDataAdapter(command);
            db.Fill(dt);
            return dt;
        }

        public void insertStudent(String @firstName, String @lastName)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText = "INSERT into Students (firstName,lastName) VALUES(@firstName , @lastName)";
            command.Parameters.Add(new SQLiteParameter("@firstName", @firstName));
            command.Parameters.Add(new SQLiteParameter("@lastName", @lastName));
            command.ExecuteNonQuery();
        }

        public void updateStudent(String @studentID, String @firstName, String @lastName)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE Students SET firstName = @firstName, lastName = @lastName WHERE studentID = @studentID";
            command.Parameters.Add(new SQLiteParameter("@studentID", @studentID));
            command.Parameters.Add(new SQLiteParameter("@firstName", @firstName));
            command.Parameters.Add(new SQLiteParameter("@lastName" , @lastName));
            command.ExecuteNonQuery();
        }

        public void deleteStudent(String @studentID)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM Students WHERE studentID = @studentID";
            command.Parameters.Add(new SQLiteParameter("@studentID", @studentID));
            command.ExecuteNonQuery();
        }

    }
}
