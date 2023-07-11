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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        L L = new L();
        private void button1_Click(object sender, EventArgs e)
        {
            {
                try

                {
                    string Username = textBox1.Text;
                    string password = textBox2.Text;

                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
                    sqlConnection.Open();
                    string query = " SELECT password FROM Login WHERE Username = '" + Username + "'";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    #pragma warning disable CS8600 
                    string pass = reader["password"].ToString();
                    #pragma warning restore CS8600 
                    if (password == pass)
                    {
                        L.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username or password incorrect plz try again ");
                    }
                    sqlConnection.Close();

                }
                catch (Exception )
                {
                    MessageBox.Show("Username or password incorrect plz try again ");
                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("این قسمت هنوز موجود نمیباشد ");
        }
    }
}
