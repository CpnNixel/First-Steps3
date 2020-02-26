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
    public partial class Form2 : Form
    {
        static int flag;

        static bool btn770_Clicked = false;
        static bool btn771_Clicked = false;
        static bool btn772_Clicked = false;
        static bool btn773_Clicked = false;
        static bool btn774_Clicked = false;
        static bool btn775_Clicked = false;
        static bool btn776_Clicked = false;
        static bool btn777_Clicked = false;
        static bool btn778_Clicked = false;
        static bool btn779_Clicked = false;
        static bool btn780_Clicked = false;
        static bool btn781_Clicked = false;
        static bool btn782_Clicked = false;
        static bool btn783_Clicked = false;
        static bool btn784_Clicked = false;
        static bool btn785_Clicked = false;
        static bool btn786_Clicked = false;
        static bool btn787_Clicked = false;
        static bool btn788_Clicked = false;
        static bool btn789_Clicked = false;
        static bool btn790_Clicked = false;

        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(400, 220);
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            MessageBox.Show(projectDirectory);
        }

        //proceed button
        private void button1_Click(object sender, EventArgs e)
        {
            
            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());

            string name1 = textBox1.Text;
            string name2 = textBox2.Text;
            string name3 = textBox3.Text;
            string id = textBox4.Text;
            string phone = textBox5.Text;
            DateTime en_date = DateTime.Parse(dateTimePicker1.Text);
            //TimeSpan en_time = DateTime.Parse(textBox5.Text).TimeOfDay;
            DateTime dep_date = DateTime.Parse(dateTimePicker4.Text);
            int room = flag;
            if(name1.Length<3 || name2.Length < 3 || name3.Length < 3 || id.Length < 3 || phone.Length < 3)
            {
                MessageBox.Show("Not all of the needed data is filled. Try again Please.");
                return;
            }

                //Гость1, которые живут за счет клиента
                string name_user2 = textBox11.Text;
            string surn_user2 = textBox10.Text;
            string num_user2 = textBox9.Text;

            //Гость2, которые живут за счет клиента
            string name_user3 = textBox6.Text;
            string surn_user3 = textBox7.Text;
            string num_user3 = textBox8.Text;

            root.People.Add(AddPerson(name1, name2, name3, id, en_date, dep_date, phone,room));
            if (checkBox1.Checked == true)
            {
                root.People.Add(AddPerson(name_user2, surn_user2, name3 = "", id = "###", en_date, dep_date, num_user2, room));
                if(checkBox2.Checked == true)
                {
                    root.People.Add(AddPerson(name_user3, surn_user3, name3 = "", id = "###", en_date, dep_date, num_user3, room));
                }
            }
            

            string newjson = new JavaScriptSerializer().Serialize(root);
            System.IO.File.WriteAllText(@"C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\file.json", newjson);
            colors();
            this.Close();

        }
        public static Person AddPerson(string name, string surn, string lname, string id, DateTime en_date, DateTime ldate, string phone, int room)
        {
            Person x = new Person() { Name = name, Surname = surn, Patronymic = lname, Id = id, Entry_date = en_date, Departure_date = ldate, phone_num = phone, occ_room = room };
            return x;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static string Jsonstring()
        {

            string path = "C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\file.json";
            string res = string.Empty;
            using (StreamReader r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);

                res = jobj.ToString();
                return res;
            }
        }


    


        
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                textBox2.Focus();
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                textBox3.Focus();
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                textBox4.Focus();
            }
        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                textBox5.Focus();
            }
        }
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                dateTimePicker1.Focus();
            }
        }
        

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                dateTimePicker4.Focus();
            }
        }

        private void dateTimePicker4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                button1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, KeyEventArgs e){}
        private void textBox1_Enter(object sender, EventArgs e){}
        private void textBox2_Enter(object sender, EventArgs e){}
        private void textBox3_Enter(object sender, EventArgs e){}
        private void textBox4_Enter(object sender, EventArgs e){}
        private void textBox5_Enter(object sender, EventArgs e){}
        private void textBox6_Enter(object sender, EventArgs e){}
        private void textBox2_KeyDown(object sender, EventArgs e){}
        private void textBox4_KeyDown(object sender, EventArgs e){}
        private void textBox3_KeyDown(object sender, EventArgs e){}
        private void textBox5_KeyDown(object sender, EventArgs e){}
        private void textBox6_KeyDown(object sender, EventArgs e){}
        private void textBox2_TextChanged(object sender, EventArgs e){}
        private void textBox4_TextChanged(object sender, EventArgs e){}
        private void textBox3_TextChanged(object sender, EventArgs e){}
        private void textBox5_TextChanged(object sender, EventArgs e){}
        private void textBox6_TextChanged(object sender, EventArgs e){}
        private void textBox1_TextChanged(object sender, EventArgs e){}

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {}

        private void Form2_Load(object sender, EventArgs e)
        { colors(); }
        public void colors()
        {
            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
            int i = 0;
            foreach (Button s in panel1.Controls.OfType<Button>())
            {
                if (root.Hotel_rooms[i].Is_free == true)
                {
                    s.BackColor = Color.LimeGreen;
                    i++;
                }
                else
                {
                    s.BackColor = Color.IndianRed;
                    i++;
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
            List<int> keker = new List<int>();

            for (int i = 0; i < root.Hotel_rooms.Count; i++)
            {
                if(root.Hotel_rooms[i].Is_free == true)
                {
                    keker.Add(root.Hotel_rooms[i].Room_id);
                }
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                button1.Focus();
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            rabota(788, btn788_Clicked, button3);
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            rabota(779, btn779_Clicked, button14);

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            rabota(777, btn777_Clicked, button16);
        }
        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void DateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            rabota(782, btn782_Clicked, button11);
        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void Button20_Click(object sender, EventArgs e)
        {
            rabota(774, btn774_Clicked, button20);
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            rabota(770, btn770_Clicked, button19);
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            rabota(773, btn773_Clicked, button18);
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            rabota(775, btn775_Clicked, button21);
        }

        private void Button17_Click(object sender, EventArgs e)
        {

            rabota(776, btn776_Clicked, button17);
        }

        private void Button15_Click(object sender, EventArgs e)
        {

            rabota(778, btn778_Clicked, button15);

        }

        private void Button13_Click(object sender, EventArgs e)
        {

            rabota(780, btn780_Clicked, button13);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            rabota(781, btn781_Clicked, button12);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
           
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            rabota(783, btn783_Clicked, button9);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            rabota(784, btn784_Clicked, button8);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            rabota(785, btn785_Clicked, button7);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            rabota(786, btn786_Clicked, button6);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            rabota(787, btn787_Clicked, button5);
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            rabota(789, btn789_Clicked, button2);
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            rabota(771, btn771_Clicked, button4);
        }

        //красит в цвет кнопку, меняет статус выбраной комнаты на свободный/занятый
        private void rabota(int flagz, bool btn_clicked, Button b)
        {

            flag = flagz;
            DialogResult dialogResult = MessageBox.Show("Sure", "ALert", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something

                var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
                if (btn_clicked == false)
                {
                    for (int i = 0; i < root.Hotel_rooms.Count; i++)
                    {
                        if (root.Hotel_rooms[i].Room_id == flag)
                        {
                            root.Hotel_rooms[i].Is_free = false;
                            btn_clicked = true;
                            b.BackColor = Color.LimeGreen;
                        }
                    }
                    string newjson = new JavaScriptSerializer().Serialize(root);
                    System.IO.File.WriteAllText(@"C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\file.json", newjson);
                }
                else
                {
                    for (int i = 0; i < root.Hotel_rooms.Count; i++)
                    {
                        if (root.Hotel_rooms[i].Room_id == flag)
                        {
                            root.Hotel_rooms[i].Is_free = true;
                            btn_clicked = false;
                        }
                    }

                    string newjson = new JavaScriptSerializer().Serialize(root);
                    System.IO.File.WriteAllText(@"C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\file.json", newjson);
                }
                colors();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        private void Button22_Click(object sender, EventArgs e)
        {
            rabota(770, btn770_Clicked, button22);
         
        }

        private void Button23_Click(object sender, EventArgs e)
        {

        }

        private void Button23_Click_1(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (panel3.Visible == true)
            {
                panel3.Visible = false;
            }
            else
            {
                panel3.Visible = true;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (panel2.Visible == true)
                panel2.Visible = false;
            else
                panel2.Visible = true;
        }

        //submit button
        private void Button10_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("\tIs all data correct?", "Alert", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (var button in panel1.Controls.OfType<Button>())
                {
                    if (button.BackColor == Color.IndianRed)
                    {
                        button.Enabled = false;
                    }
                    else
                        button.Enabled = true;
                }

                button10.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;

                pictureBox1.ImageLocation = "C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\WinHotel\\GIRLS-HOSTEL-GROUND-FLOOR-PLAN.jpg";
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                panel4.Visible = true;
                panel1.Visible = true;
                button1.Visible = true;
                button23.Visible = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        
        }

        private void Button23_Click_2(object sender, EventArgs e)
        {
            button10.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            checkBox1.Visible = true;
            checkBox2.Visible = true;

            pictureBox1.ImageLocation = "C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\WinHotel\\GIRLS-HOSTEL-GROUND-FLOOR-PLAN.jpg";
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            panel4.Visible = false;
            panel1.Visible = false;
            button1.Visible = false;
            button23.Visible = false;
        }

        private void CheckBox1_CheckStateChanged(object sender, EventArgs e)
        {
            
            checkBox2.Visible = true;
        }

        private void CheckBox2_CheckStateChanged(object sender, EventArgs e)
        {
            
           // panel6.Visible = true;
            //panel7.Visible = true;
            //panel8.Visible = true;

        }

        private void CheckBox2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label20_Click(object sender, EventArgs e)
        {

        }

        private void Label19_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Label23_Click(object sender, EventArgs e)
        {

        }

        private void Label22_Click(object sender, EventArgs e)
        {

        }

        private void Label21_Click(object sender, EventArgs e)
        {

        }
    }
}
