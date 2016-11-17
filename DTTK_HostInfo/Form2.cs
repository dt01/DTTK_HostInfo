using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DTTK_HostInfo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(DialogResult dialogResult)
        {
            DialogResult = dialogResult;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = Application.CompanyName;
        }
    }
}
