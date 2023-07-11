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
    public partial class ML : Form
    {
        public ML()
        {
            InitializeComponent();
        }

        private void ML_Load(object sender, EventArgs e)//select
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT * FROM ML";
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

        private void panel1_Paint(object sender, PaintEventArgs e)//panel,Gridview
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT * FROM ML";
            SqlCommand command = new SqlCommand(query, sc);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)//delete
        {
            #pragma warning disable CS8600
            String Id = comboBox1.SelectedItem.ToString();
            #pragma warning restore CS8600
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            String query = "DELETE FROM ML WHERE Id='" + Id + "'";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Changes saved");
        }

        private void button1_Click(object sender, EventArgs e)//insert
        {
            string BookN = Book_nameML.Text;
            string MemberC = Member_codeML.Text;
            string FirstN = First_nameML.Text;
            string LastN = Last_nameML.Text;
            string BorrowD = Borrow_dateML.Text;
            string BackD = Back_dateML.Text;
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "INSERT INTO ML (Book_name,Member_code,First_name,Last_name,Borrow_date,Back_date) VALUES (N'" + BookN + "',N'" + MemberC + "',N'" + FirstN + "',N'" + LastN + "',N'" + BorrowD + "',N'" + BackD + "')";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Changes saved");
            Borrow_dateML.Text = Member_codeML.Text = First_nameML.Text = Last_nameML.Text = Borrow_dateML.Text = Back_dateML.Text = "";
        }

        private void ML_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = Book_nameML.Text;
            string s2 = Member_codeML.Text;
            string s3 = First_nameML.Text;
            string s4 = Last_nameML.Text;
            string s5 = Borrow_dateML.Text;
            string s6 = Back_dateML.Text;
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "UPDATE ML SET First_name=N'" + s3 + "',Last_name=N'" + s4 + "',Book_name=N'" + s1 + "',Member_code=N'" + s2 + "',Borrow_date=N'" + s5 + "',Back_date=N'" + s6 + "'";
            SqlCommand command = new SqlCommand(@query, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Changes have been saved!!!!");
            Book_nameML.Text = Member_codeML.Text = First_nameML.Text = Last_nameML.Text = Borrow_dateML.Text = Back_dateML.Text = "";
        }
    }
}
