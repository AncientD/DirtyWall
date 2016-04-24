using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dirtywall
{
    public partial class Form1 : Form
    {
        public Form1(string query, int interval)
        {
            InitializeComponent();
            this.numericUpDown1.Maximum = 200;
            this.numericUpDown1.Minimum = 1;
            this.numericUpDown1.Value = interval;

            string[] keywords = query.Split(new string[] { "|" }, StringSplitOptions.None);
            this.listBox1.Items.Clear();
            foreach (string item in keywords)
                this.listBox1.Items.Add(item);
        }

        private void BT_remove_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItems.Count == 1)
                this.listBox1.Items.Remove(this.listBox1.SelectedItem);
        }

        private void BT_Add_category_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length > 1)
                this.listBox1.Items.Add(this.textBox1.Text);
        }

        private void BT_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            string str = "";
            for (int i = 0; i < this.listBox1.Items.Count; i++)
            {
                str += this.listBox1.Items[i];
                if (i+1 < this.listBox1.Items.Count)
                    str += "|";
            }
            Dirtywall.Program.searchQuery = str;
            Dirtywall.Program.interval = Convert.ToInt32(this.numericUpDown1.Value);

            Close();
        }
    }
}
