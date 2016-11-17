using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DTTK_HostInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string getEnv()
        {
            string nl = System.Environment.NewLine;
            string outString;

            textBox1.Text += "PC-Name: " + Environment.MachineName + nl;
            textBox1.Text += "Betriebssystem-Version: " + Environment.OSVersion + nl;
            textBox1.Text += "Benutzer-Domäne: " + Environment.UserDomainName + nl;
            textBox1.Text += "Benutzername: " + Environment.UserName + nl;
            textBox1.Text += "Computername: " +System.Environment.GetEnvironmentVariable("COMPUTERNAME").ToString() + nl;
            textBox1.Text += "Username: " + System.Environment.GetEnvironmentVariable("USERNAME") + nl;
            textBox1.Text += "Logon-Server: " + System.Environment.GetEnvironmentVariable("LOGONSERVER") + nl;
            textBox1.Text += "User-Domain: " + System.Environment.GetEnvironmentVariable("USERDOMAIN") + nl;
            textBox1.Text += "User DNS-Domain: " + System.Environment.GetEnvironmentVariable("USERDNSDOMAIN") + nl;
            textBox1.Text += "Roamingprofil: " + System.Environment.GetEnvironmentVariable("USERDOMAIN_ROAMINGPROFILE") + nl;
            textBox1.Text += "Benutzerprofil: " + System.Environment.GetEnvironmentVariable("USERPROFILE") + nl;

            dataGridView1.Rows.Add("PC-Name",Environment.MachineName);
            dataGridView1.Rows.Add("Betriebssystem-Version", Environment.OSVersion);
            dataGridView1.Rows.Add("Benutzer-Domäne" , Environment.UserDomainName);
            dataGridView1.Rows.Add("Benutzername",Environment.UserName);
            dataGridView1.Rows.Add("Computername" , System.Environment.GetEnvironmentVariable("COMPUTERNAME").ToString());
            dataGridView1.Rows.Add("Username" , System.Environment.GetEnvironmentVariable("USERNAME"));
            dataGridView1.Rows.Add("Logon-Server" , System.Environment.GetEnvironmentVariable("LOGONSERVER"));
            dataGridView1.Rows.Add("User-Domain" , System.Environment.GetEnvironmentVariable("USERDOMAIN"));
            dataGridView1.Rows.Add("User DNS-Domain" , System.Environment.GetEnvironmentVariable("USERDNSDOMAIN"));
            dataGridView1.Rows.Add("Roamingprofil" , System.Environment.GetEnvironmentVariable("USERDOMAIN_ROAMINGPROFILE"));
            dataGridView1.Rows.Add("Benutzerprofil", System.Environment.GetEnvironmentVariable("USERPROFILE"));
            dataGridView1.Rows.Add("Benutzerlaufwerk", System.Environment.GetEnvironmentVariable("HOMEDRIVE"));
            dataGridView1.Rows.Add("Benutzerpfad", System.Environment.GetEnvironmentVariable("HOMEPATH"));
            dataGridView1.Rows.Add("Betriebssystem", System.Environment.GetEnvironmentVariable("OS"));
            dataGridView1.Rows.Add("Prozessor-Architektur", System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
            dataGridView1.Rows.Add("Prozessor ID", System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));
            dataGridView1.Rows.Add("Prozessor Level", System.Environment.GetEnvironmentVariable("PROCESSOR_LEVEL"));
            dataGridView1.Rows.Add("Prozessor Revision", System.Environment.GetEnvironmentVariable("PROCESSOR_REVISION"));
            dataGridView1.Rows.Add("Anzahl Prozessoren", System.Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS"));

            return outString = textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getEnv();
        }

        private void saveFile()
        {
            DateTime dt = DateTime.Now;
            string s = dt.ToString("dd_MM_yyyy_HH_mm");
            string jetzt = s;
            string host;
            string outFile;
            host = System.Environment.MachineName;
            outFile = host + "_" + jetzt + ".txt";

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Console.WriteLine(saveFileDialog1.FileName);
            string defaultPath = "\\\bps\\upload\\daniel\\logons\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = false;
            saveFileDialog1.FileName = outFile;
            saveFileDialog1.InitialDirectory = defaultPath;
            //saveFileDialog1.InitialDirectory;
            if (saveFileDialog1.CheckPathExists)
            {

                MessageBox.Show(saveFileDialog1.FileName);

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (!System.IO.File.Exists(saveFileDialog1.FileName))
                        {
                            System.IO.File.Create(saveFileDialog1.FileName);
                            System.IO.File.WriteAllText(saveFileDialog1.FileName, getEnv());
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
            else MessageBox.Show("Speicherpfad: " + saveFileDialog1.InitialDirectory + "existiert nicht!");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClip_Click(object sender, EventArgs e)
        {
            ToClipboard(textBox1.Text);
               
        }
        private void ToClipboard(string text)
        {
            System.Windows.Forms.Clipboard.SetDataObject(text, true);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            ToClipboard(textBox1.Text);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void infoMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
