using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class Clubs : Form
    {
        public Clubs()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SchoolManagement;Integrated Security=True");

        void List()
        {
            SqlDataAdapter list = new SqlDataAdapter("SELECT * FROM CLUBS", conn);
            DataTable dt = new DataTable();
            list.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Clubs_Load(object sender, EventArgs e)
        {
            List();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand Add = new SqlCommand("INSERT INTO CLUBS(NAME) VALUES(@P1)", conn);
                Add.Parameters.AddWithValue("@P1", TxtClubName.Text);
                Add.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Club added to list", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List();
            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
            }
            /*
            catch
            {
                MessageBox.Show("Please do not enter more than 30 characters");  
            }
            */
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightGoldenrodYellow;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtClubID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtClubName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand delete = new SqlCommand("DELETE FROM CLUBS WHERE ID=@P1", conn);
            delete.Parameters.AddWithValue("@P1", TxtClubID.Text);
            delete.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Club deletion done");
            List();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand update = new SqlCommand("UPDATE CLUBS SET NAME=@P1 WHERE ID=@P2", conn);
            update.Parameters.AddWithValue("@P1", TxtClubName.Text);
            update.Parameters.AddWithValue("@P2", TxtClubID.Text);
            update.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Club Update completed");
            List();
        }
    }
}
