using System;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class Lessons : Form
    {
        public Lessons()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.LessonsTableAdapter dataset = new DataSet1TableAdapters.LessonsTableAdapter();

        private void Lessons_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataset.LessonList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            dataset.AddLesson(TxtLessonName.Text);
            MessageBox.Show("Lesson Addition Process Has Been Made");
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataset.LessonList();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dataset.DeleteLesson(byte.Parse(TxtLessonID.Text));
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            dataset.UpdateLesson(TxtLessonID.Text, byte.Parse(TxtLessonName.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtLessonID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtLessonName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
