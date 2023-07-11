using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_management
{
    public partial class L : Form
    {
        public L()
        {
            InitializeComponent();
        }
        MB MB = new MB();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MB.Show();
        }

        MM MM = new MM();
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MM.Show();
        }

        ML ML = new ML();
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ML.Show();
        }

        MU MU = new MU();
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MU.Show();
        }

        LB LB = new LB();
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LB.Show();
        }

        about about = new about();
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            about.Show();
        }

        Shelf Shelf = new Shelf();  
        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Shelf.Show();
        }
        SB SB = new SB();
        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SB.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Setting Setting = new Setting();
        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setting.Show();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
