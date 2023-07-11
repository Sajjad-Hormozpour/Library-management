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
    public partial class MM : Form
    {
        public MM()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//delete
        {
            #pragma warning disable CS8600 
            String Id = comboBox1.SelectedItem.ToString();
            #pragma warning restore CS8600 
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            String query = "DELETE FROM MM WHERE Id='" + Id + "'";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Changes saved");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)//panel,Gridview
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT * FROM MM";
            SqlCommand command = new SqlCommand(query, sc);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        private void MM_Load(object sender, EventArgs e)//select
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT * FROM MM";
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
        private void button1_Click_1(object sender, EventArgs e)//insert
        {
            string FN = First_nameMM.Text;
            string LN = Last_nameMM.Text;
            string P = PhoneMM.Text;
            string NC = National_codeMM.Text;
            string A = AddressMM.Text;
            string E = EmailMM.Text;
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "INSERT INTO MM (First_name,Last_name,Phone,National_code,Address,Email) VALUES (N'" + FN + "',N'" + LN + "',N'" + P + "',N'" + NC + "',N'" + A + "',N'" + E + "')";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Changes saved");
            First_nameMM.Text = Last_nameMM.Text = PhoneMM.Text = National_codeMM.Text = AddressMM.Text = EmailMM.Text = "";
        }

        private void MM_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void button3_Click(object sender, EventArgs e)//Update
        {
            string s1 = First_nameMM.Text;
            string s2 = Last_nameMM.Text;
            string s3 = PhoneMM.Text;
            string s4 = National_codeMM.Text;
            string s5 = AddressMM.Text; 
            string s6 = EmailMM.Text;
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "UPDATE MM SET First_name='" + s1 + "',Last_name='" + s2 + "',Phone='" + s3 + "',National_code='" + s4 + "',Address='" + s5 + "',Email='" + s6 + "'";
            SqlCommand command = new SqlCommand(@query, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Changes have been saved!!!!");
            First_nameMM.Text = Last_nameMM.Text = PhoneMM.Text = National_codeMM.Text = AddressMM.Text = EmailMM.Text = "";
        }
    }
}
