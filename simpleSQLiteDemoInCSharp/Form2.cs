using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace simpleSQLiteDemoInCSharp
{
    public partial class Form2 : Form
    {
        clsStudents students;
        String studentID = "";

        //Add Mode
        public Form2(clsStudents @students)
        {
            init(@students);
            lblStudentID.Text = "New Student Entry";
        }

        //Edit Mode
        public Form2(clsStudents @students, String studentID)
        {
            init(@students);
            this.studentID = studentID;
            lblStudentID.Text = this.studentID;
            DataTable dt = students.getStudent(studentID);
            txtFirstName.Text = dt.Rows[0]["firstName"].ToString();
            txtLastName.Text  = dt.Rows[0]["lastName"].ToString();
        }

        private void init(clsStudents students)
        {
            InitializeComponent();
            this.students = students;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (studentID == String.Empty)
            {
                //Add Mode
                students.insertStudent(txtFirstName.Text.Trim(), txtLastName.Text.Trim());
            }
            else
            {
                //Edit Mode
                students.updateStudent(this.studentID, txtFirstName.Text.Trim(), txtLastName.Text.Trim());
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
