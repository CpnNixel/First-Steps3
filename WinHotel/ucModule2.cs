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
using System.Collections;
using System.Diagnostics;

namespace WinHotel
{
    public partial class ucModule2 : UserControl
    {
        public static string checker;
        private static ucModule2 _instance;
        public static ucModule2 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucModule2();
                return _instance;
            }

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
        public ucModule2()
        {
     
            InitializeComponent();
        }

        private void ucModule2_Load(object sender, EventArgs e)
        {
            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
            int peep_num = root.People.Count;
            Is_freeCheck(); //проверка незанятых номеров на фактическую занятость, и наоборот
            for (int i = 0; i < peep_num; i++)
            {

                string fullname = root.People[i].Name+" "+root.People[i].Surname+" "+root.People[i].Patronymic;
                string id = root.People[i].Id;
                DateTime en_date = root.People[i].Entry_date;
                DateTime dep_date = root.People[i].Departure_date;
                string phone = root.People[i].phone_num;
                int room = root.People[i].occ_room;

                ListViewItem lvi = new ListViewItem(fullname);
                lvi.SubItems.Add(id);
                lvi.SubItems.Add(en_date.ToString("MM/dd/yyyy hh:mm tt"));
                lvi.SubItems.Add(dep_date.ToString("MM/dd/yyyy hh:mm tt"));
                lvi.SubItems.Add(phone);
            
                lvi.SubItems.Add(room.ToString());

                //случай неправильного ввода даты
                if (DateTime.Compare(en_date, dep_date)>0 || DateTime.Compare(en_date, dep_date)==0)
                {
                    lvi.BackColor = Color.DarkGray;
                    //throw (new Exception("error, дата1 меньше даты2"));
                }
                //случай проживания после предполагаемой даты выезда
                else if (DateTime.Compare(DateTime.Now, dep_date) > 0)
                {
                    lvi.BackColor = Color.PaleVioletRed;
                }
                else
                    lvi.BackColor = Color.LightGreen;
           
                listView1.Items.Add(lvi);
            }
            if(peep_num!=0)
            checker = root.People[peep_num - 1].Id;
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listView1.ListViewItemSorter = new ListViewColumnComparer(e.Column);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Is_freeCheck();
            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
            int peep_num = root.People.Count;
            listView1.Items.Clear();
            for (int i = 0; i < peep_num; i++)
            {

                string fullname = root.People[i].Name + " " + root.People[i].Surname + " " + root.People[i].Patronymic;
                string id = root.People[i].Id;
                DateTime en_date = root.People[i].Entry_date;
                DateTime dep_date = root.People[i].Departure_date;
                string phone = root.People[i].phone_num;
                int room = root.People[i].occ_room;

                ListViewItem lvi = new ListViewItem(fullname);
                lvi.SubItems.Add(id);
                lvi.SubItems.Add(en_date.ToString("MM/dd/yyyy hh:mm tt"));
                lvi.SubItems.Add(dep_date.ToString("MM/dd/yyyy hh:mm tt"));
                lvi.SubItems.Add(phone);

                lvi.SubItems.Add(room.ToString());

                if (DateTime.Compare(en_date, dep_date) > 0 || DateTime.Compare(en_date, dep_date) == 0)
                {
                    lvi.BackColor = Color.DarkGray;
                    //throw (new Exception("ошибочка, дата1 меньше даты2"));
                }
                else if (DateTime.Compare(DateTime.Now, dep_date) > 0)
                {
                    lvi.BackColor = Color.PaleVioletRed;
                }
                else
                    lvi.BackColor = Color.LightGreen;

                listView1.Items.Add(lvi);
            }
            if (peep_num != 0)
                checker = root.People[peep_num - 1].Id;
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Is_freeCheck();
            if (checkBox1.Checked == true)
            {
                var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
                int peep_num = root.People.Count;
                listView1.Items.Clear();
                for (int i = 0; i < peep_num; i++)
                {
                    //MessageBox.Show(root.People[i].Departure_date.ToString("MM/dd/yyyy"), DateTime.Now.ToString("MM / dd / yyyy"));
                    
                    string fullname = root.People[i].Name + " " + root.People[i].Surname + " " + root.People[i].Patronymic;
                    string id = root.People[i].Id;
                    DateTime en_date = root.People[i].Entry_date;
                    DateTime dep_date = root.People[i].Departure_date;
                    string phone = root.People[i].phone_num;
                    int room = root.People[i].occ_room;

                    // string kek = dep_date.ToString("MM/dd/yyyy");
                    //string lul = DateTime.Now.ToString("MM/dd/yyyy");

                    //if departure date == today
                    if (String.Equals(dep_date.ToString("MM/dd/yyyy"), DateTime.Now.ToString("MM/dd/yyyy")))
                    {
                        ListViewItem lvi = new ListViewItem(fullname);
                        lvi.SubItems.Add(id);
                        lvi.SubItems.Add(en_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(dep_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(phone);

                        lvi.SubItems.Add(room.ToString());

                        listView1.Items.Add(lvi);
                    }
                }
                if (peep_num != 0)
                    checker = root.People[peep_num - 1].Id;
            }
            else if(checkBox1.Checked == false)
            {
                button2.PerformClick();
            }
        }
        private int Payment_counter(DateTime aft, DateTime before,int def=50)
        {
            int total = def * Daycount(aft, before);
            return total;
        }
        private int Daycount(DateTime aft,DateTime before)
        {
            //позже.удалить(раньше)
            TimeSpan ts = aft - before;
            int days = Math.Abs(ts.Days);
            return days;
        }
        private void Is_freeCheck()
        {
            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
            for(int i = 0; i < root.People.Count; i++)
            {
                for(int j = 0; i < root.Hotel_rooms.Count; j++)
                {
                    if (root.Hotel_rooms[j].Room_id.ToString() == root.People[i].occ_room.ToString())
                    {
                        root.Hotel_rooms[j].Is_free = false;
                        break;
                    }
                }
            }
            
            for(int ke = 0; ke < root.Hotel_rooms.Count; ke++)
            {
                string kek = root.Hotel_rooms[ke].Room_id.ToString();
                for(int le = 0; le < root.People.Count; le++)
                {
                    if(root.People[le].occ_room.ToString() == kek)
                    {
                        root.Hotel_rooms[ke].Is_free = false;
                        break;
                    }
                    else
                        root.Hotel_rooms[ke].Is_free = true;
                }
            }
            
            string newjson = new JavaScriptSerializer().Serialize(root);
            System.IO.File.WriteAllText(@"C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\file.json", newjson);
        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {}
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {}

        private void button3_Click(object sender, EventArgs e)
        {
            string type_of_room="";
            int moneys_per_day = 0;
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a client to proceed");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
                Person temp = new Person();

                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    //MessageBox.Show(listView1.SelectedItems[i].SubItems[5].Text);
                    for (int j = 0; j < root.People.Count; j++)
                    {
                        if (root.People[j].occ_room.ToString() == listView1.SelectedItems[i].SubItems[5].Text)
                        {
                            temp = root.People[j];
                            root.People.Remove(root.People[j]);
                            --j;
                        }
                    }
                    for (int k = 0; k < root.Hotel_rooms.Count; k++)
                    {
                        if (root.Hotel_rooms[k].Room_id.ToString() == listView1.SelectedItems[i].SubItems[5].Text)
                        {
                            root.Hotel_rooms[k].Is_free = true;
                            type_of_room = root.Hotel_rooms[k].Level;
                        }
                    }
                }

                /////////////////////////////
                //string since_days = 
                string kek = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
                kek.Substring(kek.Length - 5);
                kek += "-" + DateTime.Now.ToString("MM/dd/yyyy");



                string path = @"C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\reports\\";
                path.Substring(path.Length - 4);
                path += kek;
                path += ".txt";

                switch (type_of_room)
                {
                    case "low":
                        moneys_per_day = 50;
                        break;
                    case "middle":
                        moneys_per_day = 90;
                        break;
                    case "high":
                        moneys_per_day = 150;
                        break;
                }
                
                int days = Daycount(DateTime.Now, temp.Entry_date)+1;
                int money = Payment_counter(DateTime.Now, temp.Entry_date,moneys_per_day);
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Grand Hotel");
                        sw.WriteLine("____________");
                        sw.WriteLine("Client: "+ temp.Name + temp.Surname + temp.Patronymic);
                        
                        sw.WriteLine("Payment Cheque");
                        sw.WriteLine("____________");
                        sw.WriteLine("Stayed since:" + "\n " + temp.Entry_date.ToShortDateString());
                        sw.WriteLine("Stayed until:" + "\n " + DateTime.Now.ToShortDateString());
                        sw.WriteLine("Total days stayed:" + " " + days);
                        sw.WriteLine("Payment plan" + " $" + moneys_per_day.ToString() + ".00");
                        sw.WriteLine("____________");
                        sw.WriteLine("Total sum to pay:" + " $" + money + ".00");
                        sw.WriteLine("____________");
                        sw.WriteLine(DateTime.UtcNow);
                        sw.WriteLine("Thank you and Welcome!");
                    }
                }
                MessageBox.Show("Check saved.");

                var fileToOpen = path;
                var process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = fileToOpen
                };

                process.Start();
                process.WaitForExit();

                string newjson = new JavaScriptSerializer().Serialize(root);
                System.IO.File.WriteAllText(@"C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\file.json", newjson);
                button2.PerformClick();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //listView1.Sorting = SortOrder.Descending;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());

        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                int counter = 0;
                foreach (ListViewItem item in listView1.Items)
                {
                    counter++;
                    if (item.Selected)
                    {
                        var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
                        root.People.Remove(root.People[counter - 1]);
                        string newjson = new JavaScriptSerializer().Serialize(root);
                        System.IO.File.WriteAllText(@"C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\file.json", newjson);

                        listView1.Items.Remove(item);
                    }
                }
            }
        }

    
        private static void SearchTextInListView(ListView lst, string Search)
        {
            string iSearch = Search.ToLower();
            foreach (ListViewItem item in lst.Items)
            {
                if (item.Text.ToLower().Contains(iSearch))
                {
                    item.Selected = true;
                }
                //if (item.SubItems[1].Text.ToLower().Contains(iSearch))
                //{
                //	item.Selected = true;
                //}
            }
            RemoveUnselected(lst);
        }

        // remove unselected items
        private static void RemoveUnselected(ListView lst)
        {
            int i = 0;
            while (true)
            {
                if (i >= lst.Items.Count)
                {
                    break;
                }
                if (lst.Items[i].Selected == false)
                {
                    lst.Items[i].Remove();
                    i--;
                }
                i++;
            }
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
                if(textBox1.Text != "")
                {
                listView1.Items.Clear();
                    var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
                    int peep_num = root.People.Count;

                    for (int i = 0; i < peep_num; i++)
                    {

                        string fullname = root.People[i].Name + " " + root.People[i].Surname + " " + root.People[i].Patronymic;
                        string id = root.People[i].Id;
                        DateTime en_date = root.People[i].Entry_date;
                        DateTime dep_date = root.People[i].Departure_date;
                        string phone = root.People[i].phone_num;
                        int room = root.People[i].occ_room;

                        ListViewItem lvi = new ListViewItem(fullname);
                        lvi.SubItems.Add(id);
                        lvi.SubItems.Add(en_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(dep_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(phone);

                        lvi.SubItems.Add(room.ToString());

                        if (DateTime.Compare(en_date, dep_date) > 0 || DateTime.Compare(en_date, dep_date) == 0)
                        {
                            lvi.BackColor = Color.DarkGray;
                            //throw (new Exception("ошибочка, дата1 меньше даты2"));
                        }
                        else if (DateTime.Compare(DateTime.Now, dep_date) > 0)
                        {
                            lvi.BackColor = Color.PaleVioletRed;
                        }
                        else
                            lvi.BackColor = Color.LightGreen;

                        listView1.Items.Add(lvi);
                    }
                    if (peep_num != 0)
                        checker = root.People[peep_num - 1].Id;
                }
                SearchTextInListView(listView1, textBox1.Text);
            
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());

            listView1.Items.Clear();

            if(comboBox1.SelectedItem.ToString() == ""|| comboBox1.SelectedItem.ToString() == " ")
            {
                MessageBox.Show("Choose Parameter below");
            }
            else if (comboBox1.SelectedItem.ToString() == "Name")
            {
                foreach (Person kek in root.People)
                {
                    if (kek.Name.Contains(textBox1.Text.ToString()))
                    {
                        ListViewItem lvi = new ListViewItem(kek.Name);
                        lvi.SubItems.Add(kek.Id.ToString());
                        lvi.SubItems.Add(kek.Entry_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(kek.Departure_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(kek.phone_num);

                        lvi.SubItems.Add(kek.occ_room.ToString());

                        if (DateTime.Compare(kek.Entry_date, kek.Departure_date) > 0 || DateTime.Compare(kek.Entry_date, kek.Departure_date) == 0)
                        {
                            lvi.BackColor = Color.DarkGray;
                            //throw (new Exception("ошибочка, дата1 меньше даты2"));
                        }
                        else if (DateTime.Compare(DateTime.Now, kek.Departure_date) > 0)
                        {
                            lvi.BackColor = Color.PaleVioletRed;
                        }
                        else
                            lvi.BackColor = Color.LightGreen;

                        listView1.Items.Add(lvi);
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Passport ID")
            {
                foreach (Person kek in root.People)
                {
                    if (kek.Id.Contains(textBox1.Text.ToString()))
                    {
                        ListViewItem lvi = new ListViewItem(kek.Name);
                        lvi.SubItems.Add(kek.Id.ToString());
                        lvi.SubItems.Add(kek.Entry_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(kek.Departure_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(kek.phone_num);

                        lvi.SubItems.Add(kek.occ_room.ToString());

                        if (DateTime.Compare(kek.Entry_date, kek.Departure_date) > 0 || DateTime.Compare(kek.Entry_date, kek.Departure_date) == 0)
                        {
                            lvi.BackColor = Color.DarkGray;
                            //throw (new Exception("ошибочка, дата1 меньше даты2"));
                        }
                        else if (DateTime.Compare(DateTime.Now, kek.Departure_date) > 0)
                        {
                            lvi.BackColor = Color.PaleVioletRed;
                        }
                        else
                            lvi.BackColor = Color.LightGreen;

                        listView1.Items.Add(lvi);
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Phone")
            {
                foreach (Person kek in root.People)
                {
                    if (kek.phone_num.Contains(textBox1.Text.ToString()))
                    {
                        ListViewItem lvi = new ListViewItem(kek.Name);
                        lvi.SubItems.Add(kek.Id.ToString());
                        lvi.SubItems.Add(kek.Entry_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(kek.Departure_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(kek.phone_num);

                        lvi.SubItems.Add(kek.occ_room.ToString());

                        if (DateTime.Compare(kek.Entry_date, kek.Departure_date) > 0 || DateTime.Compare(kek.Entry_date, kek.Departure_date) == 0)
                        {
                            lvi.BackColor = Color.DarkGray;
                            //throw (new Exception("ошибочка, дата1 меньше даты2"));
                        }
                        else if (DateTime.Compare(DateTime.Now, kek.Departure_date) > 0)
                        {
                            lvi.BackColor = Color.PaleVioletRed;
                        }
                        else
                            lvi.BackColor = Color.LightGreen;

                        listView1.Items.Add(lvi);
                    }
                }

            }
            else if (comboBox1.SelectedItem.ToString() == "Room")
            { 
                foreach (Person kek in root.People)
                {
                    if (kek.occ_room.ToString().Contains(textBox1.Text.ToString()))
                    {
                        ListViewItem lvi = new ListViewItem(kek.Name);
                        lvi.SubItems.Add(kek.Id.ToString());
                        lvi.SubItems.Add(kek.Entry_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(kek.Departure_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(kek.phone_num);

                        lvi.SubItems.Add(kek.occ_room.ToString());

                        if (DateTime.Compare(kek.Entry_date, kek.Departure_date) > 0 || DateTime.Compare(kek.Entry_date, kek.Departure_date) == 0)
                        {
                            lvi.BackColor = Color.DarkGray;
                            //throw (new Exception("ошибочка, дата1 меньше даты2"));
                        }
                        else if (DateTime.Compare(DateTime.Now, kek.Departure_date) > 0)
                        {
                            lvi.BackColor = Color.PaleVioletRed;
                        }
                        else
                            lvi.BackColor = Color.LightGreen;

                        listView1.Items.Add(lvi);
                    }
                }
            }
        }

        private void ComboBox1_Click(object sender, EventArgs e)
        {
            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Name");
            comboBox1.Items.Add("Passport ID");
            comboBox1.Items.Add("Phone");
            comboBox1.Items.Add("Room");
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a client to proceed");
                return;
            }
            panel1.Visible = true;

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            DateTime dep_date = DateTime.Parse(dateTimePicker4.Text);
            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());

            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                //MessageBox.Show(listView1.SelectedItems[i].SubItems[5].Text);
                for (int j = 0; j < root.People.Count; j++)
                {
                    if (listView1.SelectedItems[i].Text.Contains(root.People[j].Name.ToString()))
                    {
                        root.People[j].Departure_date = dep_date;
                    }
                }
            }

            string newjson = new JavaScriptSerializer().Serialize(root);
            System.IO.File.WriteAllText(@"C:\\Users\\Nikitocik\\source\\repos\\WinHotel\\file.json", newjson);
            button2.PerformClick();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void DateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

            Is_freeCheck();
            if (checkBox2.Checked == true)
            {
                var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
                int peep_num = root.People.Count;
                listView1.Items.Clear();
                for (int i = 0; i < peep_num; i++)
                {
                    //MessageBox.Show(root.People[i].Departure_date.ToString("MM/dd/yyyy"), DateTime.Now.ToString("MM / dd / yyyy"));

                    string fullname = root.People[i].Name + " " + root.People[i].Surname + " " + root.People[i].Patronymic;
                    string id = root.People[i].Id;
                    DateTime en_date = root.People[i].Entry_date;
                    DateTime dep_date = root.People[i].Departure_date;
                    string phone = root.People[i].phone_num;
                    int room = root.People[i].occ_room;

                    // string kek = dep_date.ToString("MM/dd/yyyy");
                    //string lul = DateTime.Now.ToString("MM/dd/yyyy");

                    //if departure date == today
                    if (String.Equals(en_date.ToString("MM/dd/yyyy"), DateTime.Now.ToString("MM/dd/yyyy")))
                    {
                        ListViewItem lvi = new ListViewItem(fullname);
                        lvi.SubItems.Add(id);
                        lvi.SubItems.Add(en_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(dep_date.ToString("MM/dd/yyyy hh:mm tt"));
                        lvi.SubItems.Add(phone);

                        lvi.SubItems.Add(room.ToString());

                        listView1.Items.Add(lvi);
                    }
                }
                if (peep_num != 0)
                    checker = root.People[peep_num - 1].Id;
            }
            else if (checkBox2.Checked == false)
            {
                button2.PerformClick();
            }
        }
    }
    public class HotelRoom
    {
        public int Room_id { get; set; }
        public bool Is_free { get; set; }
        public string Level { get; set; }
        public int Beds_num { get; set; }
        public string Phone { get; set; }
        public Person[] Tenants { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Id { get; set; }
        public DateTime Entry_date { get; set; }
        public DateTime Departure_date { get; set; }
        public string phone_num { get; set; }
        public int occ_room { get; set; }
    }

    public class RootObject
    {
        public List<HotelRoom> Hotel_rooms { get; set; }
        public List<Person> People { get; set; }
    }
    class ListViewColumnComparer : IComparer
    {

        public int ColumnIndex { get; set; }

        public ListViewColumnComparer(int columnIndex)
        {
            ColumnIndex = columnIndex;
        }

        public int Compare(object x, object y)
        {

            try
            {
                return String.Compare(
                ((ListViewItem)x).SubItems[ColumnIndex].Text,
                ((ListViewItem)y).SubItems[ColumnIndex].Text);
            }
            catch (Exception) // если вдруг столбец пустой (или что-то пошло не так)
            {
                return 0;
            }
        }
    }
}
