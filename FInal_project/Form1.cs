using CsvHelper;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace FInal_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            personBindingSource.DataSource = new List<Person>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_id.Text) || string.IsNullOrEmpty(text_firstname.Text) || string.IsNullOrEmpty(text_lastname.Text))
                return;

            string in_id = this.text_id.Text;
            string in_firstnamename = this.text_firstname.Text;
            string in_lastname = this.text_lastname.Text;

            ListViewItem item = new ListViewItem(in_id);
            item.SubItems.Add(in_firstnamename);
            item.SubItems.Add(in_lastname);
            listView1.Items.Add(item);

            text_id.Clear();
            text_firstname.Clear();
            text_lastname.Clear();

            gridps gridps = new gridps();
            gridps.id = in_id;
            gridps.firstname = in_firstnamename;
            gridps.lastname = in_lastname;


        }

        private void Remvoe_but_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string ID = listView1.SelectedItems[0].SubItems[0].Text;
                string fname = listView1.SelectedItems[0].SubItems[1].Text;
                string lname = listView1.SelectedItems[0].SubItems[2].Text;

                textBox1.Text = ID;
                textBox2.Text = fname;
                textBox3.Text = lname;
            }
            else
            {
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            listView1.SelectedItems.Clear();
            l1.Checked = false; l2.Checked = false;
            l3.Checked = false; d5.Checked = false;
            d4.Checked = false; d3.Checked = false;
            d2.Checked = false; d1.Checked = false;
            g5.Checked = false; l4.Checked = false;
            l5.Checked = false; o5.Checked = false;
            o4.Checked = false; o3.Checked = false;
            o2.Checked = false; o1.Checked = false;
            g4.Checked = false; g3.Checked = false;
            g2.Checked = false; g1.Checked = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int l = 0;
            int o = 0;
            int d = 0;
            int g = 0;

            string id = this.textBox1.Text;
            string fname = this.textBox2.Text;
            string lname = this.textBox3.Text;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                return;

            if (l1.Checked) { l = 1; }
            if (l2.Checked) { l = 2; }
            if (l3.Checked) { l = 3; }
            if (l4.Checked) { l = 4; }
            if (l5.Checked) { l = 5; }

            if (o1.Checked) { o = 1; }
            if (o2.Checked) { o = 2; }
            if (o3.Checked) { o = 3; }
            if (o4.Checked) { o = 4; }
            if (o5.Checked) { o = 5; }

            if (d1.Checked) { d = 1; }
            if (d2.Checked) { d = 2; }
            if (d3.Checked) { d = 3; }
            if (d4.Checked) { d = 4; }
            if (d5.Checked) { d = 5; }

            if (g1.Checked) { g = 1; }
            if (g2.Checked) { g = 2; }
            if (g3.Checked) { g = 3; }
            if (g4.Checked) { g = 4; }
            if (g5.Checked) { g = 5; }

            if (l == 0 | o == 0 | d == 0 | g == 0) { return; }
            else
            {
                Person person = new Person(id, fname, lname, l, o, d, g);
                personBindingSource.Add(person);
            }
            //clear
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            listView1.SelectedItems.Clear();
            l1.Checked = false; l2.Checked = false;
            l3.Checked = false; d5.Checked = false;
            d4.Checked = false; d3.Checked = false;
            d2.Checked = false; d1.Checked = false;
            g5.Checked = false; l4.Checked = false;
            l5.Checked = false; o5.Checked = false;
            o4.Checked = false; o3.Checked = false;
            o2.Checked = false; o1.Checked = false;
            g4.Checked = false; g3.Checked = false;
            g2.Checked = false; g1.Checked = false;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //savefile
            //ssl 1 doens't work cansave file **no header no data**
            //ss3 work but doesn't contect to datasouce
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog1.Title = "Save CSV file";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            if (j != dataGridView1.Columns.Count - 1)
                            {
                                writer.Write(",");
                            }
                        }
                        writer.WriteLine("");
                    }
                }
            }

        }

        private void readFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                TextFieldParser parser = new TextFieldParser(filePath);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                int idcolum = 0;
                int firsnamecolum = 1;
                int lastnamecolum = 2;
                int leadership = 3;
                int ontime = 4;
                int dutifu = 5;
                int giveusefulinfomation = 6;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    string iddata = fields[idcolum];
                    string fname = fields[firsnamecolum];
                    string lname = fields[lastnamecolum];
                    int Readledership = Int32.Parse(fields[leadership]);
                    int Readontime = Int32.Parse(fields[ontime]);
                    int Readdutiful = Int32.Parse(fields[dutifu]);
                    int Readgiveusefulinfomation = Int32.Parse(fields[giveusefulinfomation]);

                    Person readperson = new Person(iddata, fname, lname, Readledership, Readontime, Readdutiful, Readgiveusefulinfomation);
                    personBindingSource.Add(readperson);
                    //string fname = fields[firsnamecolum];
                    //string lname = fields[lastnamecolum];

                    // Do something with the data
                }

            }
        }
    }
}