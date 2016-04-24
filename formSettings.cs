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
    public partial class formSettings : Form
    {
        public formSettings(string query, int interval)
        {
            InitializeComponent();
            this.nud_interval.Maximum = 200;
            this.nud_interval.Minimum = 1;
            this.nud_interval.Value = interval;

            string[] keywords = query.Split(new string[] { "|" }, StringSplitOptions.None);
            this.lb_Search_Category.Items.Clear();
            foreach (string item in keywords)
                this.lb_Search_Category.Items.Add(item);
        }

        private void BT_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            string str = "";
            for (int i = 0; i < this.lb_Search_Category.Items.Count; i++)
            {
                str += this.lb_Search_Category.Items[i];
                if (i+1 < this.lb_Search_Category.Items.Count)
                    str += "|";
            }
            Dirtywall.Program.searchQuery = str;
            Dirtywall.Program.interval = Convert.ToInt32(this.nud_interval.Value);

            Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newCategory = Microsoft.VisualBasic.Interaction.InputBox("Input category name", "New category", "");
            if (!string.IsNullOrEmpty(newCategory))
                lb_Search_Category.Items.Add(newCategory);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lb_Search_Category.SelectedIndex != -1)
            {
                string newNameCategory = Microsoft.VisualBasic.Interaction.InputBox("Input category name", "New name category", "");
                this.lb_Search_Category.Items.Insert(this.lb_Search_Category.SelectedIndex, newNameCategory);
                this.lb_Search_Category.Items.Remove(this.lb_Search_Category.SelectedItem);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lb_Search_Category.SelectedItems.Count == 1)
                this.lb_Search_Category.Items.Remove(this.lb_Search_Category.SelectedItem);
        }
    }
}
