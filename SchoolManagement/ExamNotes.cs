using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class ExamNotes : Form
    {
        public ExamNotes()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SchoolManagement;Integrated Security=True");

        DataSet1TableAdapters.LectureNotesTableAdapter ds = new DataSet1TableAdapters.LectureNotesTableAdapter();

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NoteList(int.Parse(TxtStudentID.Text));
        }

        private void ExamNotes_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Lessons", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CmbLesson.ValueMember = "Name";
            CmbLesson.DisplayMember = "LessonID";
            CmbLesson.DataSource = dt;
            conn.Close();
        }

        int noteID;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            noteID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtStudentID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtExam1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtExam2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtExam3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProject.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtAverage.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        int exam1, exam2, exam3, project;
        double average;

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            //string status;

            exam1 = Convert.ToInt16(TxtExam1.Text);
            exam2 = Convert.ToInt16(TxtExam2.Text);
            exam3 = Convert.ToInt16(TxtExam3.Text);
            project = Convert.ToInt16(TxtProject.Text);
            average = (exam1 + exam2 + exam3 + project) / 4;
            TxtAverage.Text = average.ToString();
            if (average >= 50)
            {
                TxtStatus.Text = "True";
            }
            else
            {
                TxtStatus.Text = "False";
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.NoteUpdate(byte.Parse(CmbLesson.SelectedValue.ToString()), int.Parse(TxtStudentID.Text), byte.Parse(TxtExam1.Text), byte.Parse(TxtExam2.Text), byte.Parse(TxtExam3.Text), byte.Parse(TxtProject.Text), decimal.Parse(TxtAverage.Text), bool.Parse(TxtStatus.Text), noteID);
        }
    }
}
