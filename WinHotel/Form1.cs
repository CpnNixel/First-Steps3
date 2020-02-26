using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;


namespace WinHotel
{
    public partial class MainForm : Form
    {

        List<Panel> listPanel = new List<Panel>();
        int index;

        public MainForm()
        {
            InitializeComponent();
            textBox1.Text = "admin";
            textBox2.Text = "admin";
        }

        //string[] usernames = { "username1", "username2" };
        //string[] passwords = { "password1", "password2" };
        
        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel[index].BringToFront();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if(textBox1.Text != "admin" || textBox2.Text != "admin")
            {
                MessageBox.Show(" Inccorrect login or password.\n Try again or send email on grand.hotel@gmail.com");
                textBox1.Text = "";
                textBox2.Text = "";

            }
            else
            {
                btnModule1.Visible = true;
                btnModule2.Visible = true;
                panel2.Visible = true;
                button2.Visible = true;
                panel1.Visible = false;
                if (index < listPanel.Count - 1)
                    listPanel[++index].BringToFront();
                btnModule1.PerformClick();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Do you want to leave?",
        "Important Message",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                btnModule1.Visible = false;
                btnModule2.Visible = false;
                panel2.Visible = false;
                button2.Visible = false;
                panel1.Visible = true;
                if (index > 0)
                {
                    listPanel[--index].BringToFront();
                }
            }
            else
            {
                panel5.Visible = true;
                panel5.Height = button2.Height;
                panel5.Top = button2.Top;
                panel5.BringToFront();
            }
        }

        private void password_Click(object sender, EventArgs e)
        {

        }
        //////////////////////////////////////////////////////
        private void btnModule1_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel5.Height = btnModule1.Height;
            panel5.Top = btnModule1.Top;
            panel5.BringToFront();


            if (!panel3.Controls.Contains(ucModule1.Instance))
            {
                panel3.Controls.Add(ucModule1.Instance);
                ucModule1.Instance.Dock = DockStyle.Fill;
                ucModule1.Instance.BringToFront();
            }
            else ucModule1.Instance.BringToFront();
        }

        private void btnModule2_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel5.Height = btnModule2.Height;
            panel5.Top = btnModule2.Top;

            panel5.BringToFront();

            if (!panel3.Controls.Contains(ucModule2.Instance))
            {
                panel3.Controls.Add(ucModule2.Instance);
                ucModule2.Instance.Dock = DockStyle.Fill;
                ucModule2.Instance.BringToFront();
            }
            else ucModule2.Instance.BringToFront();
        }

        private void btnModule3_Click(object sender, EventArgs e)
        {
           
            
        }
       
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Newbutton_Click(object sender, EventArgs e)
        {
            

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Username_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            textBox2.Focus();
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox1.Focus();
            if (e.KeyCode == Keys.Down)
                button1.Focus();
        }
    }

}
