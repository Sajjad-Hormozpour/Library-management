using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_management
{
    public partial class MU : Form
    {
        public MU()
        {
            InitializeComponent();
        }

        private void MU_Load(object sender, EventArgs e)//select
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT * FROM Login";
            SqlCommand command = new SqlCommand(query, sc);

            SqlDataReader reader = command.ExecuteReader();
          
            while (reader.Read())
            {
                #pragma warning disable CS8600
                string nam = reader["Id"].ToString();
                #pragma warning restore CS8600
                comboBox1.Items.Add(nam);
            }
        }

        private void button2_Click(object sender, EventArgs e)//delete
        {
            string s = PasswordRL.Text;
            #pragma warning disable CS8600
            String Id = comboBox1.SelectedItem.ToString();
            #pragma warning restore CS8600
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            String query = "DELETE FROM Login WHERE Id='" + Id + "'";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Changes saved");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UT = UsernameL.Text;
            string PT = PasswordL.Text;
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "INSERT INTO Login (Username,Password) VALUES (N'" + UT + "',N'" + PT + "')";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            if (PasswordRL.Text == PasswordL.Text)
            {
                sc.Close();
                MessageBox.Show("Changes saved!!");
                UsernameL.Text = PasswordL.Text = "";
            }
            else
            {
                MessageBox.Show("Please re-enter your Password!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT Id,Username FROM Login";
            SqlCommand command = new SqlCommand(query, sc);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView2.DataSource = dt;
        }

        private void MU_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
