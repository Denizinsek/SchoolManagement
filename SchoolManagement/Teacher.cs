using System;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void BtnClup_Click(object sender, EventArgs e)
        {
            Clubs clubs = new Clubs();
            clubs.Show();
        }

        private void BtnLesson_Click(object sender, EventArgs e)
        {
            Lessons lessons = new Lessons();
            lessons.Show();
        }

        private void BtnStudent_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Show();
        }

        private void BtnExam_Click(object sender, EventArgs e)
        {
            ExamNotes examNotes = new ExamNotes();
            examNotes.Show();
        }
    }
}
