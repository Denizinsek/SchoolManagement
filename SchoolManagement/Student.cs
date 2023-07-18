using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SchoolManagement;Integrated Security=True");
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void Student_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentList();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CLUBS", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CmbClub.DisplayMember = "NAME";
            CmbClub.ValueMember = "ID";
            CmbClub.DataSource = dt;
            conn.Close();
        }
        string gender = "";
        private void BtnAdd_Click(object sender, EventArgs e)
        {


            ds.StudentAdd(TxtName.Text, TxtSurname.Text, byte.Parse(CmbClub.SelectedValue.ToString()), gender);
            MessageBox.Show("Student Added");
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentList();
        }

        private void CmbClub_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtStudentID.Text = CmbClub.SelectedValue.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ds.StudentDel(int.Parse(TxtStudentID.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtStudentID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //CmbClub.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.StudentUpdate(TxtName.Text, TxtSurname.Text, byte.Parse(CmbClub.SelectedValue.ToString()), gender, int.Parse(TxtStudentID.Text));
        }

        private void RdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbFemale.Checked == true)
            {
                gender = "FEMALE";
            }
        }

        private void RdbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbMale.Checked == true)
            {
                gender = "MALE";
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentBring(TxtSearch.Text);
        }
    }
}
