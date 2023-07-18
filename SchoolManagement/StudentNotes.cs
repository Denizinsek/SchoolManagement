using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class StudentNotes : Form
    {
        public StudentNotes()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SchoolManagement;Integrated Security=True");
        public string number;
        private void StudentNotes_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT Name,Exam1,Exam2,Exam3,Project,Average,Status FROM LectureNotes\r\nINNER JOIN Lessons On LectureNotes.LessonID = Lessons.LessonID WHERE StudentID=@P1", conn);
            cmd.Parameters.AddWithValue("@p1", number);
            //this.Text = number.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
