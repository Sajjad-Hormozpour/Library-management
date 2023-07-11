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
    public partial class MB : Form
    {
        public MB()
        {
            InitializeComponent();
        }
      
        private void MB_Load(object sender, EventArgs e)//select
        {
            loadId();
        }
        private void loadId()
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT * FROM MB";
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
        private void button1_Click(object sender, EventArgs e)//insert
        {
            string Name = NameMB.Text;
            string Writer = WriterMB.Text;
            string Number = NumberMB.Text;
            string Publish_year = Publish_yearMB.Text;
            string Price = PriceMB.Text;
            string Subject = SubjectMB.Text;
            string Publisher = PriceMB.Text;
            string Shabek = ShabekMB.Text;
            string Translator = TranslatorMB.Text;
            string Publication = PublicationMB.Text;

            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "INSERT INTO MB (Name,Writer,Number,Publish_year,Price,Subject,Publisher,Shabek,Translator,publication) VALUES (N'" + Name + "',N'" + Writer + "',N'" + Number + "',N'" + Publish_year + "',N'" + Price + "',N'" + Subject + "',N'" + Publisher + "',N'" + Shabek + "',N'" + Translator + "',N'" + Publication + "')";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            loadId();
            sc.Close();
            MessageBox.Show("Changes saved");
            NameMB.Text = WriterMB.Text = NumberMB.Text = PublisherMB.Text = PriceMB.Text = SubjectMB.Text = PublisherMB.Text = ShabekMB.Text = TranslatorMB.Text = PublicationMB.Text = "";
        }


        private void button3_Click(object sender, EventArgs e)//Delete
        {
            #pragma warning disable CS8600 
            String Id = comboBox1.SelectedItem.ToString();
            #pragma warning restore CS8600 
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            String query = "DELETE FROM MB WHERE Id='" + Id + "'";
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Changes saved");
        }

        private void MB_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)//select Gridview
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT * FROM MB";
            SqlCommand command = new SqlCommand(query, sc);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            sc.Close();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)// update
        {
            string s1 = NameMB.Text;
            string s2 = WriterMB.Text;
            string s3 = NumberMB.Text;
            string s4 = Publish_yearMB.Text;
            string s5 = PriceMB.Text;
            string s6 = SubjectMB.Text;
            string s7 = PublisherMB.Text;
            string s8 = ShabekMB.Text;
            string s9 = TranslatorMB.Text;
            string s10 = PublicationMB.Text;
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "UPDATE MB SET Name=N'" + s1 + "',Writer=N'" + s2 + "',Number=N'" + s3 + "',Publish_year=N'" + s4 + "',Price=N'" + s5 + "',Subject=N'" + s6 + "',Publisher='" + s7 + "',Shabek=N'" + s8 + "',Translator=N'" + s9 + "',Publication=N'" + s10 + "'";
            SqlCommand command = new SqlCommand(@query, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Changes have been saved!!!!");
            NameMB.Text = WriterMB.Text = NumberMB.Text = Publish_yearMB.Text = PriceMB.Text = SubjectMB.Text = PublisherMB.Text = ShabekMB.Text = TranslatorMB.Text = PublicationMB.Text = "";
        }
    }
}
