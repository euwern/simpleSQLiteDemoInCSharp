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
    public partial class Form1 : Form
    {
        SQLiteConnection conn;
        clsStudents students;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(@"data source = ..\\..\\testdb.db");
            students = new clsStudents(conn);
            dataGridView1.DataSource = students.getAllStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new Form2(students).ShowDialog();
            loadGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index > -1)
            {
                String studentID = dataGridView1.Rows[index].Cells["studentID"].Value.ToString();
                new Form2(students, studentID).ShowDialog();
                loadGridView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int index = dataGridView1.CurrentCell.RowIndex;
            if (index > -1)
            {
                String studentID = dataGridView1.Rows[index].Cells["studentID"].Value.ToString();
                var results = MessageBox.Show("Are you sure you want to delete this record?",
                                "Delete Student", 
                                MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question);
                if (results == DialogResult.Yes)
                {
                    students.deleteStudent(studentID);
                    loadGridView();
                }
            }
        }

        private void loadGridView()
        {
            dataGridView1.DataSource = students.getAllStudents();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
