using System;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StudentNotes studentNotes = new StudentNotes();
            studentNotes.number = textBox1.Text;
            studentNotes.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.Show();
            this.Hide();
        }
    }
}
