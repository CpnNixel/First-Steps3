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


namespace WinHotel
{

    public partial class ucModule1 : UserControl
    {
        private static ucModule1 _instance;
        public static ucModule1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucModule1();
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
        public ucModule1()
        {


            InitializeComponent();

        }

        private void ucModule1_Load(object sender, EventArgs e)
        {
            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
            int room_num = root.Hotel_rooms.ToArray().Length;
            for (int i = 0; i < room_num - 1; i++)
            {
                /*
                ComboBox comboBox33 = new ComboBox();
                comboBox33.Location = new Point(100, 240);
     
                comboBox33.Visible = true;

               */

               
                int kekz = root.Hotel_rooms[i].Room_id;
                bool isfree = root.Hotel_rooms[i].Is_free;
                string lelvel = root.Hotel_rooms[i].Level;
                int bedsnum = root.Hotel_rooms[i].Beds_num;
                string phone = root.Hotel_rooms[i].Phone;

                ListViewItem lvi = new ListViewItem(kekz.ToString());
                lvi.SubItems.Add(lelvel);
                lvi.SubItems.Add(bedsnum.ToString());
                lvi.SubItems.Add(isfree.ToString());
                lvi.SubItems.Add(phone);
                listView1.Items.Add(lvi);
            }



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var root = new JavaScriptSerializer().Deserialize<RootObject>(Jsonstring());
            List<int> kek = new List<int>();
            richTextBox1.Clear();
            panel1.Visible = true;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    for (int j = 0; j < root.People.Count; j++)
                    {
                        if (root.People[j].occ_room == Convert.ToInt32(listView1.Items[i].Text))
                        {
                            richTextBox1.AppendText(root.People[j].Name +" "+ root.People[j].Surname + " " + root.People[j].Patronymic + " " + "\n(Phone: +" + root.People[j].phone_num+ ")\n\n");
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, ColumnClickEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        //В событие клик добавляет компаратор
        {
            this.listView1.ListViewItemSorter = new ListViewColumnComparer(e.Column);

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
        public class HotelRoom
        {
            public int Room_id { get; set; }
            public bool Is_free { get; set; }
            public string Level { get; set; }
            public int Beds_num { get; set; }
            public string Phone { get; set; }
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

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void ComboBox1_Click(object sender, EventArgs e)
        {
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
